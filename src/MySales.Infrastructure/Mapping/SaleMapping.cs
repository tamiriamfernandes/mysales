using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySales.Model.Entities;

namespace MySales.Infrastructure.Mapping;

public class SaleMapping : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Payment)
            .IsRequired();

        builder.Property(e => e.Installments)
            .IsRequired();

        builder.Property(e => e.DatePay)
            .IsRequired();

        builder.Property(e => e.CreatedDate)
            .HasColumnType("timestamp")
            .IsRequired();

        builder.Property(e => e.Total)
            .HasColumnType("decimal(15,2)")
            .IsRequired();

        builder.Property(e => e.Observation)
            .HasColumnType("varchar(250)")
            .HasMaxLength(250);

        builder.HasOne(e => e.Customer)
            .WithMany(e => e.Sales)
            .HasForeignKey(e => e.CustomerId);
    }
}
