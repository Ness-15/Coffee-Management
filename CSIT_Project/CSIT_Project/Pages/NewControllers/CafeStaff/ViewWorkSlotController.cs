using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.CafeStaff
{
    public class ViewWorkSlotController
    {
        public int GetMaxWeeksFromDatabase()
        {
            return new WorkSlot().GetMaxWeeks();
        }

        public List<WorkSlot> viewAllWorkSlots()
        {
            return new WorkSlot().ViewWorkSlot();
        }
    }
}
//test