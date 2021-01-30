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
    public class ScheduleEntryEngine : IStatEngine<ScheduleEntry>
    {
        private readonly IRepository repo;

        /// <summary>
        /// Creates a Schedule Entry Engine with InMemory Data Store.
        /// </summary>
        public ScheduleEntryEngine()
        {
            repo = new SqlRepository();
        }

        /// <summary>
        /// Creates a Schedule Entry Engine with provided Repository.
        /// </summary>
        /// <param name="repo">Repository</param>
        public ScheduleEntryEngine(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Creates a Schedule Entry Engine with the provided Sql Context.
        /// </summary>
        /// <param name="ctx">Sql Context</param>
        public ScheduleEntryEngine(SqlContext ctx)
        {
            repo = new SqlRepository(ctx);
        }

        public void Delete(ScheduleEntry entity)
        {
            repo.Delete(entity);
        }

        public bool Exists(ScheduleEntry entity)
        {
            return repo.Exists(entity);
        }

        public ScheduleEntry Load(long id)
        {
            return repo.GetScheduleEntry(id);
        }

        public IQueryable<ScheduleEntry> LoadAll()
        {
            return repo.GetScheduleEntries();
        }

        public IQueryable<ScheduleEntry> Query(Expression<Func<ScheduleEntry, bool>> expression)
        {
            return repo.GetScheduleEntries().Where(expression);
        }

        public ScheduleEntry Save(ScheduleEntry entity)
        {
            if (entity.Id > 0)
            {
                return repo.Update(entity);
            }
            else
            {
                if (Exists(entity))
                {
                    var original = repo.GetScheduleEntries().Where(c => c.AwayTeamId == entity.AwayTeamId && c.HomeTeamId == entity.HomeTeamId && c.GameDate == entity.GameDate).FirstOrDefault();
                    if (original != null)
                    {
                        entity.Id = original.Id;
                        return repo.Update(entity);
                    }                    
                }
                return repo.Insert(entity);
                
            }
        }
    }
}
