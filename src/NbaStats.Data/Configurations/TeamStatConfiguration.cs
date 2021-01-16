using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NbaStats.Data.Constants;
using NbaStats.Data.DataObjects;

namespace NbaStats.Data.Configurations
{
    public class TeamStatConfiguration : IEntityTypeConfiguration<TeamStat>
    {
        public void Configure(EntityTypeBuilder<TeamStat> builder)
        {
            builder.ToTable(TableConstants.TeamStatsTable);
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Assits).IsRequired().HasColumnName("Assists").HasColumnType("int");
            builder.Property(c => c.Blocks).IsRequired().HasColumnName("Blocks").HasColumnType("int");
            builder.Property(c => c.DefensiveRebound).IsRequired().HasColumnName("DefensiveRebound").HasColumnType("int");
            builder.Property(c => c.FGCompleted).IsRequired().HasColumnName("FGCompleted").HasColumnType("int");
            builder.Property(c => c.FGPercentage).IsRequired().HasColumnName("FGPercentage").HasColumnType("float");
            builder.Property(c => c.FGTaken).IsRequired().HasColumnName("FGTaken").HasColumnType("int");
            builder.Property(c => c.Fouls).IsRequired().HasColumnName("Fouls").HasColumnType("int");
            builder.Property(c => c.FreeThrowPercentage).IsRequired().HasColumnName("FreeThrowPercentage").HasColumnType("float");
            builder.Property(c => c.FreeThrowsCompleted).IsRequired().HasColumnName("FreeThrowsCompleted").HasColumnType("int");
            builder.Property(c => c.FreeThrowsTaken).IsRequired().HasColumnName("FreeThrowsTaken").HasColumnType("int");
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint").UseIdentityColumn();
            builder.Property(c => c.OffensiveRebound).IsRequired().HasColumnName("OffensiveRebound").HasColumnType("int");
            builder.Property(c => c.OpponentId).IsRequired().HasColumnName("OpponentId").HasColumnType("int");
            builder.Property(c => c.Steals).IsRequired().HasColumnName("Steals").HasColumnType("int");
            builder.Property(c => c.TeamId).IsRequired().HasColumnName("TeamId").HasColumnType("int");
            builder.Property(c => c.ThreeCompleted).IsRequired().HasColumnName("ThreeCompleted").HasColumnType("int");
            builder.Property(c => c.ThreePercentage).IsRequired().HasColumnName("ThreePercentage").HasColumnType("float");
            builder.Property(c => c.ThreeTaken).IsRequired().HasColumnName("ThreeTaken").HasColumnType("int");
            builder.Property(c => c.TurnOvers).IsRequired().HasColumnName("Turnovers").HasColumnType("int");
        }
    }
}
