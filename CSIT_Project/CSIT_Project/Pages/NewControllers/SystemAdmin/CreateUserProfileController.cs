using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.SystemAdmin
{
    public class CreateUserProfileController
    {
        public int createUserProfile(string profile, string description)
        {
            UserProfile userProfile = new UserProfile();
            userProfile.profile = profile;
            userProfile.description = description;
            bool profileUnique = userProfile.IsProfileUnique(profile);
            int success = 0;

            if (profileUnique == false)
            {
                success = userProfile.createUserProfile();
            }
            return success;
        }
    }
}
