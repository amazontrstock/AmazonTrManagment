using Abp.Domain.Entities.Auditing;

namespace AmazonTrManagment.Products
{
	public class Product : AuditedEntity<int>
	{
		public string Asin { get; set; }
		public string Name { get; set; }
		public int StockQuantity { get; set; }
		public string Brand { get; set; }
	}
}
