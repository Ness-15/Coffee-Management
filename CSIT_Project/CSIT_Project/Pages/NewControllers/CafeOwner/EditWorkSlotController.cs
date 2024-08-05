using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.CafeOwner
{
    public class EditWorkSlotController
    {
        public int editWorkSlot(WorkSlot workslot)
        {
            string[] validWorkRoles = { "Chef", "Cashier", "Waiter" };
            string[] validWorkDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            bool inWorkRole = validWorkRoles.Contains(workslot.workRole);
            bool inWorkDay = validWorkDays.Contains(workslot.workDay);
            
            if (inWorkRole && inWorkRole)
            {
                int success = workslot.editWorkSlot();
                return success;
            }
            else
            {
                return 0;
            }
        }
    }
}
