using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.CafeOwner
{
    public class ViewManagersController
    {
        public List<UserAccount> viewManager()
        {
            List<UserAccount> listManagers = new List<UserAccount>();
            listManagers = new UserAccount().viewManager();
            return listManagers;

        }
    }
}
