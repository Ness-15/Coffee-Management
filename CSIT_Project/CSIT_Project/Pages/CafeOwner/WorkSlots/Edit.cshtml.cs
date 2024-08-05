using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using CSIT_Project.Pages.Entities;
using CSIT_Project.Pages.NewControllers.CafeOwner;

namespace CSIT_Project.Pages.WorkSlots
{
    public class EditModel : PageModel
    {
        public WorkSlot workSlot = new WorkSlot();
        EditWorkSlotController editWorkSlot = new EditWorkSlotController();
        public string workRole;
        public string workDay;
        public string workWeek;
        public string startTime;
        public string endTime;
        public String id;
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            GetWorkSlots();
        }

        public void OnPost()
        {
            EditWorkSlots();
        }

        public void EditWorkSlots()
        {
            workSlot.id = Request.Form["id"];
            workSlot.workRole = Request.Form["workRole"];
            workSlot.workDay = Request.Form["workDay"];
            workSlot.workWeek = Request.Form["workWeek"];
            workSlot.startTime = Request.Form["startTime"];
            workSlot.endTime = Request.Form["endTime"];

            if (workSlot.id.Length == 0 || workSlot.workRole.Length == 0 || workSlot.workDay.Length == 0 || workSlot.workWeek.Length == 0
                || workSlot.startTime.Length == 0 || workSlot.endTime.Length == 0)
            {
                errorMessage = "All the fields are required";
                GetWorkSlots();
                return;
            }

            string role = workSlot.workRole.Trim();
            role = role.ToLower();
            if (!(role.Equals("chef") || role.Equals("waiter") || role.Equals("cashier")))
            {
                errorMessage = "Please enter 'Chef', 'Waiter' or 'Cashier' for work role.";
                return;
            }

            int success = editWorkSlot.editWorkSlot(workSlot);

            //clear fields and display success message
            if (success == 1)
            {
                // Set a flag in TempData to indicate a successful operation
                TempData["EditMessage"] = "Work Slot Updated";
            }
            Response.Redirect("/CafeOwner/WorkSlots/Index");
        }

        public void GetWorkSlots()
        {
            String id = Request.Query["id"];
            workSlot = workSlot.getWorkSlot(id);
        }
    }
}
