﻿using _4Tables2._0.Domain.ProductDomain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4Tables2._0.Infra.Data.EntitiesConfig
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                    .IsRequired();

            builder.Property(x => x.Price)
                    .IsRequired()
                    .HasPrecision(8, 4);

            builder.Property(x => x.TotalRequests)
                    .IsRequired();
        }
    }
}
