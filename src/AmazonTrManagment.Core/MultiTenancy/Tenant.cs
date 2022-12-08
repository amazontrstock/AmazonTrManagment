using Abp.MultiTenancy;
using AmazonTrManagment.Authorization.Users;

namespace AmazonTrManagment.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
