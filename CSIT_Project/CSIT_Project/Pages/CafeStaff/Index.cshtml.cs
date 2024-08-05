using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using CSIT_Project.Pages.Entities;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using CSIT_Project.Pages.NewControllers.CafeStaff;

namespace CSIT_Project.Pages.CafeStaff
{
    public class IndexModel : PageModel
    {
        public UserAccount currentUser = new UserAccount();
        public List<WorkSlot> listWorkSlots = new List<WorkSlot>();
        public string Search { get; set; }
        public int maxWeeks;
        public ViewWorkSlotController viewWorkSlotController = new ViewWorkSlotController();

        public void OnGet()
        {
            // Retrieve user info from the session
            currentUser.id = HttpContext.Session.GetString("id");
            currentUser = currentUser.getUserInfo(currentUser.id);
            var id = HttpContext.Session.GetString("id");
            var stafftype = HttpContext.Session.GetString("stafftype");

            // Check if the user is logged in
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(stafftype))
            {
                Response.Redirect("/Index");
            }

            //View all workslots
            viewWorkSlot();

        }

        public void OnPost()
        {
        }

        public string GetDayName(int day)
        {
            switch (day)
            {
                case 1:
                    return "Monday";
                case 2:
                    return "Tuesday";
                case 3:
                    return "Wednesday";
                case 4:
                    return "Thursday";
                case 5:
                    return "Friday";
                case 6:
                    return "Saturday";
                case 7:
                    return "Sunday";
                default:
                    return "Invalid Day";
            }
        }

        public void viewWorkSlot()
        {
            maxWeeks = viewWorkSlotController.GetMaxWeeksFromDatabase();
            listWorkSlots.Clear();
            listWorkSlots = viewWorkSlotController.viewAllWorkSlots();
        }
    }
}
