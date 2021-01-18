using System;
using System.Collections.Generic;
using System.Text;
using NbaStats.Data.DataObjects;
using NbaStats.Data.Context;
using NbaStats.Data.Repositories;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework;
using NbaStats.Data.Engines;

namespace NbaStats.Data.Tests.Engines
{
    [TestFixture]
    public class PlayerEngineTests
    {
        private Player player;
        private SqlContext ctx;
        private IStatEngine<Player> engine;
        

        [SetUp]
        public void Setup()
        {
            ctx = new SqlContext();
            engine = new PlayerEngine(ctx);

            player = new Player()
            {
                Id = 1,
                PlayerCode = "JSMITH",
                PlayerName = "Jim Smith"
            };
        }

        [TearDown]
        public void Cleanup()
        {
            foreach(Player item in ctx.Players)
            {
                ctx.Players.Remove(item);
            }
            ctx.SaveChanges();
        }

        [Test]
        public void TestSavePlayer()
        {
            engine.Save(player);
            Assert.AreEqual(1, ctx.Players.Count());

            Assert.IsNotNull(ctx.Players.Where(c => c.Id == 1).FirstOrDefault());
        }

        [Test]
        public void TestUpdatePlayer()
        {
            engine.Save(player);
            Player player2 = new Player()
            {
                Id = 1,
                PlayerCode = "JSMITH",
                PlayerName = "Jeff Smith"
            };
            engine.Save(player2);
            Assert.AreEqual(1, ctx.Players.Count());

            Assert.IsNotNull(ctx.Players.Where(c => c.PlayerName == "Jeff Smith").FirstOrDefault());
        }

        [Test]
        public void TestUpdatePlayerNoId()
        {
            engine.Save(player);
            Player player2 = new Player()
            {
                Id = 0,
                PlayerCode = "JSMITH",
                PlayerName = "Jeff Smith"
            };
            engine.Save(player2);
            Assert.AreEqual(1, ctx.Players.Count());

            Assert.IsNotNull(ctx.Players.Where(c => c.PlayerName == "Jeff Smith").FirstOrDefault());

        }

        [Test]
        public void TestLoad()
        {
            engine.Save(player);
            Assert.IsNotNull(engine.Load(1));
        }

        [Test]
        public void TestLoadAll()
        {
            engine.Save(player);
            Assert.AreEqual(1, engine.LoadAll().Count());

        }

        [Test]
        public void TestQuery()
        {
            engine.Save(player);
            Expression<Func<Player, bool>> expression = c => c.PlayerCode == "JSMITH";

            Assert.AreEqual(1, engine.Query(expression).Count());
        }

        [Test]
        public void TestDelete()
        {
            engine.Save(player);
            Assert.IsNotNull(engine.Load(1));

            engine.Delete(player);
            Assert.AreEqual(0, ctx.Players.Count());
        }

        [Test]
        public void TestExists()
        {
            engine.Save(player);
            Assert.IsTrue(engine.Exists(player));
        }
    }
}
