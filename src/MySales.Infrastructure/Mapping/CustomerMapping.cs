using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySales.Model.Entities;

namespace MySales.Infrastructure.Mapping;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .HasColumnType("varchar(250)")
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(e => e.Phone)
            .HasColumnType("varchar(11)");

        builder.Property(e => e.CreatedDate)
            .HasColumnType("timestamp")
            .IsRequired();
    }
}
