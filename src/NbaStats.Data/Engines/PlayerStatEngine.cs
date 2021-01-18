using System;
using System.Collections.Generic;
using System.Text;
using NbaStats.Data.DataObjects;
using NbaStats.Data.Context;
using NbaStats.Data.Repositories;
using System.Linq;
using System.Linq.Expressions;

namespace NbaStats.Data.Engines
{
    public class PlayerStatEngine : IStatEngine<PlayerStat>
    {
        private readonly IRepository repo;

        /// <summary>
        /// Creates a Player Stat Engine with an InMemory Datastore.
        /// </summary>
        public PlayerStatEngine()
        {
            repo = new SqlRepository();
        }

        /// <summary>
        /// Creates a Player Stat Engine utilizing the provided Repository.
        /// </summary>
        /// <param name="repo">Repository</param>
        public PlayerStatEngine(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Creates a Player Stat Engine utilizing the provide Sql Context.
        /// </summary>
        /// <param name="ctx">Sql Context</param>
        public PlayerStatEngine(SqlContext ctx)
        {
            repo = new SqlRepository(ctx);
        }


        public void Delete(PlayerStat entity)
        {
            repo.Delete(entity);
        }

        public bool Exists(PlayerStat entity)
        {
            return repo.Exists(entity);
        }

        public PlayerStat Load(long id)
        {
            return repo.GetPlayerStat(id);
        }

        public IQueryable<PlayerStat> LoadAll()
        {
            return repo.GetPlayerStats();
        }

        public IQueryable<PlayerStat> Query(Expression<Func<PlayerStat, bool>> expression)
        {
            return repo.GetPlayerStats().Where(expression);
        }

        public PlayerStat Save(PlayerStat entity)
        {
            if (entity.Id > 0 && Exists(entity))
            {
                return repo.Update(entity);
            }
            else
            {
                if (Exists(entity))
                {
                    var original = repo.GetPlayerStats().Where(c => c.PlayerId == entity.PlayerId && c.ScheduleId == entity.ScheduleId).FirstOrDefault();
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
                else
                {
                    return repo.Insert(entity);
                }
            }
        }
    }
}
