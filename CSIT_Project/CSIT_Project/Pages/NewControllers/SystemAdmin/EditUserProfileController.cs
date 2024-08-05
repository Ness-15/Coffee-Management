using CSIT_Project.Pages.Entities;

namespace CSIT_Project.Pages.NewControllers.SystemAdmin
{
    public class EditUserProfileController
    {
        public int editUserProfile(string id, string profile, string description)
        {
            UserProfile userProfile = new UserProfile();
            userProfile.id = id;
            userProfile.profile = profile;
            userProfile.description = description;

            UserProfile tempProfile = new UserProfile();
            tempProfile = tempProfile.getUserProfile(id);

            bool profileUnique = false;
            int success = 0;

            if (!(tempProfile.profile.Equals(profile)))
                 profileUnique = userProfile.IsProfileUnique(profile);


            if (profileUnique == false)
            {
                success = userProfile.editUserProfile();
            }
            return success;
        }
    }
}
