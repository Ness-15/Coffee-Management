using CSIT_Project.Pages.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CSIT_Project.Pages.NewControllers.CafeOwner;

namespace CSIT_Project.Pages.WorkSlots
{
    public class SearchWorkSlotsModel : PageModel
    {
        public List<WorkSlot> listWorkSlots = new List<WorkSlot>();
        public SearchWorkSlotController searchWorkSlot = new SearchWorkSlotController();
        public string search;
        public void OnGet()
        {
        }
        public void OnPost()
        { 
            SearchWorkSlot();
        }

        public void SearchWorkSlot()
        {
            search = Request.Form["SearchWorkSlot"];

            if (search == "")
                listWorkSlots.Clear();
            else
                listWorkSlots = searchWorkSlot.SearchWorkSlot(search);
        }
    }
}
