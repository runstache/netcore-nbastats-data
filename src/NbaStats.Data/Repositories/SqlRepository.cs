using NbaStats.Data.Context;
using NbaStats.Data.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            base.Delete(injury);
        }

        public void Delete(Player player)
        {
            base.Delete(player);
        }

        public void Delete(PlayerStat playerStat)
        {
            base.Delete(playerStat);
        }

        public void Delete(RosterEntry rosterEntry)
        {
            base.Delete(rosterEntry);
        }

        public void Delete(ScheduleEntry scheduleEntry)
        {
            base.Delete(scheduleEntry);
        }

        public void Delete(Team team)
        {
            base.Delete(team);
        }

        public void Delete(TeamStat teamStat)
        {
            base.Delete(teamStat);
        }

        public void Delete(Transaction transaction)
        {
            base.Delete(transaction);
        }

        public bool Exists(Injury injury)
        {
            Expression<Func<Injury, bool>> doesExist = c => c.PlayerId == injury.PlayerId && c.ScratchDate == injury.ScratchDate;
            return Query(doesExist).Count() > 0;
        }

        public bool Exists(Player player)
        {
            Expression<Func<Player, bool>> doesExist = c => c.PlayerCode == player.PlayerCode;
            return Query(doesExist).Count() > 0;
        }

        public bool Exists(PlayerStat playerStat)
        {
            Expression<Func<PlayerStat, bool>> doesExist = c => c.PlayerId == playerStat.PlayerId && c.ScheduleId == playerStat.ScheduleId;
            return Query(doesExist).Count() > 0;
        }

        public bool Exists(RosterEntry rosterEntry)
        {
            Expression<Func<RosterEntry, bool>> doesExist = c => c.PlayerId == rosterEntry.PlayerId && c.TeamId == rosterEntry.TeamId;
            return Query(doesExist).Count() > 0;
        }

        public bool Exists(ScheduleEntry scheduleEntry)
        {
            Expression<Func<ScheduleEntry, bool>> doesExist = c => c.HomeTeamId == scheduleEntry.HomeTeamId && c.AwayTeamId == scheduleEntry.AwayTeamId && c.GameDate == scheduleEntry.GameDate;
            return Query(doesExist).Count() > 0;
        }

        public bool Exists(Team team)
        {
            Expression<Func<Team, bool>> doesExist = c => c.TeamCode == team.TeamCode;
            return Query(doesExist).Count() > 0;
        }

        public bool Exists(TeamStat teamStat)
        {
            Expression<Func<TeamStat, bool>> doesExist = c => c.TeamId == teamStat.TeamId && c.ScheduleId == teamStat.ScheduleId && c.OpponentId == teamStat.OpponentId;
            return Query(doesExist).Count() > 0;
        }

        public bool Exists(Transaction transaction)
        {
            Expression<Func<Transaction, bool>> doesExist = c => c.PlayerId == transaction.PlayerId && c.NewTeamId == transaction.NewTeamId && c.OldTeamId == transaction.OldTeamId;
            return Query(doesExist).Count() > 0;
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
