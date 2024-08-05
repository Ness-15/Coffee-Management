using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using CSIT_Project.Pages.Entities;
using System.Data;
using System.Globalization;
using CSIT_Project.Pages.NewControllers.SystemAdmin;

namespace CSIT_Project.Pages.UserProfiles
{
    public class EditModel : PageModel
    {
        public UserProfile userProfile = new UserProfile();
        public string id;
        public string profile;
        public string description;
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            GetUserProfile();
        }

        public void OnPost()
        {  
            EditUserProfile();    
        }

        public void GetUserProfile()
        {
             id = Request.Query["id"];
            userProfile = userProfile.getUserProfile(id);
        }

        public void EditUserProfile()
        {
            id = Request.Query["id"];
            profile = Request.Form["profile"];
            description = Request.Form["description"];

            if (profile.Length == 0 || description.Length == 0)
            {
                errorMessage = "All the fields are required";
            }
            else
            {
                int success = new EditUserProfileController().editUserProfile(id, profile, description);
                if (success == 1)
                {
                    // Set a flag in TempData to indicate a successful operation
                    TempData["EditMessage"] = "Edited role info";
                    Response.Redirect("/SystemAdmin/UserProfiles/Index");
                }
                else if (success == 0)
                {
                    errorMessage = "The profile entered already exists.";
                }
            }
        }

    }
}

