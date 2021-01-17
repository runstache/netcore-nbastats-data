using NbaStats.Data.Context;
using NbaStats.Data.DataObjects;
using NbaStats.Data.Repositories;
using NUnit.Framework;
using System;
using System.Linq;

namespace NbaStats.Data.Tests.Repositories
{
    [TestFixture]
    public class RepositoryInsertTests
    {

        private IRepository repo;
        private SqlContext ctx;

        [SetUp]
        public void Setup()
        {
            ctx = new SqlContext();
            repo = new SqlRepository(ctx);
        }

        [TearDown]
        public void Cleanup()
        {

            foreach (Injury entity in ctx.Injuries)
            {
                ctx.Injuries.Remove(entity);
                
            }

            foreach(Player entity in ctx.Players)
            {
                ctx.Players.Remove(entity);
            }

            foreach(PlayerStat entity in ctx.PlayerStats)
            {
                ctx.PlayerStats.Remove(entity);
            }

            foreach(RosterEntry entity in ctx.RosterEntries)
            {
                ctx.RosterEntries.Remove(entity);
            }

            foreach(ScheduleEntry entity in ctx.ScheduleEntries)
            {
                ctx.ScheduleEntries.Remove(entity);
            }

            foreach(Team entity in ctx.Teams)
            {
                ctx.Teams.Remove(entity);
            }

            foreach(TeamStat entity in ctx.TeamStats)
            {
                ctx.TeamStats.Remove(entity);
            }

            foreach(Transaction entity in ctx.Transactions)
            {
                ctx.Transactions.Remove(entity);
            }

            ctx.SaveChanges();

        }

        [Test]
        public void TestInsertInjury()
        {
            Injury injury = new Injury()
            {
                Id = 1,
                PlayerId = 1,
                ScratchDate = DateTime.Now
            };

            repo.Insert(injury);

            Assert.IsTrue(ctx.Injuries.Any(c => c.Id == 1));
        }

        [Test]
        public void TestInsertPlayer()
        {
            Player player = new Player()
            {
                Id = 1,
                PlayerCode = "MAllison",
                PlayerName = "Marc Allison"
            };
            repo.Insert(player);
            Assert.IsTrue(ctx.Players.Any(c => c.Id == 1));
        }

        [Test]
        public void TestInsertPlayerStat()
        {
            PlayerStat stat = new PlayerStat()
            {
                Id = 1,
                PlayerId = 1,
                ScheduleId = 4,
                Assists = 5,
                PointDifferential = -12,
                Points = 25,
                FGPercentage = 0.25,
                ThreePercentage = 0.15,
                ThreeCompleted = 3,
                ThreeTaken = 15,
                Turnovers = 3,
                FGTaken = 20,
                FGCompleted = 5,
                Fouls = 2,
                Blocks = 5,
                DefensiveRebound = 3,
                OffensiveRebound = 3,
                GameMinutes = 18,
                Steals = 4
            };
            repo.Insert(stat);
            Assert.IsTrue(ctx.PlayerStats.Any(c => c.Id == 1));
        }

        [Test]
        public void TestInsertRosterEntry()
        {
            RosterEntry entry = new RosterEntry()
            {
                Id = 1,
                PlayerId = 3,
                TeamId = 4
            };
            repo.Insert(entry);
            Assert.IsTrue(ctx.RosterEntries.Any(c => c.Id == 1));
        }

        [Test]
        public void TestInsertScheduleEntry()
        {
            ScheduleEntry entry = new ScheduleEntry()
            {
                Id = 1,
                AwayTeamId = 3,
                GameDate = DateTime.Now,
                HomeTeamId = 2
            };
            repo.Insert(entry);
            Assert.IsTrue(ctx.ScheduleEntries.Any(c => c.Id == 1));
        }

        [Test]
        public void TestInsertTeam()
        {
            Team team = new Team()
            {
                Id = 1,
                TeamCode = "MIN",
                TeamName = "Minnesota Wild"
            };
            repo.Insert(team);
            Assert.IsTrue(ctx.Teams.Any(c => c.Id == 1));
        }

        [Test]
        public void TestInsertTeamStat()
        {
            TeamStat stat = new TeamStat()
            {
                Id = 1,
                OpponentId = 3,
                TeamId = 2,
                ScheduleId = 4,
                Assits = 3,
                Blocks = 6,
                DefensiveRebound = 15,
                FGCompleted = 35,
                FGPercentage = 0.6,
                FGTaken = 50,
                Fouls = 15,
                FreeThrowPercentage = 0.33,
                FreeThrowsCompleted = 9,
                FreeThrowsTaken = 3,
                OffensiveRebound = 25,
                Steals = 15,
                ThreeCompleted = 30,
                ThreePercentage = 0.33,
                ThreeTaken = 10,
                TurnOvers = 20
            };
            repo.Insert(stat);
            Assert.IsTrue(ctx.TeamStats.Any(c => c.Id == 1));
        }

        [Test]
        public void TestInsertTransaction()
        {
            Transaction transaction = new Transaction()
            {
                Id = 1,
                NewTeamId = 4,
                OldTeamId = 6,
                PlayerId = 3
            };
            repo.Insert(transaction);
            Assert.IsTrue(ctx.Transactions.Any(c => c.Id == 1));
        }     
    }
}
