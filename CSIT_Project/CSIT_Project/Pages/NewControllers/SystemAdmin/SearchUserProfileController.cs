using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.SystemAdmin
{
    public class SearchUserProfileController
    {
        public List<UserProfile> searchUserProfile(string keyword)
        {
            return new UserProfile().SearchUserProfile(keyword);
        }
    }
}
