using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NbaStats.Data.Constants;
using NbaStats.Data.DataObjects;

namespace NbaStats.Data.Configurations
{
    public class RosterEntryConfiguration : IEntityTypeConfiguration<RosterEntry>
    {
        public void Configure(EntityTypeBuilder<RosterEntry> builder)
        {
            builder.ToTable(TableConstants.RosterTable);
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint").UseIdentityColumn();
            builder.Property(c => c.PlayerId).IsRequired().HasColumnName("PlayerId").HasColumnType("bigint");
            builder.Property(c => c.TeamId).IsRequired().HasColumnName("TeamId").HasColumnType("int");
        }
    }
}
