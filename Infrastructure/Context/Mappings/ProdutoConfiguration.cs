using Infrastructure.Context.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Mappings
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<ProdutoTable>
    {
        public void Configure(EntityTypeBuilder<ProdutoTable> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(nameof(ProdutoTable.Id));

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
