using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.CafeStaff
{
    public class SearchWorkSlotsController
    {
        public List<WorkSlot> SearchWorkSlot(string search)
        {
            return new WorkSlot().SearchWorkSlot(search);
        }
    }
}
//test