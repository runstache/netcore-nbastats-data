using System;
using System.Collections.Generic;
using System.Text;
using NbaStats.Data.DataObjects;
using System.Linq;

namespace NbaStats.Data.Repositories
{
    public interface IRepository
    {
        #region Insert

        /// <summary>
        /// Inserts an Injury Record to the Database.
        /// </summary>
        /// <param name="injury">Injury to insert</param>
        /// <returns>Resulting Injury</returns>
        Injury Insert(Injury injury);

        /// <summary>
        /// Inserts a Player Record to the Database.
        /// </summary>
        /// <param name="player">Player to Insert</param>
        /// <returns>Resulting Player</returns>
        Player Insert(Player player);

        /// <summary>
        /// Inserts a Player Stat to the Database.
        /// </summary>
        /// <param name="playerStat">Player Stat to Insert</param>
        /// <returns>Resulting Player Stat</returns>
        PlayerStat Insert(PlayerStat playerStat);

        /// <summary>
        /// Inserts a Rosert Entry to the Database.
        /// </summary>
        /// <param name="rosterEntry">Roster Entry to Insert</param>
        /// <returns>Resulting Roster Entry</returns>
        RosterEntry Insert(RosterEntry rosterEntry);

        /// <summary>
        /// Inserts a Schedule Entry to the Database.
        /// </summary>
        /// <param name="scheduleEntry">Schedule Entry to Insert</param>
        /// <returns>Resulting Schedule Entry </returns>
        ScheduleEntry Insert(ScheduleEntry scheduleEntry);

        /// <summary>
        /// Inserts a Team to the Database.
        /// </summary>
        /// <param name="team">Team to Insert</param>
        /// <returns>Resulting Team</returns>
        Team Insert(Team team);

        /// <summary>
        /// Inserts a Team Stat to the Database.
        /// </summary>
        /// <param name="teamStat">Team Stat to Insert</param>
        /// <returns>Resulting Team Stat</returns>
        TeamStat Insert(TeamStat teamStat);

        /// <summary>
        /// Inserts a Transaction to the Database.
        /// </summary>
        /// <param name="transaction">Transaction to Insert</param>
        /// <returns>Resulting Transaction</returns>
        Transaction Insert(Transaction transaction);

        #endregion

        #region Update

        /// <summary>
        /// Injury to Update in the Database.
        /// </summary>
        /// <param name="injury">Injury to Update</param>
        /// <returns>Updated Injury</returns>
        Injury Update(Injury injury);

        /// <summary>
        /// Updates a Player in the Database.
        /// </summary>
        /// <param name="player">Player to Update</param>
        /// <returns>Updated Player</returns>
        Player Update(Player player);

        /// <summary>
        /// Updates a Player Stat in the Database.
        /// </summary>
        /// <param name="playerStat">Player Stat to Update</param>
        /// <returns>Updated Player Stat</returns>
        PlayerStat Update(PlayerStat playerStat);

        /// <summary>
        /// Updates a Roster Entry in the Database.
        /// </summary>
        /// <param name="rosterEntry">Roster Entry to Update</param>
        /// <returns>Updated Roster Entry</returns>
        RosterEntry Update(RosterEntry rosterEntry);

        /// <summary>
        /// Updates a Schedule Entry in the Database.
        /// </summary>
        /// <param name="scheduleEntry">Schedule Entry to Update</param>
        /// <returns>Updated Schedule Entry</returns>
        ScheduleEntry Update(ScheduleEntry scheduleEntry);

        /// <summary>
        /// Updates a Team in the Database.
        /// </summary>
        /// <param name="team">Team to Update</param>
        /// <returns>Updated Team</returns>
        Team Update(Team team);

        /// <summary>
        /// Updates a Team Stat in the Database.
        /// </summary>
        /// <param name="teamStat">Team Stat to Update</param>
        /// <returns>Updated Team Stat</returns>
        TeamStat Update(TeamStat teamStat);

        /// <summary>
        /// Updates a Transaction in the Database.
        /// </summary>
        /// <param name="transaction">Transaction to Update</param>
        /// <returns>Updated Transaction</returns>
        Transaction Update(Transaction transaction);

        #endregion

        #region Retrieval

        /// <summary>
        /// Retrieves a Given Injury Entry from the Database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Injury Record</returns>
        Injury GetInjury(long id);

        /// <summary>
        /// Retrives All the Injuries from the Database.
        /// </summary>
        /// <returns>Queryable of the Injuries</returns>
        IQueryable<Injury> GetInjuries();

        /// <summary>
        /// Retrieves a Given Player from the Database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Player</returns>
        Player GetPlayer(long id);

        /// <summary>
        /// Retrieves the Players from the Database
        /// </summary>
        /// <returns></returns>
        IQueryable<Player> GetPlayers();

        /// <summary>
        /// Retrieves a Given Player Stat.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Player Stat</returns>
        PlayerStat GetPlayerStat(long id);

        /// <summary>
        /// Retrieves the Player Stats from the Database.
        /// </summary>
        /// <returns>Queryable of Player Stats</returns>
        IQueryable<PlayerStat> GetPlayerStats();

