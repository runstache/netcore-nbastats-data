using System;
using System.Collections.Generic;
using System.Text;
using NbaStats.Data.Context;
using NbaStats.Data.DataObjects;
using NbaStats.Data.Engines;
using NUnit.Framework;
using System.Linq;
using System.Linq.Expressions;

namespace NbaStats.Data.Tests.Engines
{
    [TestFixture]
    public class RosterEntryEngineTests
    {
        private SqlContext ctx;
        private RosterEntryEngine engine;
        private RosterEntry entry;

        [SetUp]
        public void Setup()
        {
            entry = new RosterEntry()
            {
                Id = 1,
                PlayerId = 3,
                TeamId = 4
            };
            ctx = new SqlContext();
            engine = new RosterEntryEngine(ctx);

        }

        [TearDown]
        public void Cleanup()
        {
            foreach(RosterEntry item in ctx.RosterEntries)
            {
                ctx.RosterEntries.Remove(item);
            }

            foreach(Transaction item in ctx.Transactions)
            {
                ctx.Transactions.Remove(item);
            }
            ctx.SaveChanges();
        }

        [Test]
        public void TestSave()
        {
            engine.Save(entry);            
            Assert.AreEqual(1, ctx.RosterEntries.Count());
            Assert.IsNotNull(ctx.RosterEntries.Where(c => c.Id == 1).FirstOrDefault());
        }

        [Test]
        public void TestSaveUpdate()
        {
            engine.Save(entry);
            RosterEntry entry2 = new RosterEntry()
            {
                Id = 1,
                PlayerId = 3,
                TeamId = 5
            };
            engine.Save(entry2);

            Assert.AreEqual(1, ctx.RosterEntries.Count());
            Assert.IsNotNull(ctx.RosterEntries.Where(c => c.Id == 1 && c.TeamId == 5).FirstOrDefault());
            Assert.IsNotNull(ctx.Transactions.Where(c => c.NewTeamId == 5 && c.PlayerId == 3 && c.OldTeamId == 4).FirstOrDefault());           
        }

        [Test]
        public void TestSaveUpdateNoId()
        {
            engine.Save(entry);
            RosterEntry entry2 = new RosterEntry()
            {
                Id = 0,
                PlayerId = 3,
                TeamId = 5
            };
            engine.Save(entry2);

            Assert.AreEqual(1, ctx.RosterEntries.Count());
            Assert.IsNotNull(ctx.RosterEntries.Where(c => c.Id == 1 && c.TeamId == 5).FirstOrDefault());
            Assert.IsNotNull(ctx.Transactions.Where(c => c.NewTeamId == 5 && c.PlayerId == 3 && c.OldTeamId == 4).FirstOrDefault());
        }

        [Test]
        public void TestLoad()
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
        public void TestExists()
        {
            engine.Save(entry);
            RosterEntry entry2 = new RosterEntry()
            {
                Id = 1,
                PlayerId = 3,
                TeamId = 5
            };
            Assert.IsTrue(engine.Exists(entry2));
        }

        [Test]
        public void TestDelete()
        {
            engine.Save(entry);
            Assert.AreEqual(1, ctx.RosterEntries.Count());
            engine.Delete(entry);
            Assert.IsNull(ctx.RosterEntries.Where(c => c.Id == 1).FirstOrDefault());
        }

        [Test]
        public void TestQuery()
        {
            engine.Save(entry);
            Expression<Func<RosterEntry, bool>> expression = c => c.PlayerId == 3;
            Assert.AreEqual(1, engine.Query(expression).Count());
        }
    }
}
