using System;
using System.Collections.Generic;
using System.Text;
using NbaStats.Data.Context;
using NbaStats.Data.DataObjects;
using NbaStats.Data.Engines;
using NUnit.Framework;
using System.Linq.Expressions;
using System.Linq;

namespace NbaStats.Data.Tests.Engines
{
    [TestFixture]
    public class ScheduleEntryEngineTests
    {
        private IStatEngine<ScheduleEntry> engine;
        private ScheduleEntry entry;
        private SqlContext ctx;

        [SetUp]
        public void Setup()
        {
            entry = new ScheduleEntry()
            {
                Id = 0,
                AwayTeamId = 3,
                HomeTeamId = 4,
                GameDate = new DateTime(2020, 1, 18)
            };

            ctx = new SqlContext();
            engine = new ScheduleEntryEngine(ctx);
        }

        [TearDown]
        public void Cleanup()
        {
            foreach(ScheduleEntry item in ctx.ScheduleEntries)
            {
                ctx.ScheduleEntries.Remove(item);
            }
            ctx.SaveChanges();
        }

        [Test]
        public void TestSave()
        {
            engine.Save(entry);
            Assert.AreEqual(1, ctx.ScheduleEntries.Count());
        }

        [Test]
        public void TestSaveUpdate()
        {
            entry.Id = 1;
            ctx.ScheduleEntries.Add(entry);
            ctx.SaveChanges();

            ScheduleEntry entry2 = new ScheduleEntry()
            {
                Id = 1,
                AwayTeamId = 3,
                HomeTeamId = 5,
                GameDate = new DateTime(2020, 1, 18)
            };
            engine.Save(entry2);
            Assert.AreEqual(1, ctx.ScheduleEntries.Count());
            Assert.IsNotNull(ctx.ScheduleEntries.Where(c => c.Id == 1 && c.HomeTeamId == 5).FirstOrDefault());
        }

        [Test]
        public void TestLoad()
        {
            entry.Id = 1;
            ctx.ScheduleEntries.Add(entry);
            ctx.SaveChanges();
            Assert.IsNotNull(engine.Load(1));
        }

        [Test]
        public void TestLoadAll()
        {
            entry.Id = 1;
            ctx.ScheduleEntries.Add(entry);
            ctx.SaveChanges();
            Assert.AreEqual(1, engine.LoadAll().Count());
        }

        [Test]
        public void TestExists()
        {
            entry.Id = 1;
            ctx.ScheduleEntries.Add(entry);
            ctx.SaveChanges();
            ScheduleEntry entry2 = new ScheduleEntry()
            {
                Id = 1,
                AwayTeamId = 3,
                HomeTeamId = 4,
                GameDate = new DateTime(2020, 1, 18)
            };
            Assert.IsTrue(engine.Exists(entry2));
        }

        [Test]
        public void TestDelete()
        {
            entry.Id = 1;
            ctx.ScheduleEntries.Add(entry);
            ctx.SaveChanges();
            engine.Delete(entry);

            Assert.IsNull(ctx.ScheduleEntries.Where(c => c.Id == 1).FirstOrDefault());
        }

        [Test]
        public void TestQuery()
        {
            entry.Id = 1;
            ctx.ScheduleEntries.Add(entry);
            ctx.SaveChanges();
            Expression<Func<ScheduleEntry, bool>> expression = c => c.AwayTeamId == 3 && c.GameDate > new DateTime(2020, 1, 17);
            Assert.AreEqual(1, engine.Query(expression).Count());
        }
    }
}
