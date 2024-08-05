using CSIT_Project.Pages.Controllers;
using CSIT_Project.Pages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SprintTests
{
    public class UnitTest_UseCase25
    {
        public UserAccountController userAccountController = new UserAccountController();

        [Fact]
        public void UseCase25_Test1() //using stafftype
        {
            string search = "system admin";

            List<UserAccount> result = userAccountController.searchUserAccount(search);

            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void UseCase25_Test2() //using email
        {
            string search = "bill.gates@microsoft.com";

            List<UserAccount> result = userAccountController.searchUserAccount(search);

            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void UseCase25_Test3() //using username
        {
            string search = "billgates";

            List<UserAccount> result = userAccountController.searchUserAccount(search);

            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void UseCase25_Test4() //using address
        {
            string search = "usa";

            List<UserAccount> result = userAccountController.searchUserAccount(search);

            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }


        [Fact]
        public void UseCase25_Test5() // search not found
        {
            string search = "nonexistent role";

            List<UserAccount> result = userAccountController.searchUserAccount(search);

            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }
    }
}
