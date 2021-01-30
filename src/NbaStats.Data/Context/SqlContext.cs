using Microsoft.EntityFrameworkCore;
using NbaStats.Data.Configurations;
using NbaStats.Data.DataObjects;

namespace NbaStats.Data.Context
{
    public class SqlContext : DbContext
    {
        private readonly string connectionString;
        private readonly bool useInMemory = false;
        public SqlContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlContext()
        {
            useInMemory = true;
        }

        public DbSet<Injury> Injuries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStat> PlayerStats { get; set; }
        public DbSet<RosterEntry> RosterEntries { get; set; }
        public DbSet<ScheduleEntry> ScheduleEntries { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamStat> TeamStats { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<BoxScoreEntry> BoxScoreEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (useInMemory)
                {
                    optionsBuilder.UseInMemoryDatabase("Test");
                }
                else
                {
                    optionsBuilder.UseSqlServer(connectionString);
                }
            }            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new InjuryConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerStatConfiguration());
            modelBuilder.ApplyConfiguration(new RosterEntryConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleEntryConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new TeamStatConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new BoxScoreEntryConfiguration());
        }
    }
}
