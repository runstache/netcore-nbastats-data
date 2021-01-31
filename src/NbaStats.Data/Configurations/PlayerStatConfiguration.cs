using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NbaStats.Data.Constants;
using NbaStats.Data.DataObjects;

namespace NbaStats.Data.Configurations
{
    public class PlayerStatConfiguration : IEntityTypeConfiguration<PlayerStat>
    {
        public void Configure(EntityTypeBuilder<PlayerStat> builder)
        {
            builder.ToTable(TableConstants.PlayerStatsTable);
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Assists).IsRequired().HasColumnName("Assists").HasColumnType("int");
            builder.Property(c => c.Blocks).IsRequired().HasColumnName("Blocks").HasColumnType("int");
            builder.Property(c => c.DefensiveRebound).IsRequired().HasColumnName("DefensiveRebounds").HasColumnType("int");
            builder.Property(c => c.FGCompleted).IsRequired().HasColumnName("FGCompleted").HasColumnType("int");
            builder.Property(c => c.FGPercentage).IsRequired().HasColumnName("FGPercentage").HasColumnType("float");
            builder.Property(c => c.FGTaken).IsRequired().HasColumnName("FGTaken").HasColumnType("int");
            builder.Property(c => c.Fouls).IsRequired().HasColumnName("Fouls").HasColumnType("int");
            builder.Property(c => c.GameMinutes).IsRequired().HasColumnName("GameMinutes").HasColumnType("int");
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint").UseIdentityColumn();
            builder.Property(c => c.OffensiveRebound).IsRequired().HasColumnName("OffensiveRebound").HasColumnType("int");
            builder.Property(c => c.PlayerId).IsRequired().HasColumnName("PlayerId").HasColumnType("bigint");
            builder.Property(c => c.PointDifferential).IsRequired().HasColumnName("PointDifferential").HasColumnType("int");
            builder.Property(c => c.Points).IsRequired().HasColumnName("Points").HasColumnType("int");
            builder.Property(c => c.Steals).IsRequired().HasColumnName("Steals").HasColumnType("int");
            builder.Property(c => c.ThreeCompleted).IsRequired().HasColumnName("ThreeCompleted").HasColumnType("int");
            builder.Property(c => c.ThreeTaken).IsRequired().HasColumnName("ThreeTaken").HasColumnType("int");
            builder.Property(c => c.Turnovers).IsRequired().HasColumnName("Turnovers").HasColumnType("int");
            builder.Property(c => c.ThreePercentage).IsRequired().HasColumnName("ThreePercentage").HasColumnType("float");
            builder.Property(c => c.ScheduleId).IsRequired().HasColumnName("ScheduleId").HasColumnType("bigint");
            builder.Property(c => c.FTCompleted).IsRequired().HasColumnName("FTCompleted").HasColumnType("int");
            builder.Property(c => c.FTPercentage).IsRequired().HasColumnName("FTPercentage").HasColumnType("float");
            builder.Property(c => c.FTTaken).IsRequired().HasColumnName("FTTaken").HasColumnType("int");
        }
    }
}
