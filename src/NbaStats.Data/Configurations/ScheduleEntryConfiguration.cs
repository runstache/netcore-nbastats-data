using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NbaStats.Data.Constants;
using NbaStats.Data.DataObjects;

namespace NbaStats.Data.Configurations
{
    public class ScheduleEntryConfiguration : IEntityTypeConfiguration<ScheduleEntry>
    {
        public void Configure(EntityTypeBuilder<ScheduleEntry> builder)
        {
            builder.ToTable(TableConstants.ScheduleTable);
            builder.HasKey(c => c.Id);
            builder.Property(c => c.AwayTeamId).IsRequired().HasColumnName("AwayTeamId").HasColumnType("int");
            builder.Property(c => c.GameDate).IsRequired().HasColumnName("GameDate").HasColumnType("date");
            builder.Property(c => c.HomeTeamId).IsRequired().HasColumnName("HomeTeamId").HasColumnType("int");
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint").UseIdentityColumn();
        }
    }
}
