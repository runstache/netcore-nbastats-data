using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NbaStats.Data.Constants;
using NbaStats.Data.DataObjects;

namespace NbaStats.Data.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable(TableConstants.TeamsTable);
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(c => c.TeamCode).IsRequired().HasColumnName("TeamCode").HasColumnType("varchar(25)").HasMaxLength(25);
            builder.Property(c => c.TeamName).IsRequired().HasColumnName("TeamName").HasColumnType("varchar(150)").HasMaxLength(150);
        }
    }
}
