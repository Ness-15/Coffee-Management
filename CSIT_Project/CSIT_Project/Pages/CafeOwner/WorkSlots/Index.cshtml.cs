using CSIT_Project.Pages.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CSIT_Project.Pages.NewControllers.CafeOwner;

namespace CSIT_Project.Pages.WorkSlots
{
    public class IndexModel : PageModel
    {
        public List<WorkSlot> listWorkSlots = new List<WorkSlot>();
        public ViewWorkSlotController workSlotController = new ViewWorkSlotController();
        public int maxWeeks;
        public string search;
        public void OnGet()
        {
            // Retrieve user info from the session
            var id = HttpContext.Session.GetString("id");
            var stafftype = HttpContext.Session.GetString("stafftype");
            // Check if the user is logged in
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(stafftype))
            {
                Response.Redirect("/Index");
            }

            ViewWorkSlots();
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

        public void ViewWorkSlots()
        {
            MaxWeeks();
            listWorkSlots = workSlotController.viewAllWorkSlots();
        }

        public void MaxWeeks()
        {
            maxWeeks = workSlotController.GetMaxWeeksFromDatabase();
        }

    }
}
