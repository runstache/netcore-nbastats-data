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
            player.Id = 0;
            engine.Save(player);
            Assert.AreEqual(1, ctx.Players.Count());

            Assert.IsNotNull(ctx.Players.Where(c => c.Id == 1).FirstOrDefault());
        }

        [Test]
        public void TestUpdatePlayer()
        {
            ctx.Players.Add(player);
            ctx.SaveChanges();

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
            ctx.Players.Add(player);
            ctx.SaveChanges();
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
            ctx.Players.Add(player);
            ctx.SaveChanges();
            Assert.IsNotNull(engine.Load(1));
        }

        [Test]
        public void TestLoadAll()
        {
            ctx.Players.Add(player);
            ctx.SaveChanges();
            Assert.AreEqual(1, engine.LoadAll().Count());

        }

        [Test]
        public void TestQuery()
        {
            ctx.Players.Add(player);
            ctx.SaveChanges();
            Expression<Func<Player, bool>> expression = c => c.PlayerCode == "JSMITH";

            Assert.AreEqual(1, engine.Query(expression).Count());
        }

        [Test]
        public void TestDelete()
        {
            ctx.Players.Add(player);
            ctx.SaveChanges();
            Assert.IsNotNull(engine.Load(1));

            engine.Delete(player);
            Assert.AreEqual(0, ctx.Players.Count());
        }

        [Test]
        public void TestExists()
        {
            ctx.Players.Add(player);
            ctx.SaveChanges();
            Assert.IsTrue(engine.Exists(player));
        }
    }
}
