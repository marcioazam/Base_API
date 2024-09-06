using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Context.Tables;

namespace Infrastructure.Context.Mappings
{
    public class SupplierConfiguration : IEntityTypeConfiguration<SupplierTable>
    {
        public void Configure(EntityTypeBuilder<SupplierTable> builder)
        {
            builder.ToTable("Supplier");

            builder.HasKey(nameof(SupplierTable.Id));

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
