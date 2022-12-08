using System.IO.Compression;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace AmazonTrManagment.Scraper
{
	public static class HttpHelper
	{
		public static async Task<string> GetHtmlByLink(string link)
		{
			var userAgents = new UserAgents();
			string userAgent = userAgents.GetRandomUserAgent();

			var request = (HttpWebRequest)WebRequest.Create(link);
			request.Referer = "https://www.google.com";
			if (!string.IsNullOrEmpty(userAgent))
				request.UserAgent = userAgent;

			request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");

			request.Proxy = null;

			using HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync());

			WebHeaderCollection header = response.Headers;
			string strResponse = "";
			var contentEncoding = response.Headers["content-encoding"];
			if (contentEncoding != null && contentEncoding.Contains("gzip")) // cause httphandler only request gzip
			{
				using var responseStreamReader = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress));
				strResponse = responseStreamReader.ReadToEnd().Trim();
			}
			else
			{
				using var responseStreamReader = new StreamReader(response.GetResponseStream());
				strResponse = responseStreamReader.ReadToEnd().Trim();
			}

			return strResponse;
		}
	}
}
