using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using CSIT_Project.Pages.Entities;
using CSIT_Project.Pages.NewControllers.SystemAdmin;

namespace CSIT_Project.Pages.UserAccounts
{
    public class EditModel : PageModel
    {
        public UserAccount userInfo = new UserAccount();
        public string id;
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
            GetUserInfo();
        }

        public void OnPost()
        {
            EditUserAccount();
        }

        public void EditUserAccount()
        {
            userInfo.id = Request.Form["id"];
            userInfo.username = Request.Form["username"];
            userInfo.password = Request.Form["password"];
            userInfo.name = Request.Form["name"];
            userInfo.email = Request.Form["email"];
            userInfo.phone = Request.Form["phone"];
            userInfo.address = Request.Form["address"];
            userInfo.stafftypeId = Int32.Parse(Request.Form["stafftype"]);
            if (userInfo.stafftypeId == 3)
                userInfo.role = Request.Form["role"];
            else
                userInfo.role = "";


            if (userInfo.id.Length == 0 || userInfo.username.Length == 0 || userInfo.password.Length == 0 || userInfo.name.Length == 0
                || userInfo.email.Length == 0 || userInfo.phone.Length == 0 || userInfo.address.Length == 0)
            {
                errorMessage = "All the fields are required";
            }
            else
            {
                int success = new EditUserAccountController().editUserAccount(userInfo);
                if (success == 1)
                {
                    TempData["EditMessage"] = "User successfully edited";
                    Response.Redirect("/SystemAdmin/UserAccounts/Index");
                }
                else if (success == 0)
                    errorMessage = "Email entered already exists";
            }
        }

        public void GetUserInfo()
        {
            String id = Request.Query["id"];
            userInfo = userInfo.getUserInfo(id);
        }

    }
}
