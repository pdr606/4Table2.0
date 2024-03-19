using _4Tables2._0.Domain.OrderDomain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4Tables2._0.Infra.Data.EntitiesConfig
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Total)
                   .IsRequired()
                   .HasPrecision(8, 2);

            builder.HasMany(x => x.CustomerOrdes)
                    .WithOne(x => x.Order)
                    .HasForeignKey(x => x.OrderId)
                    .IsRequired();
        }
    }
}
