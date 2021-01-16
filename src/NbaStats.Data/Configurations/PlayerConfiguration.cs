using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NbaStats.Data.Constants;
using NbaStats.Data.DataObjects;

namespace NbaStats.Data.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable(TableConstants.PlayersTable);
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint").UseIdentityColumn();
            builder.Property(s => s.PlayerCode).IsRequired().HasColumnName("PlayerCode").HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(s => s.PlayerName).IsRequired().HasColumnName("PlayerName").HasColumnType("varchar(500)").HasMaxLength(500);
        }
    }
}
