using Azure;
using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace CSIT_Project.Pages.Entities
{
    public class UserAccount
    {
        public String id;
        public String username;
        public String password;
        public String name;
        public String email;
        public String phone;
        public String address;
        public int stafftypeId;
        public String stafftype;
        public bool status;
        public String role;
        public int TotalWorkSlots;

        public UserAccount()
        {
            // Provide default values for non-nullable variables
            id = "";
            username = "";
            password = "";
            name = "";
            email = "";
            phone = "";
            address = "";
            stafftypeId = 0;
            stafftype = "";
            status = false;
            role = "";
            TotalWorkSlots = 0;
 
        }
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccount(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string[] loginUser()
        {
            string[] loginData = {"","",""};
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT email, password, stafftype FROM useraccounts " +
                                 "WHERE email=@email AND password=@password AND stafftype=@stafftype;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@stafftype", stafftypeId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string loginEmail = reader.GetString(0);
                                string loginPassword = reader.GetString(1);
                                string loginStaffType = "" + reader.GetInt32(2);
                                loginData[0] = loginEmail;
                                loginData[1] = loginPassword;
                                loginData[2] = loginStaffType;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            return loginData;

        }
        
        public string getId(string email, string password, string stafftype)
        {
            string id = "";
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT id FROM useraccounts WHERE email=@email AND password=@password AND stafftype=@stafftype";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@stafftype", stafftype);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id = "" + reader.GetInt32(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            return id;
        }

        public void getStaffType()
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT Profile FROM UserProfiles WHERE ID=@ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", stafftypeId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                stafftype = reader.GetString(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
        public int createUserAccount()
        {
            //save user into database
            if (role != "")
            {
                try
                {
                    String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        String sql = "INSERT INTO useraccounts " +
                                     "(username, password, name, email, phone, address, stafftype, role) VALUES " +
                                     "(@username, @password, @name, @email, @phone, @address, @stafftype, @role);";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@username", username);
                            command.Parameters.AddWithValue("@password", password);
                            command.Parameters.AddWithValue("@name", name);
                            command.Parameters.AddWithValue("@email", email);
                            command.Parameters.AddWithValue("@phone", phone);
                            command.Parameters.AddWithValue("@address", address);
                            command.Parameters.AddWithValue("@stafftype", stafftypeId);
                            command.Parameters.AddWithValue("@role", role);

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
            else
            {
                try
                {
                    String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        String sql = "INSERT INTO useraccounts " +
                                     "(username, password, name, email, phone, address, stafftype) VALUES " +
                                     "(@username, @password, @name, @email, @phone, @address, @stafftype);";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@username", username);
                            command.Parameters.AddWithValue("@password", password);
                            command.Parameters.AddWithValue("@name", name);
                            command.Parameters.AddWithValue("@email", email);
                            command.Parameters.AddWithValue("@phone", phone);
                            command.Parameters.AddWithValue("@address", address);
                            command.Parameters.AddWithValue("@stafftype", stafftypeId);

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
        }

        public UserAccount getUserInfo(string id) {
            UserAccount userInfo = new UserAccount();

            //get user from database
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM useraccounts WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userInfo.id = "" + reader.GetInt32(0);
                                userInfo.username = reader.GetString(1);
                                userInfo.password = reader.GetString(2);
                                userInfo.name = reader.GetString(3);
                                userInfo.email = reader.GetString(4);
                                userInfo.phone = reader.GetString(5);
                                userInfo.address = reader.GetString(6);
                                userInfo.stafftypeId = reader.GetInt32(7);
                                userInfo.status = reader.GetBoolean(8);
                                userInfo.getStaffType();
                                userInfo.role = reader.GetString(9);
                            }
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return userInfo;
        }

        public int editUserAccount()
        {
            //save user into database
            if (role!=""){
                try
                {
                    String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        String sql = "UPDATE useraccounts SET username=@username, " +
                            "password=@password, name=@name, email=@email, phone=@phone, " +
                            "address=@address, stafftype=@stafftype, role=@role " +
                            "WHERE id=@id";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@username", username);
                            command.Parameters.AddWithValue("@password", password);
                            command.Parameters.AddWithValue("@name", name);
                            command.Parameters.AddWithValue("@email", email);
                            command.Parameters.AddWithValue("@phone", phone);
                            command.Parameters.AddWithValue("@address", address);
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@stafftype", stafftypeId);
                            command.Parameters.AddWithValue("@role", role);

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
            else
            {
                try
                {
                    String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        String sql = "UPDATE useraccounts SET username=@username, " +
                            "password=@password, name=@name, email=@email, phone=@phone, " +
                            "address=@address, stafftype=@stafftype, role=NULL " +
                            "WHERE id=@id";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@username", username);
                            command.Parameters.AddWithValue("@password", password);
                            command.Parameters.AddWithValue("@name", name);
                            command.Parameters.AddWithValue("@email", email);
                            command.Parameters.AddWithValue("@phone", phone);
                            command.Parameters.AddWithValue("@address", address);
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@stafftype", stafftypeId);

                            command.ExecuteNonQuery();
                        }
                        return 1;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.ToString());
                    return 0;
                }
            }

        }

        public List<UserAccount> SearchUserAccount(string search)
        {
            int searchId = 0;

            if ("system admin".Contains(search.ToLower()))
                searchId = 4;
            else if ("cafe owner".Contains(search.ToLower()))
                searchId = 1;
            else if ("cafe manager".Contains(search.ToLower()))
                searchId = 2;
            else if ("cafe staff".Contains(search.ToLower()))
                searchId = 3;


            List<UserAccount> listAccounts = new List<UserAccount>();

            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM useraccounts WHERE username LIKE '%' + @search + '%' OR name LIKE '%' + @search + '%' OR id LIKE '%' + @search + '%' OR email LIKE '%' + @search + '%' OR phone LIKE '%' + @search + '%' OR address LIKE '%' + @search + '%' OR stafftype = @searchId";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@search", "%" + search + "%");
                        command.Parameters.AddWithValue("@searchId", searchId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserAccount userInfo = new UserAccount();
                                userInfo.id = "" + reader.GetInt32(0);
                                userInfo.username = reader.GetString(1);
                                userInfo.password = reader.GetString(2);
                                userInfo.name = reader.GetString(3);
                                userInfo.email = reader.GetString(4);
                                userInfo.phone = reader.GetString(5);
                                userInfo.address = reader.GetString(6);
                                userInfo.stafftypeId = reader.GetInt32(7);
                                userInfo.status = reader.GetBoolean(8);
                                userInfo.getStaffType();

                                listAccounts.Add(userInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return listAccounts;
        }
        public List<UserAccount> ViewUserAccount()
        {
            List<UserAccount> listAccounts = new List<UserAccount>();
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM useraccounts";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserAccount userInfo = new UserAccount();
                                userInfo.id = "" + reader.GetInt32(0);
                                userInfo.username = reader.GetString(1);
                                userInfo.password = reader.GetString(2);
                                userInfo.name = reader.GetString(3);
                                userInfo.email = reader.GetString(4);
                                userInfo.phone = reader.GetString(5);
                                userInfo.address = reader.GetString(6);
                                userInfo.stafftypeId = reader.GetInt32(7);
                                userInfo.status = reader.GetBoolean(8);
                                userInfo.getStaffType();

                                listAccounts.Add(userInfo);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            return listAccounts;
        }

        public int deleteUserAccount(String id)
        {
            String errorMessage;

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE useraccounts " +
                                 "SET status=0" +
                                 "where id=@id";

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

        public List<UserAccount> viewManager()
        {
            List<UserAccount> listManagers = new List<UserAccount>();
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM useraccounts";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserAccount userInfo = new UserAccount();
                                userInfo.id = "" + reader.GetInt32(0);
                                userInfo.username = reader.GetString(1);
                                userInfo.password = reader.GetString(2);
                                userInfo.name = reader.GetString(3);
                                userInfo.email = reader.GetString(4);
                                userInfo.phone = reader.GetString(5);
                                userInfo.address = reader.GetString(6);
                                userInfo.stafftypeId = reader.GetInt32(7);
                                userInfo.status = reader.GetBoolean(8);
                                userInfo.getStaffType();
                                if (userInfo.stafftypeId == 2)
                                {
                                    listManagers.Add(userInfo);
                                }


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            return listManagers;
        }
        public bool Login(String email, String password, String stafftype)
        {
            String errorMessage;

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT password, stafftype from useraccounts " +
                                 "WHERE email = @email";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        command.ExecuteNonQuery();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPassword = reader["password"].ToString();
                                string storedStafftype = reader["stafftype"].ToString();
                                return password == storedPassword && stafftype == storedStafftype;
                            }
                        }
                    }
                    return false;
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public void GetTotalWorkSlots()
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT COUNT(*) FROM workslots WHERE staffAllocated = @UserID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", id);
                        TotalWorkSlots = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
 
    public List<UserAccount> viewStaff()
    {
        List<UserAccount> staffList = new List<UserAccount>();
        try
        {
            String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String sql = "SELECT * FROM useraccounts where stafftype = 3";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserAccount userInfo = new UserAccount
                            {
                                id = "" + reader.GetInt32(0),
                                username = reader.GetString(1),
                                password = reader.GetString(2),
                                name = reader.GetString(3),
                                email = reader.GetString(4),
                                phone = reader.GetString(5),
                                address = reader.GetString(6),
                                stafftypeId = reader.GetInt32(7),
                                status = reader.GetBoolean(8),
                                role = reader.GetString(9)
                            };

                            userInfo.GetTotalWorkSlots();  // Update the total work slots

                            staffList.Add(userInfo);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.ToString());
        }

        return staffList;
    }

    public List<UserAccount> SearchStaff(string search)
        {
            int searchId = 0;

            if ("system admin".Contains(search.ToLower()))
                searchId = 4;
            else if ("cafe owner".Contains(search.ToLower()))
                searchId = 1;
            else if ("cafe manager".Contains(search.ToLower()))
                searchId = 2;
            else if ("cafe staff".Contains(search.ToLower()))
                searchId = 3;


            List<UserAccount> listAccounts = new List<UserAccount>();

            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM useraccounts " +
                                 "WHERE (username LIKE '%' + @search + '%' OR " +
                                        "name LIKE '%' + @search + '%' OR " +
                                        "id LIKE '%' + @search + '%' OR " +
                                        "email LIKE '%' + @search + '%' OR " +
                                        "(phone = @search) OR " +
                                        "address LIKE '%' + @search + '%' OR " +
                                        "role LIKE '%' + @search + '%') AND " +
                                        "stafftype = 3";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@search", "%" + search + "%");
                        command.Parameters.AddWithValue("@searchId", searchId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserAccount userInfo = new UserAccount();
                                userInfo.id = "" + reader.GetInt32(0);
                                userInfo.username = reader.GetString(1);
                                userInfo.password = reader.GetString(2);
                                userInfo.name = reader.GetString(3);
                                userInfo.email = reader.GetString(4);
                                userInfo.phone = reader.GetString(5);
                                userInfo.address = reader.GetString(6);
                                userInfo.stafftypeId = reader.GetInt32(7);
                                userInfo.status = reader.GetBoolean(8);
                                userInfo.role = reader.GetString(9);
                                userInfo.getStaffType();

                                listAccounts.Add(userInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return listAccounts;
        }

        public bool IsMailUnique(string email)
        {
            // Check if the given Role already exists in the database
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
            string sql = "SELECT COUNT(*) FROM useraccounts WHERE email = @email AND status = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    int count = (int)command.ExecuteScalar();

                    return count >= 1;
                }
            }
        }

        public int Logout()
        {
            return 1;
        }
    }
}


