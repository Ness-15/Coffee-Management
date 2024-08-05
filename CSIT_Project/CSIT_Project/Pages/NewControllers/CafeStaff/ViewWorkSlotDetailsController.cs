using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.CafeStaff
{
    public class ViewWorkSlotDetailsController
    {
        public WorkSlot viewWorkSlotDetails(string workRole, string startTime, string workDay, int workWeek)
        {
            WorkSlot workSlot = new WorkSlot();
            workSlot.setWorkRole(workRole);
            workSlot.setStartTime(startTime);
            workSlot.setWorkDay(workDay);
            workSlot.setWorkWeek(workWeek);
            workSlot = workSlot.viewWorkSlotDetails();

            return workSlot;
        }
    }
}
