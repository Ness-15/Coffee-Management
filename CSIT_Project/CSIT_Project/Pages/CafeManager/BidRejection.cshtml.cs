using CSIT_Project.Pages.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using CSIT_Project.Pages.NewControllers;

namespace CSIT_Project.Pages.CafeManager
{
    public class BidRejectionModel : PageModel
    {

        public void OnGet(string bidId)
        {
            rejectBid(bidId);
        }

        public void rejectBid(string staffbid)
        {
            BidRejectionController controller = new BidRejectionController();
            StaffBid bid = controller.viewProcessingStaffBids().FirstOrDefault(b => b.id.Equals(staffbid, StringComparison.OrdinalIgnoreCase));

            if (bid != null)
            {
                controller.changeBidStatus(bid, "rejected");
            }
            else
            {
                throw new KeyNotFoundException("Staff bid not found");
            }
        }
    }
}
