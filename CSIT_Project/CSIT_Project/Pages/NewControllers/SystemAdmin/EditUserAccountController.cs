using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.SystemAdmin
{
    public class EditUserAccountController
    {
        public int editUserAccount(UserAccount userInfo)
        {
            UserAccount tempUser = new UserAccount();
            tempUser = tempUser.getUserInfo(userInfo.id);

            bool emailUnique = false;
            int success = 0;

            if (!(tempUser.email.Equals(userInfo.email)))
                emailUnique = tempUser.IsMailUnique(userInfo.email);

            if (emailUnique == false)
            {
                success = userInfo.editUserAccount();
            }
            return success;
        }
    }
}
