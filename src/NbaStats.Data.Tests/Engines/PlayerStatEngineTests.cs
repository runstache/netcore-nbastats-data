using System;
using System.Collections.Generic;
using System.Text;
using NbaStats.Data.Engines;
using NbaStats.Data.Context;
using NbaStats.Data.Repositories;
using NbaStats.Data.DataObjects;
using NUnit.Framework;
using System.Linq;
using System.Linq.Expressions;

namespace NbaStats.Data.Tests.Engines
{
    [TestFixture]
    public class PlayerStatEngineTests
    {
        private IStatEngine<PlayerStat> engine;
        private SqlContext ctx;
        private PlayerStat stat;

        [SetUp]
        public void Setup()
        {
            ctx = new SqlContext();
            engine = new PlayerStatEngine(ctx);

            stat = new PlayerStat()
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
                Steals = 4,
                FTCompleted = 2,
                FTTaken = 1,
                FTPercentage = 0.5
            };
        }

        [TearDown]
        public void Cleanup()
        {
            foreach(PlayerStat item in ctx.PlayerStats)
            {
                ctx.PlayerStats.Remove(item);
            }
            ctx.SaveChanges();
        }

        [Test]
        public void TestSave()
        {
            engine.Save(stat);

            Assert.AreEqual(1, ctx.PlayerStats.Count());
        }

        [Test]
        public void TestSaveUpdate()
        {
            engine.Save(stat);

            PlayerStat stat2 = new PlayerStat()
            {
                Id = 1,
                PlayerId = 1,
                ScheduleId = 4,
                Assists = 20,
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
            engine.Save(stat2);

            Assert.AreEqual(1, ctx.PlayerStats.Count());

            Assert.IsNotNull(ctx.PlayerStats.Where(c => c.Id == 1 && c.Assists == 20));
        }

        [Test]
        public void TestSaveUpdateNoId()
        {
            engine.Save(stat);

            PlayerStat stat2 = new PlayerStat()
            {
                Id = 0,
                PlayerId = 1,
                ScheduleId = 4,
                Assists = 20,
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
            engine.Save(stat2);

            Assert.AreEqual(1, ctx.PlayerStats.Count());

            Assert.IsNotNull(ctx.PlayerStats.Where(c => c.Id == 1 && c.Assists == 20));
        }

        [Test]
        public void TestLoad()
        {
            engine.Save(stat);
            Assert.AreEqual(1, ctx.PlayerStats.Count());
            Assert.IsNotNull(ctx.PlayerStats.Where(c => c.Id == 1).FirstOrDefault());
        }

        [Test]
        public void TestLoadAll()
        {
            engine.Save(stat);
            Assert.AreEqual(1, engine.LoadAll().Count());
        }

        [Test]
        public void TestQuery()
        {
            engine.Save(stat);
            Expression<Func<PlayerStat, bool>> expression = c => c.PlayerId == 1;
            Assert.AreEqual(1, engine.Query(expression).Count());
        }

        [Test]
        public void TestDelete()
        {
            engine.Save(stat);
            Assert.IsNotNull(ctx.PlayerStats.Where(c => c.Id == 1).FirstOrDefault());

            engine.Delete(stat);
            Assert.IsNull(ctx.PlayerStats.Where(c => c.Id == 1).FirstOrDefault());
        }
    }
}
