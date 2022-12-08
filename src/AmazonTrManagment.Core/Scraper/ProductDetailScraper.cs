using AmazonTrScrapingWinFrom.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace AmazonTrManagment.Scraper
{
	public class ProductDetailScraper
	{
		public async Task<ScrapeProductDto> ProductScraper(string asin)
		{
			//asin = "B0BJVXP3QF";
			var html = await HttpHelper.GetHtmlByLink($"https://www.amazon.com.tr/dp/{asin}");
			html = HttpUtility.HtmlDecode(html);

			var htmlDoc = new HtmlDocument();
			htmlDoc.LoadHtml(html);

			var product = new ScrapeProductDto
			{
				Asin = asin,
				Name = GetProductTitle(htmlDoc),
				Brand = GetProductBrand(htmlDoc),
				ProductPrice = GetProductPrice(htmlDoc),
				StockQuantity = GetStockQuantity(htmlDoc),
				Details = GetProductDetails(htmlDoc)
			};

			return product;
		}

		private string GetProductTitle(HtmlDocument htmlDoc)
		{
			var titleElem = htmlDoc.DocumentNode.SelectSingleNode("//span[@id=\"productTitle\"]");
			if (titleElem != null)
				return titleElem.InnerText.Trim();

			var titleElemTwo = htmlDoc.DocumentNode.SelectSingleNode("//h1[@id=\"title\"]");
			if (titleElemTwo != null)
				return titleElemTwo.InnerText.Trim();

			return string.Empty;
		}

		private string GetProductBrand(HtmlDocument htmlDoc)
		{
			var brand = htmlDoc.DocumentNode.SelectSingleNode("//div[@id=\"bylineInfo_feature_div\"]");
			if (brand != null && brand.InnerText.ToLower().Contains("marka"))
				return brand.InnerText.Split("Marka: ")[1].Trim().Replace("amp;", "");
			else if (brand != null && brand.InnerText.ToLower().Contains("store'unu"))
				return brand.InnerText.Split("Store'unu")[0].Trim().Replace("amp;", "");

			return string.Empty;
		}

		private decimal GetProductPrice(HtmlDocument htmlDoc)
		{
			var removedElem = htmlDoc.DocumentNode.SelectSingleNode("//div[@id=\"percolate-ui-lpo_div\"]");
			if (removedElem != null)
				removedElem.Remove();

			var priceElem = htmlDoc.DocumentNode.SelectSingleNode("//span[@class=\"a-offscreen\"]");
			if (priceElem != null)
			{
				decimal.TryParse(priceElem.InnerText
					.Replace("TL", "").Trim(), out var purchasePrice);

				return purchasePrice;
			}

			return 0;
		}

		private int GetStockQuantity(HtmlDocument htmlDoc)
		{
			var stockElem = htmlDoc.DocumentNode.SelectSingleNode("//div[@id=\"availability\"]");
			if (stockElem != null)
			{
				var stockElemText = stockElem.InnerText.Trim().ToLower();
				if (stockElemText.ToLower().Contains("stokta sadece"))
				{
					var quantityText = stockElemText.Split("sadece")[1].Split("adet")[0].Trim();
					if (int.TryParse(quantityText, out int quantity))
						return quantity;
				}
				else if (stockElemText.ToLower().Contains("stokta yok"))
					return 0;
				else if (stockElemText.ToLower().Contains("stokta var"))
					return 20;
			}

			return 0;
		}

		private string GetProductDetails(HtmlDocument htmlDoc)
		{
			var details = htmlDoc.DocumentNode.SelectSingleNode("//div[@id=\"productOverview_feature_div\"]");
			if (details != null && !string.IsNullOrEmpty(details.InnerText.Trim()))
				return details.InnerText.Trim();

			var detailsTwo = htmlDoc.DocumentNode.SelectSingleNode("//div[@id=\"featurebullets_feature_div\"]");
			if (detailsTwo != null)
			{
				if (!string.IsNullOrEmpty(detailsTwo.InnerText.Trim()))
					return detailsTwo.InnerText.Trim();
			}

			var detailsThree = htmlDoc.DocumentNode.SelectSingleNode("//div[@id=\"productFactsDesktop_feature_div\"]");
			if (detailsThree != null)
			{
				var removedElem = htmlDoc.DocumentNode.SelectSingleNode("//div[@id=\"productFactsToggleButton\"]");
				if (removedElem != null)
					removedElem.Remove();

				var detailsThreeIn = htmlDoc.DocumentNode.SelectSingleNode("//div[@id=\"productFactsDesktop_feature_div\"]");
				if (detailsThreeIn != null)
					return detailsThreeIn.InnerText.Trim();

				return detailsThree.InnerText.Trim();
			}

			var detailsFour = htmlDoc.DocumentNode.SelectSingleNode("//div[@id=\"detailBulletsWrapper_feature_div\"]");
			if (detailsFour != null)
				return detailsFour.InnerText.Trim();

			var detailsFive = htmlDoc.DocumentNode.SelectSingleNode("//div[@id=\"productDescription_feature_div\"]");
			if (detailsFive != null)
				return detailsFive.InnerText.Trim();

			return string.Empty;
		}

	}
}
