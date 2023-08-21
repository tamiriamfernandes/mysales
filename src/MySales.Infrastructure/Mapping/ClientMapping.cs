using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMySales.Model.Entities;

namespace MySales.Infrastructure.Mapping;

public class ClientMapping : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
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
