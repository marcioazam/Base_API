using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
