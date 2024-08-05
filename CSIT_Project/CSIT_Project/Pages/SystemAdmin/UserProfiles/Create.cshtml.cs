using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using CSIT_Project.Pages.Entities;
using System.Security.Cryptography;
using CSIT_Project.Pages.NewControllers.SystemAdmin;

namespace CSIT_Project.Pages.UserProfiles
{
    public class CreateModel : PageModel
    {
        public string profile;
        public string description;
        public String errorMessage = "";
        public String successMessage = "";
        public int test;

        public void OnGet()
        {
        }

        public void OnPost()
        {
            CreateProfile();
        }

        protected void CreateProfile()
        {
            profile = Request.Form["profile"];
            description = Request.Form["description"];

            if (profile.Length == 0 || description.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }
            else 
            {
                int success = new CreateUserProfileController().createUserProfile(profile, description);
                if (success == 1)
                {
                    // Set a flag in TempData to indicate a successful operation
                    TempData["CreateMessage"] = "New Profile added";
                    Response.Redirect("/SystemAdmin/UserProfiles/Index");
                }
                else if (success == 0) {
                    errorMessage = "Email entered already exists.";
                }
            }
        }
    }
}
