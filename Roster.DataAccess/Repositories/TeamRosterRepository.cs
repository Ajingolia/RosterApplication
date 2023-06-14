using Roster.DataAccess.Context;
using Roster.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;


namespace Roster.DataAccess.Repositories
{
    public class TeamRosterRepository
    {
        private TeamRosterDbContext _dbContext;
        public TeamRosterRepository(TeamRosterDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(TeamRosters roster)
        {
            _dbContext.Add(roster);
            _dbContext.SaveChanges();

            return roster.PlayerID;
        }
        public int Update(TeamRosters roster)
        {
            TeamRosters existingRoster = _dbContext.Rosters.Find(roster.PlayerID);

            existingRoster.TeamName = roster.TeamName;
            existingRoster.FirstName = roster.FirstName;
            existingRoster.LastName = roster.LastName;
            existingRoster.Age = roster.Age;
            existingRoster.Sport = roster.Sport;
            existingRoster.Position = roster.Position;

            _dbContext.SaveChanges();

            return existingRoster.PlayerID;
        }
        public bool Delete(int PlayerID)
        {
            TeamRosters roster = _dbContext.Rosters.Find(PlayerID);
            _dbContext.Remove(roster);
            _dbContext.SaveChanges();

            return true;
        }
        public List<TeamRosters> GetAllRosters()
        {
            List<TeamRosters> RosterList = _dbContext.Rosters.ToList();

            return RosterList;
        }
        public TeamRosters GetRostersByID(int PlayerID)
        {
            TeamRosters roster = _dbContext.Rosters.Find(PlayerID);

            return roster;
        }
    }
}
