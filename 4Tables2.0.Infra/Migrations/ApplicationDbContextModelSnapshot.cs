﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using _4Tables2._0.Infra.Data.DbConfig;

#nullable disable

namespace _4Tables2._0.Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("_4Tables2._0.Domain.CostumeOrder.Entity.CustomerOrder", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Observation")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProductId1")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductId1")
                        .IsUnique();

                    b.ToTable("CustomerOrders");
                });

            modelBuilder.Entity("_4Tables2._0.Domain.OrderDomain.Entity.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Total")
                        .HasPrecision(8, 2)
                        .HasColumnType("numeric(8,2)");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("_4Tables2._0.Domain.ProductDomain.Entity.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<int?>("Code")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasPrecision(8, 4)
                        .HasColumnType("numeric(8,4)");

                    b.Property<int>("TotalRequests")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("_4Tables2._0.Domain.CostumeOrder.Entity.CustomerOrder", b =>
                {
                    b.HasOne("_4Tables2._0.Domain.OrderDomain.Entity.Order", "Order")
                        .WithMany("CustomerOrdes")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_4Tables2._0.Domain.ProductDomain.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("_4Tables2._0.Domain.ProductDomain.Entity.Product", null)
                        .WithOne("CostumerOrder")
                        .HasForeignKey("_4Tables2._0.Domain.CostumeOrder.Entity.CustomerOrder", "ProductId1");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("_4Tables2._0.Domain.OrderDomain.Entity.Order", b =>
                {
                    b.Navigation("CustomerOrdes");
                });

            modelBuilder.Entity("_4Tables2._0.Domain.ProductDomain.Entity.Product", b =>
                {
                    b.Navigation("CostumerOrder")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
