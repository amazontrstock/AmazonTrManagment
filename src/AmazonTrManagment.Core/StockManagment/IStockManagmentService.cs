using Abp.Dependency;
using Abp.Domain.Services;
using System.Threading.Tasks;

namespace AmazonTrManagment.StockManagment
{
	public interface IStockManagmentService : IDomainService
	{
		Task StartStockManagment();
	}
}
