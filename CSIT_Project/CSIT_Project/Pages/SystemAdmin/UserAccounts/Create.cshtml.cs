using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using CSIT_Project.Pages.Entities;
using CSIT_Project.Pages.NewControllers.SystemAdmin;
using Azure.Identity;

namespace CSIT_Project.Pages.UserAccounts
{
    public class CreateModel : PageModel
    {
        public string username;
        public string password;
        public string name;
        public string email;
        public string phone;
        public string address;
        public int stafftypeId;
        public string role = "";
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            CreateUserAccount();
        }

        public void CreateUserAccount()
        {
            username = Request.Form["username"];
            password = Request.Form["password"];
            name = Request.Form["name"];
            email = Request.Form["email"];
            phone = Request.Form["phone"];
            address = Request.Form["address"];
            stafftypeId = Int32.Parse(Request.Form["stafftype"]);

            if (stafftypeId == 3)
                role = Request.Form["role"];

            if (username.Length == 0 || password.Length == 0 || name.Length == 0
                || email.Length == 0 || phone.Length == 0 || address.Length == 0)
            {
                errorMessage = "All the fields are required";
            }
            else
            {
                int success = new CreateUserAccountController().createUserAccount(username, password, name, email, phone, address, stafftypeId, role);
                if (success == 1)
                {
                    // Set a flag in TempData to indicate a successful operation
                    TempData["CreateMessage"] = "New User added";
                    Response.Redirect("/SystemAdmin/UserAccounts/Index");
                }
                else if (success == 0)
                {
                    errorMessage = "Email entered already exists.";
                }
            }
        }

    }
}
