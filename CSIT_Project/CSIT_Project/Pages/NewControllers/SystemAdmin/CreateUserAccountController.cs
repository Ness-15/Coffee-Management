using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.SystemAdmin
{
    public class CreateUserAccountController
    {
        public int createUserAccount(string username, string password, string name, string email, string phone, string address, int stafftypeId, string role)
        {
            UserAccount userInfo = new UserAccount();
            userInfo.username = username;
            userInfo.password = password;
            userInfo.name = name;
            userInfo.email = email;
            userInfo.phone = phone;
            userInfo.address = address;
            userInfo.stafftypeId = stafftypeId;
            userInfo.role = role;

            bool mailUnique = userInfo.IsMailUnique(email);
            int success = 0;

            if (mailUnique == false) {
                success = userInfo.createUserAccount();
            }
            return success;
        }
    }
}
