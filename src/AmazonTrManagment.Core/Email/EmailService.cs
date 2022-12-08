using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace AmazonTrManagment.Email
{
	public class EmailService : IEmailService
	{
		public async Task SendEmail(string body)
		{
			string username = "m.akvardar.424@gmail.com";
			string password = "nsecndxlsocyadbx";
			var credentials = new NetworkCredential(username, password);

			var smtpClient = new SmtpClient()
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				Credentials = credentials
			};

			var mail = new MailMessage
			{
				From = new MailAddress(username),
				Subject = $"",
				Body = body
			};
			mail.To.Add("");

			smtpClient.Send(mail);
		}


	}
}
