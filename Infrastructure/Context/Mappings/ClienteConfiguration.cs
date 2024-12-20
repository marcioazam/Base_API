﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context.Tables;

namespace Infrastructure.Context.Mappings
{
    public class ClienteConfiguration : IEntityTypeConfiguration<ClienteTable>
    {
        public void Configure(EntityTypeBuilder<ClienteTable> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(nameof(ClienteTable.Id));

            builder.Property(x => x.Id).UseIdentityColumn()
                .HasColumnName("Id")
                .HasColumnType("bigint");

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(x => x.Gender)
                .HasColumnName("Gender")
                .HasColumnType("CHAR")
                .IsRequired(true);

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired(true);
        }
    }
}
