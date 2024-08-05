using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSIT_Project.Pages.Controllers;
using CSIT_Project.Pages.Entities;

namespace SprintTests
{
    public class UnitTest_UseCase14
    {
        public WorkSlotController workSlotController = new WorkSlotController();

        [Fact]
        public void UseCase14_Test1() // create workslot when input is valid (upper case)
        {
            string workRole = "Cashier";
            string workDay = "Wednesday";
            string workWeek = "" + 1;
            string startTime = "07:00:00";
            string endTime = "16:00:00";

            int result = workSlotController.createWorkSlot(workRole, workDay, workWeek, startTime, endTime);

            Assert.Equal(1, result); // success is represented by 1
        }

        [Fact]
        public void UseCase14_Test2() // create workslot when input is valid (lower case)
        {
            string workRole = "cashier";
            string workDay = "wednesday";
            string workWeek = "" + 1;
            string startTime = "07:00:00";
            string endTime = "16:00:00";

            int result = workSlotController.createWorkSlot(workRole, workDay, workWeek, startTime, endTime);

            Assert.Equal(1, result);
        }

        [Fact]
        public void UseCase14_Test3() // create workslot when input is invalid
        {
            // Arrange
            var workSlotController = new WorkSlotController(); // Replace with the actual class name
            // Set up test data for invalid input (e.g., duplicate work slot)
            string workRole = "TestRole";
            string workDay = "Someday";
            string workWeek = "" + 1;
            string startTime = "08:00";
            string endTime = "17:00";

            int result = workSlotController.createWorkSlot(workRole, workDay, workWeek, startTime, endTime);

            Assert.Equal(0, result); 
        }
    }
}
