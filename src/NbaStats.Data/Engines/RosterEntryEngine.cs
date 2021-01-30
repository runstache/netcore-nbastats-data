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
    public class RosterEntryEngine : IStatEngine<RosterEntry>
    {
        private readonly IRepository repo;

        /// <summary>
        /// Creates a Roster Entry engine to an InMemory Data Store.
        /// </summary>
        public RosterEntryEngine()
        {
            repo = new SqlRepository();
        }

        /// <summary>
        /// Creates a Roster Entry Engine utilzing the provided Repository.
        /// </summary>
        /// <param name="repo">Repository</param>
        public RosterEntryEngine(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Creates a Roster Entry Engine utilizing the provided Sql Context.
        /// </summary>
        /// <param name="ctx">Sql Context</param>
        public RosterEntryEngine(SqlContext ctx)
        {
            repo = new SqlRepository(ctx);
        }

        public void Delete(RosterEntry entity)
        {
            repo.Delete(entity);
        }

        public bool Exists(RosterEntry entity)
        {
            return repo.Exists(entity);
        }

        public RosterEntry Load(long id)
        {
            return repo.GetRosterEntry(id);
        }

        public IQueryable<RosterEntry> LoadAll()
        {
            return repo.GetRosterEntries();
        }

        public IQueryable<RosterEntry> Query(Expression<Func<RosterEntry, bool>> expression)
        {
            return repo.GetRosterEntries().Where(expression);
        }

        public RosterEntry Save(RosterEntry entity)
        {
            if (entity.Id > 0 && Exists(entity))
            {
                var original = repo.GetRosterEntry(entity.Id);
                Transaction transaction = new Transaction()
                {
                    NewTeamId = entity.TeamId,
                    OldTeamId = original.TeamId,
                    PlayerId = entity.PlayerId
                };
                repo.Insert(transaction);
                return repo.Update(entity);
            }
            else
            {
                if (Exists(entity))
                {
                    var original = repo.GetRosterEntries().Where(c => c.PlayerId == entity.PlayerId).FirstOrDefault();
                    Transaction transaction = new Transaction()
                    {
                        NewTeamId = entity.TeamId,
                        OldTeamId = original.TeamId,
                        PlayerId = entity.PlayerId
                    };
                    entity.Id = original.Id;
                    repo.Insert(transaction);
                    return repo.Update(entity);
                }
                else
                {
                    return repo.Insert(entity);
                }
            }
        }
    }
}
