using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Collections.Generic;
using System.Xml.Linq;
using System;
using CSIT_Project.Pages.Entities;
using CSIT_Project.Pages.NewControllers;

namespace CSIT_Project.Pages.CafeManager
{
    public class IndexModel : PageModel
    {
        public List<WorkSlot> listWorkSlots = new List<WorkSlot>();
        public int maxWeeks;
        
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
            listWorkSlots.Clear();
            ViewAllWorkSlotsController controller = new ViewAllWorkSlotsController();
            maxWeeks = controller.GetMaxWeeksFromDatabase();
            listWorkSlots = controller.viewAllWorkSlots();
        }
    }
}
