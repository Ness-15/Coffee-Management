using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using CSIT_Project.Pages.Entities;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using CSIT_Project.Pages.NewControllers.SystemAdmin;
using CSIT_Project.Pages.CafeStaff;

namespace CSIT_Project.Pages.UserAccounts
{
    public class IndexModel : PageModel
    {
        public List<UserAccount> listUsers = new List<UserAccount>();
        public string search = "";
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
            ViewUsers();
        }

        public void OnPost()
        {
            SearchUsers();
        }

        public void ViewUsers()
        {
                listUsers = new ViewUserAccountController().viewUserAccount();
        }

        public void SearchUsers()
        {
            search = Request.Form["SearchUserAccount"];
            if (search == "")
                ViewUsers();
            else
            listUsers = new SearchUserAccountController().searchUserAccount(search);
        }
    }
}
