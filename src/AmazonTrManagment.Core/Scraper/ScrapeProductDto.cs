using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTrScrapingWinFrom.Models
{
	public class ScrapeProductDto
	{
		public string Asin { get; set; }
		public string Name { get; set; }
		public string Brand { get; set; }
		public string Details { get; set; }
		public decimal? ProductPrice { get; set; }
		public decimal? ShipmentPrice { get; set; }
		public decimal? TotalPrice { get; set; } //  ProductPrice + ShipmentPrice
		public decimal? SellPrice { get; set; }
		public int StockQuantity { get; set; }
		public bool HasStock => StockQuantity > 0;
		public bool NotAvailableInStore { get; set; }
		public string ImageUrl1 { get; set; }
		public string ImageUrl2 { get; set; }
		public string ImageUrl3 { get; set; }
		public string ImageUrl4 { get; set; }
		public string ImageUrl5 { get; set; }
		public string ImageUrl6 { get; set; }
	}
}
