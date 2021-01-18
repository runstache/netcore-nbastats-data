using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NbaStats.Data.DataObjects;
using NbaStats.Data.Repositories;
using NbaStats.Data.Context;

namespace NbaStats.Data.Engines
{
    public class TeamStatEngine : IStatEngine<TeamStat>
    {
        private readonly IRepository repo;

        /// <summary>
        /// Creates a Team Stat Engine with an InMemory Datastore.
        /// </summary>
        public TeamStatEngine()
        {
            repo = new SqlRepository();
        }

        /// <summary>
        /// Creates a Team Stat Engine for the provided Repository.
        /// </summary>
        /// <param name="repo">Repository</param>
        public TeamStatEngine(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Creates a Team Stat Engine for the provided Sql Context.
        /// </summary>
        /// <param name="ctx">Sql Context</param>
        public TeamStatEngine(SqlContext ctx)
        {
            repo = new SqlRepository(ctx);
        }

        public void Delete(TeamStat entity)
        {
            repo.Delete(entity);
        }

        public bool Exists(TeamStat entity)
        {
            return repo.Exists(entity);
        }

        public TeamStat Load(long id)
        {
            return repo.GetTeamStat(id);
        }

        public IQueryable<TeamStat> LoadAll()
        {
            return repo.GetTeamStats();
        }

        public IQueryable<TeamStat> Query(Expression<Func<TeamStat, bool>> expression)
        {
            return repo.GetTeamStats().Where(expression);
        }

        public TeamStat Save(TeamStat entity)
        {
            if (entity.Id > 0)
            {
                return repo.Update(entity);
            }
            else
            {
                if (Exists(entity))
                {
                    var original = repo.GetTeamStats().Where(c => c.TeamId == entity.TeamId && c.ScheduleId == entity.ScheduleId).FirstOrDefault();
                    entity.Id = original.Id;
                    return Save(entity);
                }
                return repo.Insert(entity);
            }
        }
    }
}
