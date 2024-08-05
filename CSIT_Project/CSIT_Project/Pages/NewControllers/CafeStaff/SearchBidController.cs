using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.CafeStaff
{
    public class SearchBidController
    {
        public List<StaffBid> searchBid(string search, string useraccountId)
        {
            StaffBid staffbid = new StaffBid();
            staffbid.useraccountId = useraccountId;
            return staffbid.searchMyBid(search);
        }
    }
}
//test