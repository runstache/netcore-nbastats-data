using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NbaStats.Data.Context;
using NbaStats.Data.Engines;
using NbaStats.Data.DataObjects;
using System.Linq;
using System.Linq.Expressions;

namespace NbaStats.Data.Tests.Engines
{
    [TestFixture]
    public class BoxScoreEntryTests
    {

        private IStatEngine<BoxScoreEntry> engine;
        private SqlContext ctx;
        private BoxScoreEntry entry;

        [SetUp]
        public void Setup()
        {
            ctx = new SqlContext();
            engine = new BoxScoreEngine(ctx);
            entry = new BoxScoreEntry()
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
        }

        [TearDown]
        public void Cleanup()
        {
            foreach (BoxScoreEntry entity in ctx.BoxScoreEntries)
            {
                ctx.BoxScoreEntries.Remove(entity);
            }
            ctx.SaveChanges();
        }

        [Test]
        public void TestSaveBoxScore()
        {
            engine.Save(entry);
            Assert.IsNotNull(ctx.BoxScoreEntries.Where(c => c.Id == 1).FirstOrDefault());
        }

        [Test]
        public void TestSaveBoxScoreUpdate()
        {
            engine.Save(entry);

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
            engine.Save(entry2);
            Assert.IsNotNull(ctx.BoxScoreEntries.Where(c => c.Id == 1 && c.Quarter2 == 25).FirstOrDefault());
        }

        [Test]
        public void TestSaveBoxScoreUpdateNoId()
        {
            engine.Save(entry);

            BoxScoreEntry entry2 = new BoxScoreEntry()
            {
                Id = 0,
                Ot = 0,
                Quarter1 = 15,
                Quarter2 = 25,
                Quarter3 = 15,
                Quarter4 = 20,
                TeamId = 2,
                Total = 70,
                ScheduleId = 3
            };
            engine.Save(entry2);
            Assert.IsNotNull(ctx.BoxScoreEntries.Where(c => c.Id == 1 && c.Quarter2 == 25).FirstOrDefault());
        }

        [Test]
        public void TestLoadItem()
        {
            engine.Save(entry);
            Assert.IsNotNull(engine.Load(1));
        }

        [Test]
        public void TestLoadAll()
        {
            engine.Save(entry);
            Assert.AreEqual(1, engine.LoadAll().Count());
        }

        [Test]
        public void TestQueryItems()
        {
            engine.Save(entry);
            Expression<Func<BoxScoreEntry, bool>> expression = c => c.Quarter1 == 15;
            Assert.AreEqual(1, engine.Query(expression).Count());

        }

        [Test]
        public void TestDeleteItem()
        {
            engine.Save(entry);
            Assert.AreEqual(1, ctx.BoxScoreEntries.Count());

            engine.Delete(entry);
            Assert.IsNull(engine.Load(1));

        }

        [Test]
        public void TestExists()
        {
            engine.Save(entry);

            BoxScoreEntry entry2 = new BoxScoreEntry()
            {
                Id = 1,
                Ot = 0,
                Quarter1 = 15,
                Quarter2 = 20,
                Quarter3 = 30,
                Quarter4 = 10,
                TeamId = 2,
                Total = 70,
                ScheduleId = 3
            };
            Assert.IsTrue(engine.Exists(entry2));
        }

    }
}
