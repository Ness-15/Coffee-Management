using CSIT_Project.Pages.Controllers;
using CSIT_Project.Pages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SprintTests
{
    public class UnitTest_UseCase24
    {
        public UserAccountController userAccountController = new UserAccountController();

        [Fact]
        public void UseCase24_Test1() //delete invalid id
        {
            int success = new UserAccountController().deleteUserAccount("0");
            Assert.Equal(1, success);
        }

        [Fact]
        public void UseCase24_Test2() //passing test
        {
            int success = new UserAccountController().deleteUserAccount("12");
            Assert.Equal(1, success);
        }
    }
}
