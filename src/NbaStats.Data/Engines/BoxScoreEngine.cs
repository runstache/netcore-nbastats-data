using NbaStats.Data.Context;
using NbaStats.Data.DataObjects;
using NbaStats.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NbaStats.Data.Engines
{
    public class BoxScoreEngine : IStatEngine<BoxScoreEntry>
    {
        private readonly IRepository repo;

        /// <summary>
        /// Creates a Box Score Engine with an In Memory Sql Context.
        /// </summary>
        public BoxScoreEngine()
        {
            repo = new SqlRepository();
        }

        /// <summary>
        /// Creates a Box Score Engine with the provided Repository.
        /// </summary>
        /// <param name="repo">Repository</param>
        public BoxScoreEngine(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Creates a Box Score Engine with the provided Sql Context.
        /// </summary>
        /// <param name="ctx">Sql Context</param>
        public BoxScoreEngine(SqlContext ctx)
        {
            this.repo = new SqlRepository(ctx);
        }

        public void Delete(BoxScoreEntry entity)
        {
            repo.Delete(entity);
        }

        public bool Exists(BoxScoreEntry entity)
        {
            return repo.Exists(entity);
        }

        public BoxScoreEntry Load(long id)
        {
            return repo.GetBoxScoreEntry(id);
        }

        public IQueryable<BoxScoreEntry> LoadAll()
        {
            return repo.GetBoxScoreEntries();
        }

        public IQueryable<BoxScoreEntry> Query(Expression<Func<BoxScoreEntry, bool>> expression)
        {
            return repo.GetBoxScoreEntries().Where(expression);
        }

        public BoxScoreEntry Save(BoxScoreEntry entity)
        {
            if (entity.Id > 0 && Exists(entity))
            {
                return repo.Update(entity);
            }
            else
            {
                if (Exists(entity))
                {
                    var original = repo.GetBoxScoreEntries().Where(c => c.TeamId == entity.TeamId && c.ScheduleId == entity.ScheduleId).FirstOrDefault();
                    entity.Id = original.Id;
                    return Save(entity);                    
                }
                return repo.Insert(entity);
            }
        }
    }
}
