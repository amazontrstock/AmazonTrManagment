namespace AmazonTrManagment.StockManagment
{
	public class EmailProductDto
	{
		public string Asin { get; set; }
		public int OldStock { get; set; }
		public int NewStock { get; set; }
	}
}
