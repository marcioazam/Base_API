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
    public class UserConfiguration : IEntityTypeConfiguration<UserTable>
    {
        public void Configure(EntityTypeBuilder<UserTable> builder)
        {
            builder.ToTable("User");

            builder.HasKey(nameof(UserTable.Id));

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
