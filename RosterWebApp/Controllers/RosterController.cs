using Microsoft.AspNetCore.Mvc;
using Roster.DataAccess.Context;
using Roster.DataAccess.Models;
using ClubSports.Models;

namespace ClubSports.Controllers
{
    public class RosterController : Controller
    {
        private readonly TeamRosterDbContext _context;
        public RosterController (TeamRosterDbContext context)
        {
            _context = context;
        }
     
        public IActionResult Index()
        {
            RosterViewModel Waffles = new RosterViewModel(_context);
            return View(Waffles);
        }
        [HttpPost]
        public IActionResult Index(int playerId, string teamName, string firstName, string lastName, int age, string sport, string position)
        {
            RosterViewModel model = new RosterViewModel(_context);
            TeamRosters roster = new(playerId, teamName, firstName , lastName, age, sport, position);

            model.SaveRoster(roster);
            model.IsActionSuccess = true;
            model.ActionMessage = "Roster has been saved successfully.";

            return View(model);
        }
        public IActionResult Update(int id)
        {
            RosterViewModel model = new RosterViewModel(_context, id);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            RosterViewModel model = new RosterViewModel(_context);

            if(id>0)
            {
                model.RemoveRoster(id);
            }
            model.IsActionSuccess = true;
            model.ActionMessage = "Roster has beed deleted successfully.";
            return View("Index", model);
        }
    }
}
