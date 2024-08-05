using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.CafeOwner
{
    public class DeleteWorkSlotController
    {
        public int deleteWorkSlot(string id)
        {
            WorkSlot workslot = new WorkSlot();
            workslot.id = id;
            int success = workslot.deleteWorkSlot();
            if (success == 0)
            {
                return 0;
            }
            else
                return 1;
        }
    }
}
