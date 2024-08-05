using CSIT_Project.Pages.Controllers;
using CSIT_Project.Pages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTests
{
    public class UnitTest_UseCase13
    {
        public WorkSlotController workSlotController = new WorkSlotController();

        [Fact]
        public void UseCase13_Test1() //view workslot details when workslot exists
        {
            string workRole = "Chef";
            string startTime = "08:00:00";
            string workDay = "Monday";
            int workWeek = 1;

            WorkSlot result = workSlotController.viewWorkSlotDetails(workRole, startTime, workDay, workWeek);

            Assert.NotNull(result);
            Assert.Equal(workRole, result.workRole);
            Assert.Equal(startTime, result.startTime);
            Assert.Equal(workDay, result.workDay);
            Assert.Equal(workWeek.ToString(), result.workWeek);
        }

        [Fact]
        public void UseCase13_Test2() // view workslot details when workslot does not exist
        {
            var workSlotController = new WorkSlotController(); // Replace with the actual class name
            // Set up test data for a non-existing work slot
            string workRole = "NonExistingRole";
            string startTime = "99:90";
            string workDay = "Everyday";
            int workWeek = -1;

            WorkSlot result = workSlotController.viewWorkSlotDetails(workRole, startTime, workDay, workWeek);

            Assert.NotNull(result);
            Assert.Equal(workRole, result.workRole);
            Assert.Equal(startTime, result.startTime);
            Assert.Equal(workDay, result.workDay);
            Assert.Equal(workWeek.ToString(), result.workWeek);
        }


    }
}
