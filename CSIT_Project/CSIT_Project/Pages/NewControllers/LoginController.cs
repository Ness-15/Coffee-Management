using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers
{
    public class LoginController
    {
        public bool Login(String email, String password, String stafftype)
        {
            {
                UserAccount userInfo = new UserAccount();
                userInfo.password = password;
                userInfo.email = email;
                userInfo.stafftype = stafftype;
                bool success = userInfo.Login(email, password, stafftype);
                if (success == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
