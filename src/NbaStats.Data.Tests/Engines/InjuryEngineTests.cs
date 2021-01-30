using System;
using System.Collections.Generic;
using System.Text;
using NbaStats.Data.DataObjects;
using NbaStats.Data.Engines;
using NbaStats.Data.Repositories;
using NbaStats.Data.Context;
using NUnit.Framework;
using System.Linq;
using System.Linq.Expressions;

namespace NbaStats.Data.Tests.Engines
{
    public class InjuryEngineTests
    {
        private IStatEngine<Injury> engine;
        private SqlContext ctx;
        private Injury injury;

        [SetUp]
        public void Setup()
        {
            ctx = new SqlContext();
            engine = new InjuryEngine(ctx);

            injury = new Injury()
            {
                Id = 1,
                PlayerId = 1,
                ScratchDate = new DateTime(2020, 1, 18)
            };
        }

        [TearDown]
        public void Cleanup()
        {
            foreach(Injury item in ctx.Injuries)
            {
                ctx.Injuries.Remove(item);
            }
            ctx.SaveChanges();
        }

        [Test]
        public void TestSaveInjury()
        {
            engine.Save(injury);
            Assert.IsNotNull(ctx.Injuries.Where(c => c.Id == 1).FirstOrDefault());
        }

        [Test]
        public void TestSaveInjuryUpdate()
        {
            engine.Save(injury);

            Injury injury2 = new Injury()
            {
                Id = 1,
                PlayerId = 2,
                ScratchDate = new DateTime(2020, 1, 18)
            };

            Injury result = ctx.Injuries.Where(c => c.Id == 1).FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.PlayerId);
        }

        [Test]
        public void TestSaveInjuryUpdateNoId()
        {
            engine.Save(injury);
            Injury injury2 = new Injury()
            {
                Id = 0,
                PlayerId = 1,
                ScratchDate = new DateTime(2020, 1, 18)
            };

            Assert.IsNull(ctx.Injuries.Where(c => c.Id == 0).FirstOrDefault());
        }


        [Test]
        public void TestLoadItem()
        {
            engine.Save(injury);

            Assert.IsNotNull(engine.Load(1));
        }

        [Test]
        public void TestLoadAll()
        {
            engine.Save(injury);
            Assert.AreEqual(1, engine.LoadAll().Count());
        }

        [Test]
        public void TestQueryItems()
        {
            engine.Save(injury);
            Expression<Func<Injury, bool>> expression = c => c.PlayerId == 1;

            Assert.AreEqual(1, engine.Query(expression).Count());                        
        }

        [Test]
        public void TestDeleteItem()
        {
            engine.Save(injury);
            Assert.AreEqual(1, ctx.Injuries.Count());

            engine.Delete(injury);
            Assert.IsNull(engine.Load(1));

        }

        [Test]
        public void TestExists()
        {
            engine.Save(injury);

            Injury injury2 = new Injury()
            {
                Id = 0,
                PlayerId = 1,
                ScratchDate = new DateTime(2020, 1, 18)
            };
            Assert.IsTrue(engine.Exists(injury2));
        }
    }
}
