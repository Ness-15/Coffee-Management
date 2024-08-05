using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.SystemAdmin
{
    public class DeleteUserAccountController
    {
        public int deleteUserAccount(string id)
        {
            UserAccount userInfo = new UserAccount();
            userInfo = userInfo.getUserInfo(id);
            if (userInfo.email == "")
                return 0;
            int success = userInfo.deleteUserAccount(id);
            return success;
        }
    }
}
