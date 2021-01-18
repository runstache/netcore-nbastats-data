using System;
using System.Collections.Generic;
using System.Text;
using NbaStats.Data.Context;
using NbaStats.Data.DataObjects;
using NbaStats.Data.Engines;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework;

namespace NbaStats.Data.Tests.Engines
{
    [TestFixture]
    public class TeamEngineTests
    {
        private IStatEngine<Team> engine;
        private Team team;
        private SqlContext ctx;

        [SetUp]
        public void Setup()
        {
            team = new Team()
            {
                Id = 1,
                TeamCode = "MIN",
                TeamName = "Minnesota Wild"
            };
            ctx = new SqlContext();
            engine = new TeamEngine(ctx);
        }

        [TearDown]
        public void Cleanup()
        {
            foreach(Team item in ctx.Teams)
            {
                ctx.Teams.Remove(item);
            }
            ctx.SaveChanges();
        }

        [Test]
        public void TestSave()
        {
            team.Id = 0;
            engine.Save(team);

            Assert.NotNull(ctx.Teams.Where(c => c.Id == 1).FirstOrDefault());
        }

        [Test]
        public void TestSaveUpdate()
        {
            ctx.Teams.Add(team);
            ctx.SaveChanges();

            Team team2 = new Team()
            {
                Id = 1,
                TeamCode = "MIN",
                TeamName = "Minnesota Twins"
            };
            engine.Save(team2);
            Assert.AreEqual(1, ctx.Teams.Count());
            Assert.IsNotNull(ctx.Teams.Where(c => c.Id == 1 && c.TeamName == "Minnesota Twins").FirstOrDefault());
        }

        [Test]
        public void TestSaveUpdateNoId()
        {
            ctx.Teams.Add(team);
            ctx.SaveChanges();

            Team team2 = new Team()
            {
                Id = 0,
                TeamCode = "MIN",
                TeamName = "Minnesota Twins"
            };
            engine.Save(team2);
            Assert.AreEqual(1, ctx.Teams.Count());
            Assert.IsNotNull(ctx.Teams.Where(c => c.Id == 1 && c.TeamName == "Minnesota Twins").FirstOrDefault());
        }

        [Test]
        public void TestLoad()
        {
            ctx.Teams.Add(team);
            ctx.SaveChanges();

            Assert.IsNotNull(engine.Load(1));
        }

        [Test]
        public void TestLoadAll()
        {
            ctx.Teams.Add(team);
            ctx.SaveChanges();

            Assert.AreEqual(1, engine.LoadAll().Count());
        }

        [Test]
        public void TestQuery()
        {
            ctx.Teams.Add(team);
            ctx.SaveChanges();

            Expression<Func<Team, bool>> expression = c => c.TeamCode == "MIN";
            Assert.AreEqual(1, engine.Query(expression).Count());
        }

        [Test]
        public void TestDelete()
        {
            ctx.Teams.Add(team);
            ctx.SaveChanges();
            engine.Delete(team);

            Assert.IsNull(ctx.Teams.Where(c => c.Id == 1).FirstOrDefault());
        }

        [Test]
        public void TestExists()
        {
            ctx.Teams.Add(team);
            ctx.SaveChanges();

            Team team2 = new Team()
            {
                Id = 1,
                TeamCode = "MIN",
                TeamName = "Minnesota Twins"
            };

            Assert.IsTrue(engine.Exists(team2));

        }
    }
}
