using CSIT_Project.Pages.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CSIT_Project.Pages.NewControllers.CafeOwner;


namespace CSIT_Project.Pages.WorkSlots
{
    public class ViewWorkSlotDetailsModel : PageModel
    {
        public WorkSlot WorkSlotDetails { get; set; }

        public void OnGet(string workRole, string startTime, string workDay, int workWeek, ViewWorkSlotDetailsController viewDetailController)
        {
            ViewWorkSlotDetails(workRole, startTime, workDay, workWeek, viewDetailController);
        }

        public void ViewWorkSlotDetails(string workRole, string startTime, string workDay, int workWeek, ViewWorkSlotDetailsController viewDetailController)
        {
            WorkSlotDetails = viewDetailController.viewWorkSlotDetails(workRole, startTime, workDay, workWeek);
        }
    }
}
