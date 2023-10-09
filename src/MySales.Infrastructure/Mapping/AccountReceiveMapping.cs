using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySales.Model.Entities;

namespace MySales.Infrastructure.Mapping;

public class AccountReceiveMapping : IEntityTypeConfiguration<AccountReceive>
{
    public void Configure(EntityTypeBuilder<AccountReceive> builder)
    {
        builder.ToTable("AccountsReceive");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.SaleId)
            .IsRequired();

        builder.Property(e => e.CustomerId)
            .IsRequired();

        builder.Property(e => e.NumberParcel)
            .IsRequired();

        builder.Property(e => e.DatePay)
            .HasColumnType("timestamp")
            .IsRequired();

        builder.Property(e => e.Total)
            .HasColumnType("decimal(15,2)")
            .IsRequired();

        builder.Property(e => e.DatePaid)
            .HasColumnType("timestamp")
            .IsRequired();

        builder.HasOne(e => e.Sale)
            .WithMany(e => e.AccountReceives)
            .HasForeignKey(e => e.SaleId);

        builder.HasOne(e => e.Customer)
            .WithMany(e => e.AccountReceives)
            .HasForeignKey(e => e.CustomerId);
    }
}
