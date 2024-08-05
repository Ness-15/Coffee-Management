using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSIT_Project.Pages.Controllers;
using CSIT_Project.Pages.Entities;
using Microsoft.AspNetCore.Routing;

namespace SprintTests
{
    public class UnitTest_UseCase201
    {
        public WorkSlotController workSlotController = new WorkSlotController();

        [Fact]
        public void UseCase201_Test1() // check that viewAllWorkSlot returns non null result
        {
            List<WorkSlot> result = workSlotController.viewAllWorkSlots();

            Assert.NotNull(result);
        }

        [Fact]
        public void UseCase201_Test2() // check that maxWeeks >= 0
        {
            int result = workSlotController.GetMaxWeeksFromDatabase();

            Assert.True(result >= 0);
        }

    }
}
