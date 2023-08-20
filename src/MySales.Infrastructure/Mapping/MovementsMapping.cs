using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySales.Core.Entities;

namespace MySales.Infrastructure.Mapping;

public class MovementsMapping : IEntityTypeConfiguration<Movements>
{
    public void Configure(EntityTypeBuilder<Movements> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.ProductId)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(e => e.Type)
            .IsRequired();

        builder.Property(e => e.Amount)
            .IsRequired();

        builder.Property(e => e.CreatedDate)
            .HasColumnType("timestamp")
            .IsRequired();


        builder.HasOne(e => e.Product)
            .WithMany(e => e.Movements)
            .HasForeignKey(e => e.ProductId);
    }
}
