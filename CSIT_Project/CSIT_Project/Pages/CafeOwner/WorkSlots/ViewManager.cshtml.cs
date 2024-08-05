using CSIT_Project.Pages.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Diagnostics;
using CSIT_Project.Pages.NewControllers.CafeOwner;

namespace CSIT_Project.Pages.WorkSlots
{
    public class ViewManagerModel : PageModel
    {
        ViewManagersController viewManager = new ViewManagersController();
        public List<UserAccount> listManagers = new List<UserAccount>();
        public void OnGet()
        {
            ViewManagers();
        }

        public void ViewManagers()
        {
            listManagers = viewManager.viewManager();
        }
    }
}
