using System;
using System.Collections.Generic;
using System.Text;
using NbaStats.Data.DataObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NbaStats.Data.Constants;

namespace NbaStats.Data.Configurations
{
    public class BoxScoreEntryConfiguration : IEntityTypeConfiguration<BoxScoreEntry>
    {
        public void Configure(EntityTypeBuilder<BoxScoreEntry> builder)
        {
            builder.ToTable(TableConstants.BoxScroteTable);
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint").UseIdentityColumn();
            builder.Property(c => c.Ot).IsRequired().HasColumnName("OT").HasColumnType("int");
            builder.Property(c => c.Quarter1).IsRequired().HasColumnName("Quarter1").HasColumnType("int");
            builder.Property(c => c.Quarter2).IsRequired().HasColumnName("Quarter2").HasColumnType("int");
            builder.Property(c => c.Quarter3).IsRequired().HasColumnName("Quarter3").HasColumnType("int");
            builder.Property(c => c.Quarter4).IsRequired().HasColumnName("Quarter4").HasColumnType("int");
            builder.Property(c => c.ScheduleId).IsRequired().HasColumnName("ScheduleId").HasColumnType("bigint");
            builder.Property(c => c.TeamId).IsRequired().HasColumnName("TeamId").HasColumnType("int");
            builder.Property(c => c.Total).IsRequired().HasColumnName("Total").HasColumnType("int");
        }
    }
}
