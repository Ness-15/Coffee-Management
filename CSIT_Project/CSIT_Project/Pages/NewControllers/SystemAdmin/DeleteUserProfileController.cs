using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.SystemAdmin
{
    public class DeleteUserProfileController
    {
        public int deleteUserProfile(string id)
        {
            UserProfile userProfile = new UserProfile();
            int success = userProfile.deleteUserProfile(id);
            return success;
        }
    }
}
