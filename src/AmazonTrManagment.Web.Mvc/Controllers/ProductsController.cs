using AmazonTrManagment.Controllers;
using AmazonTrManagment.Products;
using AmazonTrManagment.Products.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npoi.Mapper;
using NPOI.SS.UserModel;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonTrManagment.Web.Controllers
{
	public class ProductsController : AmazonTrManagmentControllerBase
	{
		private readonly IProductAppService _productAppService;

		public ProductsController(IProductAppService productAppService)
		{
			_productAppService = productAppService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> FileUpload(IFormFile formFile)
		{
			if (formFile != null)
			{
				var extent = Path.GetExtension(formFile.FileName);
				var randomName = ($"{Guid.NewGuid()}{extent}");
				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);

				using var stream = new FileStream(path, FileMode.Create);
				await formFile.CopyToAsync(stream);
				var workbook = WorkbookFactory.Create(stream);
				var mapper = new Mapper(workbook);
				var excelProducts = mapper.Take<CreateProductDto>();

				await _productAppService.CreateProducts(excelProducts.Select(x => x.Value).ToList());
			}

			return RedirectToAction("Index");
		}

	}
}
