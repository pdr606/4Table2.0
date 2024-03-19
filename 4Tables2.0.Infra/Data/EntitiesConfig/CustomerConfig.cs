using _4Tables2._0.Domain.CostumeOrder.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4Tables2._0.Infra.Data.EntitiesConfig
{
    public class CustomerConfig : IEntityTypeConfiguration<CustomerOrder>
    {
        public void Configure(EntityTypeBuilder<CustomerOrder> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity)
                    .IsRequired();

            builder.Property(x => x.Observation)
                    .IsRequired(false)
                    .HasMaxLength(150);

            builder.HasOne(x => x.Product)
                    .WithMany()
                    .IsRequired()
                    .HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
