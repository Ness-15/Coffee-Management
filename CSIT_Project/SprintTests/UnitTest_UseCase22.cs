using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CSIT_Project.Pages.Entities;
using CSIT_Project.Pages.Controllers;
using System.Data.SqlClient;
using System.IO;
using System.Numerics;
using System.Diagnostics.CodeAnalysis;

namespace SprintTests
{
    public class UnitTest_UseCase22
    {
        [Fact]
        public void UserStory22Test1()
        {
            UserAccountController useraccount = new UserAccountController();
            List<UserAccount> allUserAccounts = useraccount.viewUserAccount();
            int success = 0;
            if (allUserAccounts != null)
            {
                success = 1;
            }
            Assert.Equal(1, success);
        }
    }
}
