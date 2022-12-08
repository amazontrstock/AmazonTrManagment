using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AmazonTrManagment.Authorization.Roles;
using AmazonTrManagment.Authorization.Users;
using AmazonTrManagment.MultiTenancy;
using AmazonTrManagment.Products;

namespace AmazonTrManagment.EntityFrameworkCore
{
    public class AmazonTrManagmentDbContext : AbpZeroDbContext<Tenant, Role, User, AmazonTrManagmentDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AmazonTrManagmentDbContext(DbContextOptions<AmazonTrManagmentDbContext> options)
            : base(options)
        {
        }

		public virtual DbSet<Product> Products { get; set; }
	}
}
