using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.CafeStaff
{
    public class EditBidController
    {
        public int editBid(string id, string useraccountId, string workslotId)
        {
            StaffBid staffbid = new StaffBid();
            staffbid.id = id;
            staffbid.useraccountId = useraccountId;
            staffbid.workslotId = workslotId;
            int success = staffbid.editStaffBid();
            return success;
        }
    }
}
//test