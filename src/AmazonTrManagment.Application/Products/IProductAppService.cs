using Abp.Application.Services;
using AmazonTrManagment.Products.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonTrManagment.Products
{
    public interface IProductAppService : IApplicationService
	{
		Task CreateProducts(List<CreateProductDto> products);

	}
}
