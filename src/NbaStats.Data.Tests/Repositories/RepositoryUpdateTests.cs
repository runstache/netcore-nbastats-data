using NbaStats.Data.Context;
using NbaStats.Data.DataObjects;
using NbaStats.Data.Repositories;
using NUnit.Framework;
using System;
using System.Linq;

namespace NbaStats.Data.Tests.Repositories
{
    public class RepositoryUpdateTests
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

            foreach (Player entity in ctx.Players)
            {
                ctx.Players.Remove(entity);
            }

            foreach (PlayerStat entity in ctx.PlayerStats)
            {
                ctx.PlayerStats.Remove(entity);
            }

            foreach (RosterEntry entity in ctx.RosterEntries)
            {
                ctx.RosterEntries.Remove(entity);
            }

            foreach (ScheduleEntry entity in ctx.ScheduleEntries)
            {
                ctx.ScheduleEntries.Remove(entity);
            }

            foreach (Team entity in ctx.Teams)
            {
                ctx.Teams.Remove(entity);
            }

            foreach (TeamStat entity in ctx.TeamStats)
            {
                ctx.TeamStats.Remove(entity);
            }

            foreach (Transaction entity in ctx.Transactions)
            {
                ctx.Transactions.Remove(entity);
            }

            foreach(BoxScoreEntry entity in ctx.BoxScoreEntries)
            {
                ctx.BoxScoreEntries.Remove(entity);
            }

