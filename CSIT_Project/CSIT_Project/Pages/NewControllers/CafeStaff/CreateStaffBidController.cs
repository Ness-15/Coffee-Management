using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.CafeStaff
{
    public class CreateStaffBidController
    {
        public int createStaffBid(String workslotId, String useraccountId)
        {
            //create workslot and useraccount objects
            UserAccount currentUser = new UserAccount();
            currentUser = currentUser.getUserInfo(useraccountId);
            WorkSlot currentWorkslot = new WorkSlot();
            currentWorkslot = currentWorkslot.getWorkSlot(workslotId);

            //verify if user role and workslot role is same
            String workRole = currentWorkslot.workRole.ToLower();

            if (workRole.Equals(currentUser.role))
            {

                StaffBid newBid = new StaffBid(workslotId, useraccountId);
                newBid.createStaffBid();
                return 1;
            }
            return 0;
        }
    }
}
//test