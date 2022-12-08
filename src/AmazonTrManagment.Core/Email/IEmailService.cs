using Abp.Dependency;
using System.Threading.Tasks;

namespace AmazonTrManagment.Email
{
	public interface IEmailService : ITransientDependency
	{
		Task SendEmail(string body);
	}
}
