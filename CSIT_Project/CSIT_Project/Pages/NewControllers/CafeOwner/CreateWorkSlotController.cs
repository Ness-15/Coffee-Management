using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.CafeOwner
{
    public class CreateWorkSlotController
    {
        public int createWorkSlot(string workRole, string workDay, string workWeek, string startTime, string endTime)
        {
            string[] validWorkRoles = { "Chef", "Cashier", "Waiter" };
            string[] validWorkDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            bool inWorkRole = validWorkRoles.Contains(workRole);
            bool inWorkDay = validWorkDays.Contains(workDay);


            // Validate workRole
            if (!inWorkRole)
            {
                return 0;
            }

            // Validate workDay
            if (!inWorkDay)
            {
                return 0;
            }

            WorkSlot workslot = new WorkSlot();
            workslot.workRole = workRole;
            workslot.workDay = workDay;
            workslot.workWeek = workWeek;
            workslot.startTime = startTime;
            workslot.endTime = endTime;
            int success = workslot.createWorkSlot();
            if (success == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
