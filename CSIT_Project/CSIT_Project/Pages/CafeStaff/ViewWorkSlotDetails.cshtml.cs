using CSIT_Project.Pages.Entities;
using CSIT_Project.Pages.NewControllers.CafeStaff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;

namespace CSIT_Project.Pages.CafeStaff
{
    public class Index1Model : PageModel
    {
        // Define the WorkSlotDetails property to hold the details
        public WorkSlot WorkSlotDetails { get; set; }

        public void OnGet(string workRole, string startTime, string workDay, int workWeek)
        {
            viewRoleWorkSlot(workRole, startTime, workDay, workWeek);
        }

        public void viewRoleWorkSlot(string workRole, string startTime, string workDay, int workWeek)
        {
            WorkSlotDetails = new ViewWorkSlotDetailsController().viewWorkSlotDetails(workRole, startTime, workDay, workWeek);
        }
    }
}