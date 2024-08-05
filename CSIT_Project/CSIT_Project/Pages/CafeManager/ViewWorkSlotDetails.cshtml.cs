using CSIT_Project.Pages.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;
using CSIT_Project.Pages.NewControllers;

namespace CSIT_Project.Pages.CafeManager
{
    public class Index1Model : PageModel
    {
        // Define the WorkSlotDetails property to hold the details
        public WorkSlot WorkSlotDetails { get; set; }

        public void OnGet(string workRole, string startTime, string workDay, int workWeek)
        {
            WorkSlotDetails = viewWorkSlotDetails(workRole, startTime, workDay, workWeek);
        }

        public WorkSlot viewWorkSlotDetails(string workRole, string startTime, string workDay, int workWeek)
        {
            ViewWorkSlotDetailsController controller = new ViewWorkSlotDetailsController();
            return controller.viewWorkSlotDetails(workRole, startTime, workDay, workWeek);
        }
    }
}