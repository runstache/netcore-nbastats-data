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
    public class PlayerEngine : IStatEngine<Player>
    {

        private readonly IRepository repo;

        /// <summary>
        /// Creates a Player Engine connected to an InMemory Datastore.
        /// </summary>
        public PlayerEngine()
        {
            this.repo = new SqlRepository();
        }

        /// <summary>
        /// Creates a Player Engine leveraging the provided Sql Repository.
        /// </summary>
        /// <param name="repo">Repository</param>
        public PlayerEngine(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Creates a Player Engine utilizing the provided Sql Context.
        /// </summary>
        /// <param name="ctx">Sql Context</param>
        public PlayerEngine(SqlContext ctx)
        {
            this.repo = new SqlRepository(ctx);
        }

        public void Delete(Player entity)
        {
            repo.Delete(entity);
        }

        public bool Exists(Player entity)
        {
            return repo.Exists(entity);
        }

        public Player Load(long id)
        {
            return repo.GetPlayer(id);
        }

        public IQueryable<Player> LoadAll()
        {
            return repo.GetPlayers();
        }

        public IQueryable<Player> Query(Expression<Func<Player, bool>> expression)
        {
            return repo.GetPlayers().Where(expression);
        }

        public Player Save(Player entity)
        {
            if (entity.Id > 0)
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
                    var original = repo.GetPlayers().Where(c => c.PlayerCode == entity.PlayerCode).FirstOrDefault();
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
