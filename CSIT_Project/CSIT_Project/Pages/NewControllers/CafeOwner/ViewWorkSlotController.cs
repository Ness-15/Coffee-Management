using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.CafeOwner
{
    public class ViewWorkSlotController
    {
        public List<WorkSlot> viewAllWorkSlots()
        {
            return new WorkSlot().ViewWorkSlot();
        }

        public int GetMaxWeeksFromDatabase()
        {
            return new WorkSlot().GetMaxWeeks();
        }


    }
}
