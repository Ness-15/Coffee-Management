using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.SystemAdmin
{
    public class ViewUserAccountController
    {
        public List<UserAccount> viewUserAccount()
        {
            UserAccount userAccount = new UserAccount();
            List<UserAccount> allUserAccounts =  userAccount.ViewUserAccount();
            return allUserAccounts;
        }
    }
}
