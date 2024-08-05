using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using CSIT_Project.Pages.Entities;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using CSIT_Project.Pages.NewControllers.CafeStaff;

namespace CSIT_Project.Pages.CafeStaff
{
    public class ViewBidModel : PageModel
    {
        public String useraccountId = "";
        public List<StaffBid> listStaffBids = new List<StaffBid>();
        public string search = "";
        public void OnGet()
        {
            viewBids();
        }

        public void OnPost()
        {
            searchMyBids();
        }

        public void viewBids()
        {
            useraccountId = HttpContext.Session.GetString("id");
            listStaffBids = new ViewBidController().viewBid(useraccountId);
        }

        public void searchMyBids()
        {
            useraccountId = HttpContext.Session.GetString("id");
            search = Request.Form["searchBid"];
            if (search.Equals(""))
                viewBids();
            else
                listStaffBids = new SearchBidController().searchBid(search, useraccountId);
        }
    }
}
