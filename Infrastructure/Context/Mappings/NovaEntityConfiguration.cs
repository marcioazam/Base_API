using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context.Tables;

namespace Infrastructure.Context.Mappings
{
    public class NovaEntityConfiguration : IEntityTypeConfiguration<NovaEntityTable>
    {
        public void Configure(EntityTypeBuilder<NovaEntityTable> builder)
        {
            builder.ToTable("NovaEntity");

            builder.HasKey(nameof(NovaEntityTable.Id));

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}