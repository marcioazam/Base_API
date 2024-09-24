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
    public class TokenConfiguration : IEntityTypeConfiguration<TokenTable>
    {
        public void Configure(EntityTypeBuilder<TokenTable> builder)
        {
            builder.ToTable("Token");

            builder.HasKey(nameof(TokenTable.Id));

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
