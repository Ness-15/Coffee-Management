using CSIT_Project.Pages.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CSIT_Project.Pages.NewControllers;

namespace CSIT_Project.Pages.WorkSlots.CafeManager
{
    public class SearchWorkSlotModel : PageModel
    {
        public List<WorkSlot> listWorkSlots = new List<WorkSlot>();
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
            SearchWorkSlotController controller = new SearchWorkSlotController();
            search = Request.Form["SearchWorkSlot"];

            if (search == "")
                listWorkSlots.Clear();
            else
                listWorkSlots = controller.SearchWorkSlot(search);
        }
    }
}
