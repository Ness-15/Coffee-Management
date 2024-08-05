using CSIT_Project.Pages.Entities;
using CSIT_Project.Pages.NewControllers.CafeStaff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSIT_Project.Pages.CafeStaff
{
    public class EditBidModel : PageModel
    {
        public UserAccount currentUser = new UserAccount();
        public List<WorkSlot> listWorkSlots = new List<WorkSlot>();
        public string Search { get; set; }
        public int maxWeeks;
        public ViewWorkSlotController workSlotController = new ViewWorkSlotController();

        public string workslotId;

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

            viewWorkSlot();

        }

        public void OnPost()
        {
            int success = editBid();
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

        protected void viewWorkSlot()
        {
            maxWeeks = workSlotController.GetMaxWeeksFromDatabase();
            listWorkSlots.Clear();
            listWorkSlots = workSlotController.viewAllWorkSlots();
        }

        public int editBid()
        {
            String useraccountId = HttpContext.Session.GetString("id");
            workslotId = Request.Form["workslotId"];
            String id = Request.Query["id"];

            int success = new EditBidController().editBid(id, useraccountId, workslotId);

            Response.Redirect("/CafeStaff/ViewBid");
            return success;
        }
    }
}
