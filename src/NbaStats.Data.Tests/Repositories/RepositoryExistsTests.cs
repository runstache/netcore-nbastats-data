using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NbaStats.Data.Context;
using NbaStats.Data.DataObjects;
using NbaStats.Data.Repositories;

namespace NbaStats.Data.Tests.Repositories
{
    [TestFixture]
    public class RepositoryExistsTests
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

            ctx.SaveChanges();
        }

        [Test]
        public void TestInjuryExits()
        {
            Injury injury = new Injury()
            {
                Id = 1,
                PlayerId = 1,
                ScratchDate = new DateTime(2020, 1, 17)
            };
            repo.Insert(injury);

            Assert.IsTrue(repo.Exists(injury));
        }

        [Test]
        public void TestInjuryNotExists()
        {
            Injury injury = new Injury()
            {
                Id = 1,
                PlayerId = 1,
                ScratchDate = new DateTime(2020, 1, 17)
            };
            repo.Insert(injury);

            Injury injury2 = new Injury()
            {
                Id = 1,
                PlayerId = 3,
                ScratchDate = new DateTime(2020, 1, 17)
            };

            Assert.IsFalse(repo.Exists(injury2));
        }

        [Test]
        public void TestPlayerExists()
        {
            Player player = new Player()
            {
                Id = 1,
                PlayerCode = "MAllison",
                PlayerName = "Marc Allison"
            };
            repo.Insert(player);
            Assert.IsTrue(repo.Exists(player));

        }

        [Test]
        public void TestPlayerNotExists()
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
            Assert.IsFalse(repo.Exists(player2));
        }

        [Test]
        public void TestPlayerStatExists()
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

            Assert.IsTrue(repo.Exists(stat));
        }

        [Test]
        public void TestPlayerStatNotExists()
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

            PlayerStat stat2 = new PlayerStat()
            {
                Id = 1,
                PlayerId = 1,
                ScheduleId = 2,
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

            Assert.IsFalse(repo.Exists(stat2));
        }

        [Test]
        public void TestRosterEntyExists()
        {
            RosterEntry entry = new RosterEntry()
            {
                Id = 1,
                PlayerId = 3,
                TeamId = 4
            };
            repo.Insert(entry);

            Assert.IsTrue(repo.Exists(entry));
        }

        [Test]
        public void TestRosterEntryNotExists()
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
            Assert.IsFalse(repo.Exists(entry2));
        }

        [Test]
        public void TestScheduleEntryExists()
        {
            ScheduleEntry entry = new ScheduleEntry()
            {
                Id = 1,
                AwayTeamId = 3,
                GameDate = DateTime.Now,
                HomeTeamId = 2
            };
            repo.Insert(entry);

            Assert.IsTrue(repo.Exists(entry));
        }

        [Test]
        public void TestScheduleEntryNotExists()
        {
            ScheduleEntry entry = new ScheduleEntry()
            {
                Id = 1,
                AwayTeamId = 3,
                GameDate = new DateTime(2020, 1, 17),
                HomeTeamId = 2
            };
            repo.Insert(entry);

            ScheduleEntry entry2 = new ScheduleEntry()
            {
                Id = 1,
                AwayTeamId = 3,
                GameDate = new DateTime(2020, 1, 18),
                HomeTeamId = 2
            };

            Assert.IsFalse(repo.Exists(entry2));
        }

        [Test]
        public void TestTeamExists()
        {
            Team team = new Team()
            {
                Id = 1,
                TeamCode = "MIN",
                TeamName = "Minnesota Wild"
            };
            repo.Insert(team);
            Assert.IsTrue(repo.Exists(team));

        }

        [Test]
        public void TestTeamNoExists()
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
                TeamCode = "WIN",
                TeamName = "Minnesota Wild"
            };
            Assert.IsFalse(repo.Exists(team2));
        }

        [Test]
        public void TestTeamStatExists() 
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

            Assert.IsTrue(repo.Exists(stat));
        }

        [Test]
        public void TestTeamStatNotExists()
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

            TeamStat stat2 = new TeamStat()
            {
                Id = 1,
                OpponentId = 3,
                TeamId = 2,
                ScheduleId = 3,
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

            Assert.IsFalse(repo.Exists(stat2));
        }

        [Test]
        public void TestTransactionExists()
        {
            Transaction transaction = new Transaction()
            {
                Id = 1,
                NewTeamId = 4,
                OldTeamId = 6,
                PlayerId = 3
            };
            repo.Insert(transaction);
            Assert.IsTrue(repo.Exists(transaction));
        }

        [Test]
        public void TestTransactionNotExists()
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
                OldTeamId = 7,
                PlayerId = 3
            };

            Assert.IsFalse(repo.Exists(transaction2));
        }

    }
}
