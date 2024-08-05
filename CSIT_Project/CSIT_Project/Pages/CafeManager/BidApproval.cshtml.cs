using CSIT_Project.Pages.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.Json;
using CSIT_Project.Pages.NewControllers;

namespace CSIT_Project.Pages.CafeManager
{
    public class BidApprovalModel : PageModel
    {

        public void OnGet(string workslotId, string bidId)
        {
            ApproveBid(workslotId, bidId);
        }


        public void ApproveBid(string workslotId, string staffbid)
        {
            BidApprovalController controller = new BidApprovalController();
            StaffBid bid = controller.viewProcessingStaffBids().FirstOrDefault(b => b.id.Equals(staffbid, StringComparison.OrdinalIgnoreCase));

            if (bid != null)
            {
                controller.changeBidStatus(bid, "approved");
            }
            else
            {
                throw new KeyNotFoundException("Staff bid not found");
            }

            WorkSlot workSlot = controller.viewAllWorkSlots().FirstOrDefault(ws => ws.id.Equals(workslotId, StringComparison.OrdinalIgnoreCase));

            if (workSlot != null)
            {
                if (int.TryParse(bid.useraccountId, out int intUserAccountId))
                {
                    controller.setStaffAllocated(workSlot, intUserAccountId);
                }
                else
                {
                    throw new ArgumentException("Invalid useraccountId");
                }
            }
            else
            {
                throw new KeyNotFoundException("Workslot not found");
            }
        }

    }
}
