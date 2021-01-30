using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NbaStats.Data.Context;
using NbaStats.Data.DataObjects;
using NbaStats.Data.Repositories;

namespace NbaStats.Data.Engines
{
    public class TeamEngine : IStatEngine<Team>
    {
        private IRepository repo;

        /// <summary>
        /// Creates a Team Engine with an InMemory Data Store.
        /// </summary>
        public TeamEngine()
        {
            repo = new SqlRepository();
        }

        /// <summary>
        /// Creates a Team Engine with the provided Repository.
        /// </summary>
        /// <param name="repo">Repository</param>
        public TeamEngine(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Creates a Team Engine with the provided Sql Context.
        /// </summary>
        /// <param name="ctx">Sql Context</param>
        public TeamEngine(SqlContext ctx)
        {
            repo = new SqlRepository(ctx);
        }

        public void Delete(Team entity)
        {
            repo.Delete(entity);
        }

        public bool Exists(Team entity)
        {
            return repo.Exists(entity);
        }

        public Team Load(long id)
        {
            return repo.GetTeam(Convert.ToInt32(id));
        }

        public IQueryable<Team> LoadAll()
        {
            return repo.GetTeams();
        }

        public IQueryable<Team> Query(Expression<Func<Team, bool>> expression)
        {
            return repo.GetTeams().Where(expression);
        }

        public Team Save(Team entity)
        {
            if (entity.Id > 0)
            {
                return repo.Update(entity);
            }
            else
            {
                if (Exists(entity))
                {
                    var original = repo.GetTeams().Where(c => c.TeamCode == entity.TeamCode).FirstOrDefault();
                    entity.Id = original.Id;
                    return Save(entity);
                }
                return repo.Insert(entity);
            }
        }
    }
}
