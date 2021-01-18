using System;
using System.Collections.Generic;
using System.Text;
using NbaStats.Data.Repositories;
using NbaStats.Data.DataObjects;
using System.Linq;
using System.Linq.Expressions;
using NbaStats.Data.Context;

namespace NbaStats.Data.Engines
{
    public class TransactionEngine : IStatEngine<Transaction>
    {
        private readonly IRepository repo;

        /// <summary>
        /// Creates a Transaction Engine with an InMemory Datastore.
        /// </summary>
        public TransactionEngine()
        {
            repo = new SqlRepository();
        }

        /// <summary>
        /// Creates a Transaction Engine using the provided Repository.
        /// </summary>
        /// <param name="repo">Repository</param>
        public TransactionEngine(IRepository repo)
        {
            this.repo = repo;
        }
        
        /// <summary>
        /// Creates a Transaction Engine using the provided Sql Context.
        /// </summary>
        /// <param name="ctx">Sql Context</param>
        public TransactionEngine(SqlContext ctx)
        {
            repo = new SqlRepository(ctx);
        }

        public void Delete(Transaction entity)
        {
            repo.Delete(entity);
        }

        public bool Exists(Transaction entity)
        {
            return repo.Exists(entity);
        }

        public Transaction Load(long id)
        {
            return repo.GetTransaction(id);
        }

        public IQueryable<Transaction> LoadAll()
        {
            return repo.GetTransactions();
        }

        public IQueryable<Transaction> Query(Expression<Func<Transaction, bool>> expression)
        {
            return repo.GetTransactions().Where(expression);
        }

        public Transaction Save(Transaction entity)
        {
            if (entity.Id > 0)
            {
                return repo.Update(entity);
            }
            else
            {
                return repo.Insert(entity);
            }
        }
    }
}
