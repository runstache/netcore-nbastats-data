using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NbaStats.Data.Constants;
using NbaStats.Data.DataObjects;

namespace NbaStats.Data.Configurations
{
    public class InjuryConfiguration : IEntityTypeConfiguration<Injury>
    {
        public void Configure(EntityTypeBuilder<Injury> builder)
        {
            builder.ToTable(TableConstants.InjuryTable);
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint").UseIdentityColumn();
            builder.Property(s => s.PlayerId).IsRequired().HasColumnName("PlayerId").HasColumnType("bigint");
            builder.Property(s => s.ScratchDate).IsRequired().HasColumnName("ScratchDate").HasColumnType("date");
            builder.Property(s => s.InjuryStatus).HasColumnName("InjuryStatus").HasColumnType("varchar(150)").HasMaxLength(150);
        }
    }
}
