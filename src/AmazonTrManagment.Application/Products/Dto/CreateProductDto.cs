namespace AmazonTrManagment.Products.Dto
{
    public class CreateProductDto
	{
        public string Asin { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
		public string Brand { get; set; }
	}
}
