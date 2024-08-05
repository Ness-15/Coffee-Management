using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.CafeStaff
{
    public class DeleteBidController
    {
        public int deleteBid(string id)
        {
            StaffBid staffBid = new StaffBid();
            staffBid.id = id;
            int success = staffBid.deleteStaffBid();

            return success;
        }
    }
}
//test