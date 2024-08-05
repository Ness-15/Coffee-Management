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
    public class UnitTest_UseCase21
    {
        [Fact]
        public void UserStory21Test1()
        {
            //using not UNIQUE email
            UserAccountController useraccount = new UserAccountController();
            int success = useraccount.createUserAccount("test1", "1234", "test1", "test1@spacex.com", "12345678", "test1", 1, "");
            Assert.Equal(1, success);
        }

        [Fact]
        public void UserStory21Test2()
        {
            //invalid stafftype
            UserAccountController useraccount = new UserAccountController();
            int success = useraccount.createUserAccount("test2", "1234", "test2", "test2@spacex.com", "12345678", "test2", 0, "");
            Assert.Equal(1, success);
        }

        [Fact]
        public void UserStory21Test3()
        {
            UserAccountController useraccount = new UserAccountController();
            int success = useraccount.createUserAccount("test3", "1234", "test3", "test3@spacex.com", "12345678", "test3", 1, "");
            Assert.Equal(1, success);
        }
    }
}