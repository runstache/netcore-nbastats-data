using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NbaStats.Data.Context;
using NbaStats.Data.DataObjects;
using NbaStats.Data.Repositories;
using System.Linq;

namespace NbaStats.Data.Tests.Repositories
{
    [TestFixture]
    public class RepositoryRetrievalTests
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
        public void TestGetInjury()
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
                Id = 2,
                PlayerId = 3,
                ScratchDate = DateTime.Now
            };
            repo.Insert(injury2);

            Assert.IsNotNull(repo.GetInjury(2));
        }

        [Test]
        public void TestGetInjuries()
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
                Id = 2,
                PlayerId = 3,
                ScratchDate = DateTime.Now
            };
            repo.Insert(injury2);

            Assert.AreEqual(2, repo.GetInjuries().Count());
        }

        [Test]
        public void TestGetPlayer()
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
                Id = 2,
                PlayerCode = "JSmith",
                PlayerName = "Jeff Smith Jr"
            };
            repo.Insert(player2);

            Assert.IsNotNull(repo.GetPlayer(2));
        }

        [Test]
        public void TestGetPlayers()
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
                Id = 2,
                PlayerCode = "JSmith",
                PlayerName = "Jeff Smith Jr"
            };
            repo.Insert(player2);

            Assert.AreEqual(2, repo.GetPlayers().Count());
        }

        [Test]
        public void TestGetPlayerStat()
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
                Steals = 4,
                FTCompleted = 2,
                FTTaken = 1,
                FTPercentage = 0.5
            };

            repo.Insert(stat);
            PlayerStat stat2 = new PlayerStat()
            {
                Id = 2,
                PlayerId = 1,
                ScheduleId = 5,
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
                Steals = 4,
                FTCompleted = 2,
                FTTaken = 1,
                FTPercentage = 0.5
            };
            repo.Insert(stat2);

            Assert.IsNotNull(repo.GetPlayerStat(2));

        }

        [Test]
        public void TestGetPlayerStats()
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
                Steals = 4,
                FTCompleted = 2,
                FTTaken = 1,
                FTPercentage = 0.5
            };

            repo.Insert(stat);
            PlayerStat stat2 = new PlayerStat()
            {
                Id = 2,
                PlayerId = 1,
                ScheduleId = 5,
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
                Steals = 4,
                FTCompleted = 2,
                FTTaken = 1,
                FTPercentage = 0.5
            };
            repo.Insert(stat2);
            Assert.AreEqual(2, repo.GetPlayerStats().Count());
        }

        [Test]
        public void TestGetRosterEntry()
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
                Id = 2,
                PlayerId = 4,
                TeamId = 5
            };
            repo.Insert(entry2);

            Assert.IsNotNull(repo.GetRosterEntry(2));
        }

        [Test]
        public void TestGetRosterEntries()
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
                Id = 2,
                PlayerId = 4,
                TeamId = 5
            };
            repo.Insert(entry2);
            Assert.AreEqual(2, repo.GetRosterEntries().Count());
        }

        [Test]
        public void TestGetScheduleEntry()
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
                Id = 2,
                AwayTeamId = 5,
                GameDate = new DateTime(2020, 1, 12),
                HomeTeamId = 2
            };
            repo.Insert(entry2);

            Assert.IsNotNull(repo.GetScheduleEntry(2));
        }

        [Test]
        public void TestGetScheduleEntries()
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
                Id = 2,
                AwayTeamId = 5,
                GameDate = new DateTime(2020, 1, 12),
                HomeTeamId = 2
            };
            repo.Insert(entry2);
            Assert.AreEqual(2, repo.GetScheduleEntries().Count());
        }

        [Test]
        public void TestGetTeam()
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
                Id = 2,
                TeamCode = "LA",
                TeamName = "LA Raiders"
            };
            repo.Insert(team2);
            Assert.IsNotNull(repo.GetTeam(2));
        }

        [Test]
        public void TestGetTeams()
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
                Id = 2,
                TeamCode = "LA",
                TeamName = "LA Raiders"
            };
            repo.Insert(team2);
            Assert.AreEqual(2, repo.GetTeams().Count());
        }

        [Test]
        public void TestGetTeamStat()
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
                TurnOvers = 20,
                ScheduleId = 4
            };
            repo.Insert(stat);

            TeamStat stat2 = new TeamStat()
            {
                Id = 2,
                OpponentId = 5,
                TeamId = 4,
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
                TurnOvers = 20,
                ScheduleId = 2
            };
            repo.Insert(stat2);

            Assert.IsNotNull(repo.GetTeamStat(2));
        }

        [Test]
        public void TestGetTeamStats()
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
                TurnOvers = 20,
                ScheduleId = 4
            };
            repo.Insert(stat);

            TeamStat stat2 = new TeamStat()
            {
                Id = 2,
                OpponentId = 5,
                TeamId = 4,
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
                TurnOvers = 20,
                ScheduleId = 2
            };
            repo.Insert(stat2);
            Assert.AreEqual(2, repo.GetTeamStats().Count());
        }

        [Test]
        public void TestGetTransaction()
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
                Id = 2,
                NewTeamId = 9,
                OldTeamId = 4,
                PlayerId = 3
            };
            repo.Insert(transaction2);

            Assert.IsNotNull(repo.GetTransaction(2));
        }

        [Test]
        public void TestGetTransactions()
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
                Id = 2,
                NewTeamId = 9,
                OldTeamId = 4,
                PlayerId = 3
            };
            repo.Insert(transaction2);
            Assert.AreEqual(2, repo.GetTransactions().Count());
        }

        [Test]
        public void TestGetBoxScoreEntry()
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
            Assert.IsNotNull(repo.GetBoxScoreEntry(1));
        }

        [Test]
        public void TestGetBoxScoreEntries()
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
                Id = 2,
                Ot = 0,
                Quarter1 = 15,
                Quarter2 = 20,
                Quarter3 = 15,
                Quarter4 = 20,
                TeamId = 2,
                Total = 70,
                ScheduleId = 4
            };
            repo.Insert(entry2);
            Assert.AreEqual(2, repo.GetBoxScoreEntries().Count());

        }
    }
}
