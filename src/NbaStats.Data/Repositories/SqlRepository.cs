using NbaStats.Data.Context;
using NbaStats.Data.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NbaStats.Data.Repositories
{
    public class SqlRepository : BaseRepository, IRepository
    {
        

        /// <summary>
        /// Creates a New Sql Repository with an In Memory Database.
        /// </summary>
        public SqlRepository():base(new SqlContext())
        {            
        }

        /// <summary>
        /// Creates a New Sql Repository Connectected to a database using the provided Connection String/
        /// </summary>
        /// <param name="connString">DB Connection String</param>
        public SqlRepository(string connString) : base(new SqlContext(connString))
        {            
        }

        /// <summary>
        /// Creates a New Sql Repository connected to a database using the provided Sql Context.
        /// </summary>
        /// <param name="ctx">Sql Context</param>
        public SqlRepository(SqlContext ctx) : base(ctx)
        {            
        }

        public void Delete(Injury injury)
        {
            throw new NotImplementedException();
        }

        public void Delete(Player player)
        {
            throw new NotImplementedException();
        }

        public void Delete(PlayerStat playerStat)
        {
            throw new NotImplementedException();
        }

        public void Delete(RosterEntry rosterEntry)
        {
            throw new NotImplementedException();
        }

        public void Delete(ScheduleEntry scheduleEntry)
        {
            throw new NotImplementedException();
        }

        public void Delete(Team team)
        {
            throw new NotImplementedException();
        }

        public void Delete(TeamStat teamStat)
        {
            throw new NotImplementedException();
        }

        public void Delete(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Injury injury)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Player player)
        {
            throw new NotImplementedException();
        }

        public bool Exists(PlayerStat playerStat)
        {
            throw new NotImplementedException();
        }

        public bool Exists(RosterEntry rosterEntry)
        {
            throw new NotImplementedException();
        }

        public bool Exists(ScheduleEntry scheduleEntry)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Team team)
        {
            throw new NotImplementedException();
        }

        public bool Exists(TeamStat teamStat)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Injury> GetInjuries()
        {
            throw new NotImplementedException();
        }

        public Injury GetInjury(long id)
        {
            throw new NotImplementedException();
        }

        public Player GetPlayer(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Player> GetPlayers()
        {
            throw new NotImplementedException();
        }

        public PlayerStat GetPlayerStat(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PlayerStat> GetPlayerStats()
        {
            throw new NotImplementedException();
        }

        public IQueryable<RosterEntry> GetRosterEntries()
        {
            throw new NotImplementedException();
        }

        public RosterEntry GetRosterEntry(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ScheduleEntry> GetScheduleEntries()
        {
            throw new NotImplementedException();
        }

        public ScheduleEntry GetScheduleEntry(long id)
        {
            throw new NotImplementedException();
        }

        public Team GetTeam(int id)
        {
            throw new NotImplementedException();
        }

        public TeamStat GetTeamStat(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TeamStat> GetTeamStats()
        {
            throw new NotImplementedException();
        }

        public Injury Insert(Injury injury)
        {
            return Add(injury);
        }

        public Player Insert(Player player)
        {
            return Add(player);
        }

        public PlayerStat Insert(PlayerStat playerStat)
        {
            return Add(playerStat);
        }

        public RosterEntry Insert(RosterEntry rosterEntry)
        {
            return Add(rosterEntry);
        }

        public ScheduleEntry Insert(ScheduleEntry scheduleEntry)
        {
            return Add(scheduleEntry);
        }

        public Team Insert(Team team)
        {
            return Add(team);
        }

        public TeamStat Insert(TeamStat teamStat)
        {
            return Add(teamStat);
        }

        public Transaction Insert(Transaction transaction)
        {
            return Add(transaction);
        }

        public Injury Update(Injury injury)
        {
            return base.Update(injury);
        }

        public Player Update(Player player)
        {
            return base.Update(player);
        }

        public PlayerStat Update(PlayerStat playerStat)
        {
            return base.Update(playerStat);
        }

        public RosterEntry Update(RosterEntry rosterEntry)
        {
            return base.Update(rosterEntry);
        }

        public ScheduleEntry Update(ScheduleEntry scheduleEntry)
        {
            return base.Update(scheduleEntry);
        }

        public Team Update(Team team)
        {
            return base.Update(team);
        }

        public TeamStat Update(TeamStat teamStat)
        {
            return base.Update(teamStat);
        }

        public Transaction Update(Transaction transaction)
        {
            return base.Update(transaction);
        }
    }
}
