using System.Data.SqlClient;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace CSIT_Project.Pages.Entities
{
    public class UserProfile
    {
        public String profile;
        public String description;
        public string id;
        public string status;
        public string keyword;
        public List<UserProfile> listProfiles = new List<UserProfile>();

        public UserProfile() 
        {
            profile = "";
            description = "";
            id = "";
            status = "";
            keyword = "";
        }
        public int createUserProfile()
        {
            //save user into database
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO UserProfiles " +
                                 "(Profile, Description) VALUES " +
                                 "(@Profile, @Description);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Profile", profile);
                        command.Parameters.AddWithValue("@Description", description);

                        command.ExecuteNonQuery();
                    }
                }
                return 1;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                return 0;
            }
        }

        public UserProfile getUserProfile(string id) {
            UserProfile userProfile = new UserProfile();
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM UserProfiles WHERE ID=@Id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userProfile.id = "" + reader.GetInt32(0);
                                userProfile.profile = reader.GetString(1);
                                userProfile.description = reader.GetString(2);
                                userProfile.status = reader.GetString(3);
                            }
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return userProfile;
        }

        public int editUserProfile()
        {
            //save user into database
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE UserProfiles " +
                                 "SET Profile = @Profile, Description = @description " +
                                 "WHERE ID = @id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Profile", profile);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }
                return 1;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                return 0;
            }

        }

        public List<UserProfile> SearchUserProfile(string keyword)
        {
            List<UserProfile> listProfiles = new List<UserProfile>();

            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT ID, Profile, Description, Status FROM UserProfiles WHERE " +
                                 "Profile LIKE '%' + @keyword + '%' OR Description LIKE '%' + @keyword + '%' OR ID LIKE '%' + @keyword + '%' OR status LIKE '%' + @keyword + '%'";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@keyword", "%" + keyword.ToLower() + "%");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserProfile userProfile = new UserProfile
                                {
                                    id = "" + reader.GetInt32(0),
                                    profile = reader.GetString(1),
                                    description = reader.GetString(2),
                                    status = reader.GetString(3)
                                };

                                listProfiles.Add(userProfile);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return listProfiles;
        }
            public List<UserProfile> viewUserProfile()
            {
            List<UserProfile> listProfiles = new List<UserProfile>();
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT ID, Profile, Description, Status FROM UserProfiles";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserProfile userProfile = new UserProfile();
                                userProfile.id = "" + reader.GetInt32(0);
                                userProfile.profile = reader.GetString(1);
                                userProfile.description = reader.GetString(2);
                                userProfile.status = reader.GetString(3);

                                listProfiles.Add(userProfile);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            return listProfiles;
            }

        public int deleteUserProfile(String id)
        {
            String errorMessage;

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE UserProfiles " +
                                 "SET status = 'Suspended'" +
                                 "where ID=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return 0;
            }
        }

        public bool IsProfileUnique(string profile)
        {
            // Check if the given Role already exists in the database
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
            string sql = "SELECT COUNT(*) FROM UserProfiles WHERE Profile = @Profile AND Status = 'Active'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Profile", profile);
                    int count = (int)command.ExecuteScalar();

                    return count >= 1;
                }
            }
        }


    }

}

