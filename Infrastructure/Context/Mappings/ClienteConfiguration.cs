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
    public class ClienteConfiguration : IEntityTypeConfiguration<ClienteTable>
    {
        public void Configure(EntityTypeBuilder<ClienteTable> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(nameof(ClienteTable.Id));

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