            ctx.SaveChanges();

        }

        [Test]
        public void TestUpdateInjury()
        {
            Injury injury = new Injury()
            {
                Id = 1,
                PlayerId = 1,
                ScratchDate = DateTime.Now
            };
            repo.Insert(injury);

            Injury injury2 = new Injury()
            {
                Id = 1,
                PlayerId = 3,
                ScratchDate = DateTime.Now
            };
            repo.Update(injury2);

            Assert.IsTrue(ctx.Injuries.Any(c => c.Id == 1 && c.PlayerId == 3));
            Assert.AreEqual(1, ctx.Injuries.Count());
        }

        [Test]
        public void TestUpdatePlayer()
        {
            Player player = new Player()
            {
                Id = 1,
                PlayerCode = "MAllison",
                PlayerName = "Marc Allison"
            };
            repo.Insert(player);

            Player player2 = new Player()
            {
                Id = 1,
                PlayerCode = "MAllisonJr",
                PlayerName = "Marc Allison Jr"
            };
            repo.Update(player2);

            Assert.IsTrue(ctx.Players.Any(c => c.Id == 1 && c.PlayerCode == player2.PlayerCode && c.PlayerName == player2.PlayerName));
            Assert.AreEqual(1, ctx.Players.Count());            
        }

        [Test]
        public void TestUpdatePlayerStat()
        {
            PlayerStat stat = new PlayerStat()
            {
                Id = 1,
                PlayerId = 1,
                ScheduleId = 3,
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
            PlayerStat stat2 = new PlayerStat()
            {
                Id = 1,
                PlayerId = 1,
                ScheduleId = 3,
                Assists = 5,
                PointDifferential = -12,
                Points = 25,
                FGPercentage = 0.25,
                ThreePercentage = 0.15,
                ThreeCompleted = 3,
                ThreeTaken = 15,
                Turnovers = 3,
                FGTaken = 50,
                FGCompleted = 5,
                Fouls = 2,
                Blocks = 5,
                DefensiveRebound = 3,
                OffensiveRebound = 3,
                GameMinutes = 18,
                Steals = 4
            };
            repo.Update(stat2);

            Assert.IsTrue(ctx.PlayerStats.Any(c => c.Id == 1 && c.FGTaken == 50));
            Assert.AreEqual(1, ctx.PlayerStats.Count());
        }

        [Test]
        public void TestUpdateRosterEntry()
        {
            RosterEntry entry = new RosterEntry()
            {
                Id = 1,
                PlayerId = 3,
                TeamId = 4
            };
            repo.Insert(entry);

            RosterEntry entry2 = new RosterEntry()
            {
                Id = 1,
                PlayerId = 3,
                TeamId = 5
            };
            repo.Update(entry2);

            Assert.IsTrue(ctx.RosterEntries.Any(c => c.Id == 1 && c.TeamId == 5));
            Assert.AreEqual(1, ctx.RosterEntries.Count());
        }

        [Test]
        public void TestUpdateScheduleEntry()
        {
            ScheduleEntry entry = new ScheduleEntry()
            {
                Id = 1,
                AwayTeamId = 3,
                GameDate = DateTime.Now,
                HomeTeamId = 2
            };
            repo.Insert(entry);

            ScheduleEntry entry2 = new ScheduleEntry()
            {
                Id = 1,
                AwayTeamId = 5,
                GameDate = entry.GameDate,
                HomeTeamId = 2
            };
            repo.Update(entry2);

            Assert.IsTrue(ctx.ScheduleEntries.Any(c => c.Id == 1 && c.AwayTeamId == 5));
            Assert.AreEqual(1, ctx.ScheduleEntries.Count());
        }

        [Test]
        public void TestUpdateTeam()
        {
            Team team = new Team()
            {
                Id = 1,
                TeamCode = "MIN",
                TeamName = "Minnesota Wild"
            };
            repo.Insert(team);

            Team team2 = new Team()
            {
                Id = 1,
                TeamCode = "MIN",
                TeamName = "Minnesota Northstars"
            };
            repo.Update(team2);

            Assert.IsTrue(ctx.Teams.Any(c => c.Id == 1 && c.TeamName == "Minnesota Northstars"));
            Assert.AreEqual(1, ctx.Teams.Count());
        }

        [Test]
        public void TestUpdateTeamStat()
        {
            TeamStat stat = new TeamStat()
            {
                Id = 1,
                OpponentId = 3,
                TeamId = 2,
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

            TeamStat stat2 = new TeamStat()
            {
                Id = 1,
                OpponentId = 3,
                TeamId = 2,
                Assits = 3,
                Blocks = 6,
                DefensiveRebound = 15,
                FGCompleted = 35,
                FGPercentage = 0.6,
                FGTaken = 50,
                Fouls = 15,
                FreeThrowPercentage = 0.33,
                FreeThrowsCompleted = 11,
                FreeThrowsTaken = 6,
                OffensiveRebound = 25,
                Steals = 15,
                ThreeCompleted = 30,
                ThreePercentage = 0.33,
                ThreeTaken = 10,
                TurnOvers = 20
            };

            repo.Update(stat2);

            Assert.IsTrue(ctx.TeamStats.Any(c => c.Id == 1 && c.FreeThrowsCompleted == 11));
            Assert.AreEqual(1, ctx.TeamStats.Count());
        }

        [Test]
        public void TestUpdateTransaction()
        {
            Transaction transaction = new Transaction()
            {
                Id = 1,
                NewTeamId = 4,
                OldTeamId = 6,
                PlayerId = 3
            };
            repo.Insert(transaction);

            Transaction transaction2 = new Transaction()
            {
                Id = 1,
                NewTeamId = 4,
                OldTeamId = 6,
                PlayerId = 7
            };
            repo.Update(transaction2);

            Assert.IsTrue(ctx.Transactions.Any(c => c.Id == 1 && c.PlayerId == 7));
            Assert.AreEqual(1, ctx.Transactions.Count());
        }

        [Test]
        public void TestUpdateBoxScoreEntry()
        {
            BoxScoreEntry entry = new BoxScoreEntry()
            {
                Id = 1,
                Ot = 0,
                Quarter1 = 15,
                Quarter2 = 20,
                Quarter3 = 15,
                Quarter4 = 20,
                TeamId = 2,
                Total = 70,
                ScheduleId = 3
            };
            repo.Insert(entry);

            BoxScoreEntry entry2 = new BoxScoreEntry()
            {
                Id = 1,
                Ot = 0,
                Quarter1 = 15,
                Quarter2 = 25,
                Quarter3 = 15,
                Quarter4 = 20,
                TeamId = 2,
                Total = 70,
                ScheduleId = 3
            };
            repo.Update(entry2);
            Assert.IsNotNull(ctx.BoxScoreEntries.Where(c => c.Id == 1 && c.Quarter2 == 25).FirstOrDefault());
            Assert.AreEqual(1, ctx.BoxScoreEntries.Count());
        }
    }
}
