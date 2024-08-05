
using System.Data.SqlClient;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace CSIT_Project.Pages.Entities
{
    public class WorkSlot
    {
        public string id;
        public string workRole;
        public string workDay;
        public string workWeek;
        public string startTime;
        public string endTime;
        public List<StaffBid> allStaffBids = new List<StaffBid>();
        public int staffAllocated;


        public int createWorkSlot()
        {
            //save user into database
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO workslots " +
                                 "(workRole, workDay, workWeek, startTime, endTime) VALUES " +
                                 "(@workRole, @workDay, @workWeek, @startTime, @endTime);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@workRole", workRole);
                        command.Parameters.AddWithValue("@workDay", workDay);
                        command.Parameters.AddWithValue("@workWeek", workWeek);
                        command.Parameters.AddWithValue("@startTime", startTime);
                        command.Parameters.AddWithValue("@endTime", endTime);

                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
            if (workRole.Length == 0 || workDay.Length == 0 || workWeek.Length == 0
                || startTime.Length == 0 || endTime.Length == 0)
            {
                return 0;
            }
            return 1;
        }

        public WorkSlot getWorkSlot(string id)
        {
            WorkSlot workSlot = new WorkSlot();

            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM workslots WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                workSlot.id = "" + reader.GetInt32(0);
                                workSlot.workRole = reader.GetString(1);
                                workSlot.workDay = reader.GetString(2);
                                workSlot.workWeek = "" + reader.GetInt32(3);
                                workSlot.startTime = reader.GetString(4);
                                workSlot.endTime = reader.GetString(5);
                                int? nullableStaffAllocated = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6);
                                workSlot.staffAllocated = nullableStaffAllocated ?? 0; // Provide a default value if needed
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return workSlot;
        }

        public void setWorkRole(string workRole)
        {
            this.workRole = workRole;
        }
        public void setStartTime(string startTime)
        {
            this.startTime = startTime;
        }
        public void setWorkDay(string workDay)
        {
            this.workDay = workDay;
        }
        public void setWorkWeek(int workWeek)
        {
            this.workWeek = "" + workWeek;
        }

        public int editWorkSlot()
        {
            // Save work slot into the database
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE workslots " +
                                 "SET workRole=@workRole, workDay=@workDay, workweek=@workweek, startTime=@startTime, endTime=@endTime " +
                                 "WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@workRole", workRole);
                        command.Parameters.AddWithValue("@workDay", workDay);
                        command.Parameters.AddWithValue("@workWeek", workWeek);
                        command.Parameters.AddWithValue("@startTime", startTime);
                        command.Parameters.AddWithValue("@endTime", endTime);
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void addStaffBid(StaffBid staffBid)
        {
            allStaffBids.Add(staffBid);
        }

        public List<WorkSlot> SearchWorkSlot(string search)
        {
            List<WorkSlot> listWorkSlots = new List<WorkSlot>();

            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM workslots WHERE workRole LIKE '%' + @search + '%' OR workDay LIKE '%' + @search + '%' " +
                        "OR id LIKE '%' + @search + '%' OR workweek LIKE '%' + @search + '%' OR startTime LIKE '%' + @search + '%' OR endTime LIKE '%' + @search + '%' ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@search", "%" + search + "%");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                WorkSlot workslot = new WorkSlot();
                                workslot.id = "" + reader.GetInt32(0);
                                workslot.workRole = reader.GetString(1);
                                workslot.workDay = reader.GetString(2);
                                workslot.workWeek = "" + reader.GetInt32(3);
                                workslot.startTime = reader.GetString(4);
                                workslot.endTime = reader.GetString(5);

                                listWorkSlots.Add(workslot);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return listWorkSlots;
        }
        public List<WorkSlot> ViewWorkSlot()
        {
            List<WorkSlot> listWorkSlots = new List<WorkSlot>();
            try
            {
                //String connectionString = "Data Source=.\\mssqlserver01;Initial Catalog=CSIT_Project;Integrated Security=True";
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM workslots";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                WorkSlot workslot = new WorkSlot();
                                workslot.id = "" + reader.GetInt32(0);
                                workslot.workRole= reader.GetString(1);
                                workslot.workDay = reader.GetString(2);
                                workslot.workWeek = reader.GetInt32(3).ToString();
                                workslot.startTime = reader.GetString(4);
                                workslot.endTime = reader.GetString(5);
                                int? nullableStaffAllocated = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6);
                                workslot.staffAllocated = nullableStaffAllocated ?? 0; // Provide a default value if needed

                                listWorkSlots.Add(workslot);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            return listWorkSlots;
        }

        public WorkSlot viewWorkSlotDetails()
        {
            WorkSlot workSlotDetails = new WorkSlot();
            //string connectionString = "Data Source=.\\mssqlserver01;Initial Catalog=CSIT_Project;Integrated Security=True";
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
            string sql = "SELECT * FROM workslots WHERE workRole = @workRole AND startTime = @startTime AND workDay = @workDay AND workWeek = @workWeek";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Add parameters for workRole, startTime, workDay, and workWeek
                    command.Parameters.AddWithValue("@workRole", workRole);
                    command.Parameters.AddWithValue("@startTime", startTime);
                    command.Parameters.AddWithValue("@workDay", workDay);
                    command.Parameters.AddWithValue("@workWeek", workWeek);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            workSlotDetails = new WorkSlot
                            {
                                id = reader.GetInt32(0).ToString(),
                                workRole = reader.GetString(1),
                                workDay = reader.GetString(2),
                                workWeek = reader.GetInt32(3).ToString(),
                                startTime = reader.GetString(4),
                                endTime = reader.GetString(5),
                                staffAllocated = reader.IsDBNull(6) ? 0 : reader.GetInt32(6)
                            };
                        }
                        else
                        {
                            // If no data is found for the specified parameters
                            workSlotDetails = new WorkSlot
                            {
                                    id = "NA",
                                    workRole = "NA",
                                    workDay = "NA",
                                    workWeek = "NA",
                                    startTime = "NA",
                                    endTime = "NA",
                                    staffAllocated = 0
                            };
                        }
                    }
                }
            }
            return workSlotDetails;
        }


        public int deleteWorkSlot()
        {
            String errorMessage;

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "DELETE FROM workslots " +
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

        public void setStaffAllocated(int useraccountId)
        {
            this.staffAllocated = useraccountId;

            //string connectionString = "Data Source=.\\mssqlserver01;Initial Catalog=CSIT_Project;Integrated Security=True";
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "UPDATE workslots SET staffAllocated = @staff WHERE id = @workslotId;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@staff", useraccountId);
                        command.Parameters.AddWithValue("@workslotId", id);

                        command.ExecuteNonQuery(); // Execute the update statement
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

        }

        public int GetMaxWeeks()
        {
            int maxWeeks = 0;

            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                //string connectionString = "Data Source=.\\mssqlserver01;Initial Catalog=CSIT_Project;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT MAX(workWeek) FROM workslots";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            maxWeeks = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return maxWeeks;
        }

    }
}
