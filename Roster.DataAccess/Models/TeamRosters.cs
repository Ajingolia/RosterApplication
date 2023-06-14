using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.DataAccess.Models
{
    public partial class TeamRosters
    {
        public int PlayerID { get; set; }
        public string TeamName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Sport { get; set; }
        public string Position { get; set; }

        public TeamRosters(int playerID, string teamName, string firstName, string lastName, int age, string sport, string position)
        {
            PlayerID = playerID;
            TeamName = teamName;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Sport = sport;
            Position = position;
        }
        public TeamRosters()
        {
        }
    }
}
