using CSIT_Project.Pages.Controllers;
using CSIT_Project.Pages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SprintTests
{
    public class UnitTest_UseCase23
    {
        public UserAccountController userAccountController = new UserAccountController();

        [Fact]
        public void UseCase23_Test1() //missing inputs
        {
            
            UserAccount test = new UserAccount();            
            int success = new UserAccountController().editUserAccount(test);
            Assert.Equal(1, success);
        }

        [Fact]
        public void UseCase23_Test2() //invalid stafftypeId
        {
            UserAccount test = new UserAccount();
            test.id = "12";
            test.username = "test";
            test.password = "test";
            test.name = "test";
            test.email = "testing@gmail.com";
            test.phone = "1234567890";
            test.address = "testing";
            test.stafftypeId = 0;
            int success = new UserAccountController().editUserAccount(test);
            Assert.Equal(1, success);
        }

        [Fact]
        public void UseCase23_Test3() //passing test
        {
            UserAccount test = new UserAccount();
            test.id = "12";
            test.username = "test";
            test.password = "test";
            test.name = "test";
            test.email = "testing@gmail.com";
            test.phone = "1234567890";
            test.address = "testing";
            test.stafftypeId = 1;
            int success = new UserAccountController().editUserAccount(test);
            Assert.Equal(1, success);
        }
    }
}
