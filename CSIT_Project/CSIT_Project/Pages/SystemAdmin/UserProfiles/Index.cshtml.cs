using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CSIT_Project.Pages.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;
using CSIT_Project.Pages.NewControllers.SystemAdmin;

namespace CSIT_Project.Pages.UserProfiles

  
{
    public class IndexModel : PageModel
    {
        public string keyword;
        public List<UserProfile> listProfiles = new List<UserProfile>();

        public void OnGet()
        {
            // Retrieve user info from the session
            var id = HttpContext.Session.GetString("id");
            var stafftype = HttpContext.Session.GetString("stafftype");


            // Check if the user is logged in
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(stafftype))
            {
                Response.Redirect("/Index");
            }
            ViewUserProfile();
        }

        public void OnPost()
        {
            SearchUserProfile();
        }

        public void ViewUserProfile()
        {
            listProfiles = new ViewUserProfileController().viewUserProfile();
        }

        public void SearchUserProfile()
        {
            keyword = Request.Form["SearchUserProfile"];
            if (keyword == "")
                ViewUserProfile();
            else
                listProfiles = new SearchUserProfileController().searchUserProfile(keyword);
        }
    }
}