        /// <summary>
        /// Retrieves a Give Roster Entry.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Roster Entry</returns>
        RosterEntry GetRosterEntry(long id);

        /// <summary>
        /// Retrieves the Roster Entries from the Database.
        /// </summary>
        /// <returns>Queryable of Roster Entries</returns>
        IQueryable<RosterEntry> GetRosterEntries();

        /// <summary>
        /// Retrieves a given Schedule Entry from the database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Schedule Entry</returns>
        ScheduleEntry GetScheduleEntry(long id);

        /// <summary>
        /// Retrieves the Schedule Entries from the Database.
        /// </summary>
        /// <returns>Queryable of Schedule Entries</returns>
        IQueryable<ScheduleEntry> GetScheduleEntries();

        /// <summary>
        /// Retrieves a Given Team from the Database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Team</returns>
        Team GetTeam(int id);

        /// <summary>
        /// Retrieves the Teams from the Database.
        /// </summary>
        /// <returns>Queryable of Teams</returns>
        IQueryable<Team> GetTeams();

        /// <summary>
        /// Retrieves a Given Team Stat from the Database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Team Stat</returns>
        TeamStat GetTeamStat(long id);

        /// <summary>
        /// Retrieves the Team Stats from the Database.
        /// </summary>
        /// <returns>Queryable of Team Stats</returns>
        IQueryable<TeamStat> GetTeamStats();

        /// <summary>
        /// Retrieves a Given Transaction from the Database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Transaction</returns>
        Transaction GetTransaction(long id);

        /// <summary>
        /// Retrieves all of the Transactions from the Database.
        /// </summary>
        /// <returns>Queryable of Transactions</returns>
        IQueryable<Transaction> GetTransactions();


        #endregion

        #region Delete

        /// <summary>
        /// Deletes a Given Injury from the Database.
        /// </summary>
        /// <param name="injury">Injury</param>
        void Delete(Injury injury);

        /// <summary>
        /// Deletes a Given Player from the Database.
        /// </summary>
        /// <param name="player">Player</param>
        void Delete(Player player);

        /// <summary>
        /// Deletes a Player Stat from the Database.
        /// </summary>
        /// <param name="playerStat">Player Stat</param>
        void Delete(PlayerStat playerStat);

        /// <summary>
        /// Deletes a Roster Entry from the Database.
        /// </summary>
        /// <param name="rosterEntry">Roster Enry</param>
        void Delete(RosterEntry rosterEntry);

        /// <summary>
        /// Deletes a Schedule Entry from the Database.
        /// </summary>
        /// <param name="scheduleEntry">Schedule Entry</param>
        void Delete(ScheduleEntry scheduleEntry);

        /// <summary>
        /// Deletes a Team from the Database.
        /// </summary>
        /// <param name="team">Team</param>
        void Delete(Team team);

        /// <summary>
        /// Deletes a Team Stat from the Database.
        /// </summary>
        /// <param name="teamStat">Team Stat</param>
        void Delete(TeamStat teamStat);

        /// <summary>
        /// Deletes a Transaction from the Database.
        /// </summary>
        /// <param name="transaction">Transaction</param>
        void Delete(Transaction transaction);

        #endregion

        #region Exists

        /// <summary>
        /// Determines if the given Entry Exists in the Database.
        /// </summary>
        /// <param name="injury">Injury</param>
        /// <returns>bool</returns>
        bool Exists(Injury injury);

        /// <summary>
        /// Determines if a given Player exists in the Database.
        /// </summary>
        /// <param name="player">Player</param>
        /// <returns>bool</returns>
        bool Exists(Player player);

        /// <summary>
        /// Determines if a Player Stat exists in the Database.
        /// </summary>
        /// <param name="playerStat">Player Stat</param>
        /// <returns>bool</returns>
        bool Exists(PlayerStat playerStat);

        /// <summary>
        /// Determines if a Roster Entry exists in the Database.
        /// </summary>
        /// <param name="rosterEntry">Roster Entry</param>
        /// <returns>bool</returns>
        bool Exists(RosterEntry rosterEntry);

        /// <summary>
        /// Determines if a Schedule Entry exists in the Database.
        /// </summary>
        /// <param name="scheduleEntry">Schedule Entry</param>
        /// <returns>bool</returns>
        bool Exists(ScheduleEntry scheduleEntry);

        /// <summary>
        /// Determines if a Team exists in the Database.
        /// </summary>
        /// <param name="team">Team</param>
        /// <returns>bool</returns>
        bool Exists(Team team);

        /// <summary>
        /// Determines if a Team Stat exists in the Database.
        /// </summary>
        /// <param name="teamStat">Team Stat</param>
        /// <returns>bool</returns>
        bool Exists(TeamStat teamStat);

        /// <summary>
        /// Determines if a Transaction exists in the Database.
        /// </summary>
        /// <param name="transaction">Transaction</param>
        /// <returns>bool</returns>
        bool Exists(Transaction transaction);

        #endregion

    }
}
