using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AmazonTrManagment.EntityFrameworkCore
{
    public static class AmazonTrManagmentDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AmazonTrManagmentDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AmazonTrManagmentDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
