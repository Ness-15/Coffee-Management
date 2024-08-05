using CSIT_Project.Pages.Entities;
using CSIT_Project.Pages.CafeManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using CSIT_Project.Pages.NewControllers;

namespace CSIT_Project.Pages.CafeManager
{
    public class ViewStaffBidModel : PageModel
    {
        public List<StaffBid> listCompletedStaffBids { get; set; } = new List<StaffBid>();
        public List<StaffBid> listProcessingStaffBids { get; set; } = new List<StaffBid>();
   
        public void OnGet()
        {
            viewStaffBids();
        }

        public void viewStaffBids()
        {
            ViewStaffBidController controller = new ViewStaffBidController();
            listProcessingStaffBids = controller.viewProcessingStaffBids();
            listCompletedStaffBids = controller.viewCompletedStaffBids();
        }


    }
}
