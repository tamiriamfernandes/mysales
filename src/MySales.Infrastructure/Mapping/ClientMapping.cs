using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySales.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
