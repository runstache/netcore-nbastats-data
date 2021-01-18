using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using NbaStats.Data.DataObjects;
using NbaStats.Data.Context;
using NUnit.Framework;
using NbaStats.Data.Engines;

namespace NbaStats.Data.Tests.Engines
{
    [TestFixture]
    public class TeamStatEngineTests
    {
        private SqlContext ctx;
        private IStatEngine<TeamStat> engine;
        private TeamStat stat;

        [SetUp]
        public void Setup()
        {
            ctx = new SqlContext();
            engine = new TeamStatEngine(ctx);
            stat = new TeamStat()
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
        }

        [TearDown]
        public void Cleanup()
        {
            foreach(TeamStat item in ctx.TeamStats)
            {
                ctx.TeamStats.Remove(item);
            }
            ctx.SaveChanges();
        }

        [Test]
        public void TestSave()
        {
            stat.Id = 0;
            engine.Save(stat);

            Assert.AreEqual(1, ctx.TeamStats.Count());
        }

        [Test]
        public void TestSaveUpdate()
        {
            ctx.TeamStats.Add(stat);
            ctx.SaveChanges();

            TeamStat stat2 = new TeamStat()
            {
                Id = 1,
                OpponentId = 3,
                TeamId = 2,
                ScheduleId = 4,
                Assits = 20,
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
            engine.Save(stat2);
            Assert.IsNotNull(ctx.TeamStats.Where(c => c.Id == 1 && c.Assits == 20).FirstOrDefault());
            Assert.AreEqual(1, ctx.TeamStats.Count());
        }

        [Test]
        public void TestSaveUpdateNoId()
        {
            ctx.TeamStats.Add(stat);
            ctx.SaveChanges();

            TeamStat stat2 = new TeamStat()
            {
                Id = 0,
                OpponentId = 3,
                TeamId = 2,
                ScheduleId = 4,
                Assits = 20,
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
            engine.Save(stat2);
            Assert.IsNotNull(ctx.TeamStats.Where(c => c.Id == 1 && c.Assits == 20).FirstOrDefault());
            Assert.AreEqual(1, ctx.TeamStats.Count());
        }

        [Test]
        public void TestLoad()
        {
            ctx.TeamStats.Add(stat);
            ctx.SaveChanges();

            Assert.IsNotNull(engine.Load(1));
        }

        [Test]
        public void TestLoadAll()
        {
            ctx.TeamStats.Add(stat);
            ctx.SaveChanges();

            Assert.AreEqual(1, engine.LoadAll().Count());
        }

        [Test]
        public void TestQuery()
        {
            ctx.TeamStats.Add(stat);
            ctx.SaveChanges();

            Expression<Func<TeamStat, bool>> expression = c => c.Assits == 3;
            Assert.AreEqual(1, engine.Query(expression).Count());
        }

        [Test]
        public void TestExists()
        {
            ctx.TeamStats.Add(stat);
            ctx.SaveChanges();

            TeamStat stat2 = new TeamStat()
            {
                Id = 0,
                OpponentId = 3,
                TeamId = 2,
                ScheduleId = 4,
                Assits = 20,
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

            Assert.IsTrue(engine.Exists(stat2));
        }

        [Test]
        public void TestDelete()
        {
            ctx.TeamStats.Add(stat);
            ctx.SaveChanges();
            engine.Delete(stat);

            Assert.IsNull(ctx.TeamStats.Where(c => c.Id == 1).FirstOrDefault());
        }
        
    }
}
