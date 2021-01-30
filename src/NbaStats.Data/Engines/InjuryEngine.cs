using System;
using System.Collections.Generic;
using System.Text;
using NbaStats.Data.DataObjects;
using NbaStats.Data.Repositories;
using NbaStats.Data.Context;
using System.Linq;
using System.Linq.Expressions;

namespace NbaStats.Data.Engines
{
    public class InjuryEngine : IStatEngine<Injury>
    {

        private readonly IRepository repo;

        /// <summary>
        /// Creates an Injury Engine with an InMemory Datastore.
        /// </summary>
        public InjuryEngine()
        {
            repo = new SqlRepository();
        }

        /// <summary>
        /// Creates an Injury Engine with the provided Repository.
        /// </summary>
        /// <param name="repo">Repository</param>
        public InjuryEngine(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Creates an Injury Engine based on the provided Sql Context.
        /// </summary>
        /// <param name="ctx">Sql Context</param>
        public InjuryEngine(SqlContext ctx)
        {
            this.repo = new SqlRepository(ctx);
        }

        public void Delete(Injury entity)
        {
            repo.Delete(entity);
        }

        public bool Exists(Injury entity)
        {
            return repo.Exists(entity);
        }

        public IQueryable<Injury> LoadAll()
        {
            return repo.GetInjuries();
        }

        public Injury Load(long id)
        {
            return repo.GetInjury(id);
        }

        public IQueryable<Injury> Query(Expression<Func<Injury, bool>> expression)
        {
            return repo.GetInjuries().Where(expression);
        }

        public Injury Save(Injury entity)
        {
            if (entity.Id > 0  && Exists(entity))
            {
                return repo.Update(entity);
            }
            else
            {
                if (!Exists(entity))
                {
                    return repo.Insert(entity);
                }
                else
                {
                    var original = repo.GetInjuries().Where(c => c.PlayerId == entity.PlayerId && c.ScratchDate == entity.ScratchDate).FirstOrDefault();
                    if (original != null)
                    {
                        entity.Id = original.Id;
                        return Save(entity);
                    }
                    else
                    {
                        return repo.Insert(entity);
                    }
                }
            }
        }
    }
}
