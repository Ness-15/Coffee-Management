using CSIT_Project.Pages.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CSIT_Project.Pages.NewControllers.CafeOwner;

namespace CSIT_Project.Pages.WorkSlots
{
    public class CreateModel : PageModel
    {
        CreateWorkSlotController createWorkSlot = new CreateWorkSlotController();
        public string workRole;
        public string workDay;
        public string workWeek;
        public string startTime;
        public string endTime;
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            CreateWorkSlot();
        }

        public void CreateWorkSlot()
        {
            workRole = Request.Form["workRole"];
            workDay = Request.Form["workDay"];
            workWeek = Request.Form["workWeek"];
            startTime = Request.Form["startTime"];
            endTime = Request.Form["endTime"];

            if (workRole.Length == 0 || workDay.Length == 0 || workWeek.Length == 0
                || startTime.Length == 0 || endTime.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            string role = workRole.Trim();
            role = role.ToLower();
            if (!(role.Equals("chef") || role.Equals("waiter") || role.Equals("cashier")))
            {
                errorMessage = "Please enter 'Chef', 'Waiter' or 'Cashier' for work role.";
                return;
            }

            int success = createWorkSlot.createWorkSlot(workRole, workDay, workWeek, startTime, endTime);

            if (success == 1)
            {
                // Set a flag in TempData to indicate a successful operation
                TempData["CreateMessage"] = "New Work Slot added";
            }

            Response.Redirect("/CafeOwner/WorkSlots/Index");
        }
    }
}

