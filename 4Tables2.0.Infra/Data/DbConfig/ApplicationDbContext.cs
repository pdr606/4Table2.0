
using _4Tables2._0.Domain.CostumeOrder.Entity;
using _4Tables2._0.Domain.OrderDomain.Entity;
using _4Tables2._0.Domain.ProductDomain.Entity;
using _4Tables2._0.Infra.Data.EntitiesConfig;
using Microsoft.EntityFrameworkCore;

namespace _4Tables2._0.Infra.Data.DbConfig
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
        }

        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<CustomerOrder> CustomerOrders { get; set; }

    }
}
