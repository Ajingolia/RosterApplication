using Roster.DataAccess.Context;
using Roster.DataAccess.Models;
using Roster.DataAccess.Repositories;

namespace ClubSports.Models
{
    public class RosterViewModel
    {
        private TeamRosterRepository _repo;

        public List<TeamRosters> RosterList { get; set; }

        public TeamRosters CurrentRoster { get; set; }

        public bool IsActionSuccess { get; set; }

        public string ActionMessage { get; set; }

        public RosterViewModel(TeamRosterDbContext context)
        {
            _repo = new TeamRosterRepository(context);
            RosterList = GetAllRosters();
            CurrentRoster = RosterList.FirstOrDefault();
        }

        public RosterViewModel(TeamRosterDbContext context, int PlayerID)
        {
            _repo = new TeamRosterRepository(context);
            RosterList = GetAllRosters();

            if  (PlayerID > 0)
            {
                CurrentRoster = GetRoster(PlayerID);
            }
            else
            {
                CurrentRoster = new TeamRosters();
            }
        }

        public void SaveRoster(TeamRosters roster)
        {
            if (roster.PlayerID > 0)
            {
                _repo.Update(roster);
            }
            else
            {
                roster.PlayerID = _repo.Create(roster);
            }

            RosterList = GetAllRosters();
            CurrentRoster = GetRoster(roster.PlayerID);
        }

        public void RemoveRoster(int PlayerID)
        {
            _repo.Delete(PlayerID);
            RosterList = GetAllRosters();
            CurrentRoster = RosterList.FirstOrDefault();
        }

        public List<TeamRosters> GetAllRosters()
        {
            return _repo.GetAllRosters();
        }

        public TeamRosters GetRoster(int contactId)
        {
            return _repo.GetRostersByID(contactId);
        }
    }
}

