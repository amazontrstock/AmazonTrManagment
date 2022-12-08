using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AmazonTrManagment.Products.Dto;
using AmazonTrManagment.Users.Dto;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Abp.EntityFrameworkCore.Repositories;

namespace AmazonTrManagment.Products
{
	public class ProductAppService : IProductAppService
	{
		private readonly IRepository<Product> _productRepository;

		public ProductAppService(IRepository<Product> productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<PagedResultDto<ProductDto>> GetAllAsync(PagedUserResultRequestDto input)
		{
			var query = _productRepository.GetAll();
			var totalCount = await query.CountAsync();

			var products = await query
				.Skip(input.SkipCount)
				.Take(input.MaxResultCount)
				.Select(x => new ProductDto
				{
					Id = x.Id,
					Asin = x.Asin,
					Name = x.Name,
					Brand = x.Brand,
					StockQuantity = x.StockQuantity
				})
				.ToListAsync();

			return new PagedResultDto<ProductDto> { Items = products, TotalCount = totalCount };
		}

		public async Task CreateProducts(List<CreateProductDto> products)
		{
			if (!products.Any())
				return;

			var productAsins = products.Select(x => x.Asin).ToList();
			var existAsins = await _productRepository
				.GetAll()
				.Where(x => productAsins.Contains(x.Asin)).Select(s => s.Asin)
				.ToListAsync();

			products.RemoveAll(x => existAsins.Contains(x.Asin));

			var insertEntities = products.Select(x => new Product
			{
				Asin = x.Asin,
				Brand = x.Brand,
				Name = x.Name,
				StockQuantity = x.StockQuantity
			}).ToList();

			await _productRepository.GetDbContext().AddRangeAsync(insertEntities);
		}
	}
}
