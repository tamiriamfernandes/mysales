using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySales.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySales.Infrastructure.Mapping;

public class SaleItemMapping : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable("SaleItems");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.SaleId)
            .IsRequired();

        builder.Property(e => e.ProductId)
            .IsRequired();

        builder.Property(e => e.Amount)
            .IsRequired();

        builder.Property(e => e.Price)
            .HasColumnType("decimal(15,2)")
            .IsRequired();

        builder.HasOne(e => e.Product)
            .WithMany(e => e.SaleItems)
            .HasForeignKey(e => e.ProductId);

        builder.HasOne(e => e.Sale)
            .WithMany(e => e.SaleItems)
            .HasForeignKey(e => e.SaleId);

    }
}
