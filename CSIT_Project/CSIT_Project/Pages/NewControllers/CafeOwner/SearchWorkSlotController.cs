using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.CafeOwner
{
    public class SearchWorkSlotController
    {
        public List<WorkSlot> SearchWorkSlot(string search)
        {
            return new WorkSlot().SearchWorkSlot(search);
        }
    }
}
