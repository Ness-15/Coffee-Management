using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers
{
    public class LogoutController
    {
        public int Logout()
        {
            UserAccount Logout = new UserAccount();
            int success = Logout.Logout();
            return success;
        }
    }
}
