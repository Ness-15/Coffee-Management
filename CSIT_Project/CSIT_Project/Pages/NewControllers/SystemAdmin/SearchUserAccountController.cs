using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.SystemAdmin
{
    public class SearchUserAccountController
    {
        public List<UserAccount> searchUserAccount(string search)
        {
            List<UserAccount> list = new List<UserAccount>();
            if (!string.IsNullOrEmpty(search))
            {
                list = new UserAccount().SearchUserAccount(search);
            }
            return list;
        }
    }
}
