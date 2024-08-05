using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using CSIT_Project.Pages.Entities;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using CSIT_Project.Pages.NewControllers;

namespace CSIT_Project.Pages.CafeManager
{
    public class ViewStaffsModel : PageModel
    {
        public List<UserAccount> listStaffs = new List<UserAccount>();
        public string search;
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
            listStaffs = viewCafeStaff();
            viewTotalWorkSlots(listStaffs);
        }

        public void OnPost()
        {
            search = Request.Form["SearchStaffs"];
            if (search == "")
                listStaffs = viewCafeStaff();
            else
                listStaffs = searchCafeStaff(search);
            viewTotalWorkSlots(listStaffs);
        }

        public List<UserAccount> viewCafeStaff()
        {
            ViewCafeStaffController controller = new ViewCafeStaffController();
            List<UserAccount> list = controller.viewStaff();
            return list;
        }

        public List<UserAccount> viewTotalWorkSlots(List<UserAccount> list)
        {
            ViewStaffTotalWorkSlotsController controller = new ViewStaffTotalWorkSlotsController();
            controller.getTotalWorkSlots(list);
            return list;
        }

        public List<UserAccount> searchCafeStaff(string search) 
        {
            SearchCafeStaffController controller = new SearchCafeStaffController();
            List<UserAccount> list = controller.searchStaff(search);
            return list;
        }
    }
}
