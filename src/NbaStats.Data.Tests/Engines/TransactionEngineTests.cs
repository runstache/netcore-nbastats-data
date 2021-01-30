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
    public class TransactionEngineTests
    {
        private IStatEngine<Transaction> engine;
        private Transaction transaction;
        private SqlContext ctx;

        [SetUp]
        public void Setup()
        {
            ctx = new SqlContext();
            engine = new TransactionEngine(ctx);

            transaction = new Transaction()
            {
                Id = 1,
                NewTeamId = 4,
                OldTeamId = 6,
                PlayerId = 3
            };
        }

        [TearDown]
        public void Cleanup()
        {
            foreach(Transaction item in ctx.Transactions)
            {
                ctx.Transactions.Remove(item);
            }
            ctx.SaveChanges();
        }

        [Test]
        public void TestSave()
        {
            transaction.Id = 0;
            engine.Save(transaction);
            Assert.AreEqual(1, ctx.Transactions.Count());
        }

        [Test]
        public void TestSaveUpdate()
        {
            ctx.Transactions.Add(transaction);
            ctx.SaveChanges();

            Transaction transaction2 = new Transaction()
            {
                Id = 1,
                NewTeamId = 4,
                OldTeamId = 7,
                PlayerId = 3
            };
            engine.Save(transaction2);
            Assert.IsNotNull(ctx.Transactions.Where(c => c.Id == 1 && c.OldTeamId == 7).FirstOrDefault());
        }

        [Test]
        public void TestLoad()
        {
            ctx.Transactions.Add(transaction);
            ctx.SaveChanges();
            Assert.IsNotNull(engine.Load(1));
        }

        [Test]
        public void TestLoadAll()
        {
            ctx.Transactions.Add(transaction);
            ctx.SaveChanges();
            Assert.AreEqual(1, engine.LoadAll().Count());
        }

        [Test]
        public void TestQuery()
        {
            ctx.Transactions.Add(transaction);
            ctx.SaveChanges();

            Expression<Func<Transaction, bool>> expression = c => c.OldTeamId == 6;
            Assert.AreEqual(1, engine.Query(expression).Count());
        }

        [Test]
        public void TestExists()
        {
            ctx.Transactions.Add(transaction);
            ctx.SaveChanges();

            Transaction transaction2 = new Transaction()
            {
                Id = 1,
                NewTeamId = 4,
                OldTeamId = 6,
                PlayerId = 3
            };
            Assert.IsTrue(engine.Exists(transaction2));
        }

        [Test]
        public void TestDelete()
        {
            ctx.Transactions.Add(transaction);
            ctx.SaveChanges();
            engine.Delete(transaction);

            Assert.IsNull(ctx.Transactions.Where(c => c.Id == 1).FirstOrDefault());
        }

    }
}
