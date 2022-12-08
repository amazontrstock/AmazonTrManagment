using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Repositories;
using AmazonTrManagment.Email;
using AmazonTrManagment.Products;
using AmazonTrManagment.Scraper;
using AmazonTrScrapingWinFrom.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTrManagment.StockManagment
{
	public class StockManagmentService : DomainService, IStockManagmentService
	{
		private readonly IRepository<Product, int> _productRepository;
		private readonly IEmailService _emailService;

		public StockManagmentService(IRepository<Product, int> productRepository,
			IEmailService emailService)
		{
			_productRepository = productRepository;
			_emailService = emailService;
		}

		[UnitOfWork]
		public async Task StartStockManagment()
		{
			var products = await _productRepository.GetAll().ToListAsync();
			if (!products.Any())
				return;

			string brTag = "<br/>";

			var bodySb = new StringBuilder();
			var productScraper = new ProductDetailScraper();
			var lessStockQuantityProducts = new List<EmailProductDto>();
			foreach (var item in products.Where(x => !string.IsNullOrEmpty(x.Asin)))
			{
				ScrapeProductDto scrapeProduct;
				try
				{
					scrapeProduct = await productScraper.ProductScraper(item.Asin);
				}
				catch (Exception ex)
				{
					continue;
				}
				if (scrapeProduct != null)
				{
					if (item.StockQuantity > scrapeProduct.StockQuantity)
						lessStockQuantityProducts.Add(new EmailProductDto
						{
							Asin = item.Asin,
							OldStock = item.StockQuantity,
							NewStock = scrapeProduct.StockQuantity
						});

					item.StockQuantity = scrapeProduct.StockQuantity;
				}
			}

			await _productRepository.GetDbContext().SaveChangesAsync();

			foreach (var item in lessStockQuantityProducts)
			{
				bodySb.AppendLine($"Asin: {item.Asin}   Eski Stok: {item.OldStock}   Yeni Stok: {item.NewStock}");
			}

			await _emailService.SendEmail(bodySb.ToString());
		}
	}
}
