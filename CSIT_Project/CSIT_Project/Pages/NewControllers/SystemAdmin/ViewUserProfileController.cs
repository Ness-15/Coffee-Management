using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.SystemAdmin
{
    public class ViewUserProfileController
    {
        public List<UserProfile> viewUserProfile()
        {
            return new UserProfile().viewUserProfile();
        }
    }
}
