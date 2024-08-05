using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.CafeStaff
{
    public class ViewBidController
    {
        public List<StaffBid> viewBid(String useraccountId)
        {
            StaffBid staffBid = new StaffBid();
            staffBid.useraccountId = useraccountId;
            return staffBid.ViewMyBids();
        }
    }
}