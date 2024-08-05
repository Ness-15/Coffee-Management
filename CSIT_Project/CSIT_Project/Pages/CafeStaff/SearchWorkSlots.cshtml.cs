using CSIT_Project.Pages.Entities;
using CSIT_Project.Pages.NewControllers.CafeStaff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSIT_Project.Pages.CafeStaff
{
    public class SearchWorkSlotsModel : PageModel
    {
        public List<WorkSlot> listWorkSlots = new List<WorkSlot>();

        public string search;
        public void OnGet()
        {
        }
        public void OnPost()
        {
            searchWorkSlot();
        }

        protected void searchWorkSlot() {
            SearchWorkSlotsController searchWorkSlot = new SearchWorkSlotsController();
            search = Request.Form["SearchWorkSlot"];
            if (search == "")
                listWorkSlots.Clear();
            else
                listWorkSlots = searchWorkSlot.SearchWorkSlot(search);
        }
    }
}
