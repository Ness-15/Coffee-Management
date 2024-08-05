using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Net;
using System.Numerics;
using System.Xml.Linq;
using System.Data;
using static Azure.Core.HttpHeader;
using CSIT_Project.Pages.NewControllers.CafeStaff;

namespace CSIT_Project.Pages.Entities
{
	public class StaffBid
	{
		public String id;
		public String workslotId;
		public String useraccountId;
        public string userName;
        public string userEmail;
        public string userPhone;
        public string role;
        public string status;
        public WorkSlot workslot = new WorkSlot();
        public List<StaffBid> allStaffBids = new List<StaffBid>();

        public StaffBid()
		{
		}

		public StaffBid(String workslotId, String useraccountId)
		{
			this.workslotId = "" + workslotId;
			this.useraccountId = "" + useraccountId;
		}

        public void getStaffBid(string id)
        {
            try
            {
                //string connectionString = "Data Source=.\\mssqlserver01;Initial Catalog=CSIT_Project;Integrated Security=True";
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT " +
                                "sa.id AS staffbidId, " +
                                "ws.id AS workslotId, " +
                                "ua.id AS useraccountId, " +
                                "ua.name, " +
                                "ua.email, " +
                                "ua.phone, " +
                                "ws.workRole, " +
                                "sa.status FROM staffbids sa " +
                                "INNER JOIN useraccounts ua ON sa.useraccountId = ua.id " +
                                "INNER JOIN workslots ws ON sa.workslotId = ws.id ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                id = "" + reader.GetInt32(0);
                                workslotId = "" + reader.GetInt32(1);
                                useraccountId = "" + reader.GetInt32(2);
                                userName = reader.GetString(3);
                                userEmail = reader.GetString(4);
                                userPhone = reader.GetString(5);
                                role = reader.GetString(6);
                                status = reader.GetString(7);
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

		public void createStaffBid()
		{
            String errorMessage;

            try
            {
                //String connectionString = "Data Source=.\\mssqlserver01;Initial Catalog=CSIT_Project;Integrated Security=True";
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {   
                    connection.Open();
                    String sql = "INSERT INTO staffbids " +
                                    "(workslotId, useraccountId) VALUES " +
                                    "(@workslotId, @useraccountId);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@workslotId", workslotId);
                        command.Parameters.AddWithValue("@useraccountId", useraccountId);

                        command.ExecuteNonQuery();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
        }

        public List<StaffBid> ViewStaffBids()
        {
            List<StaffBid> listStaffBids = new List<StaffBid>();
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                //string connectionString = "Data Source=.\\mssqlserver01;Initial Catalog=CSIT_Project;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT " +
                                "sa.id AS staffbidId, " +
                                "ws.id AS workslotId, " +
                                "ua.id AS useraccountId, " +
                                "ua.name, " +
                                "ua.email, " +
                                "ua.phone, " +
                                "ws.workRole, " +
                                "sa.status FROM staffbids sa " +
                                "INNER JOIN useraccounts ua ON sa.useraccountId = ua.id " +
                                "INNER JOIN workslots ws ON sa.workslotId = ws.id ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StaffBid staffBid = new StaffBid();
                                staffBid.id = "" + reader.GetInt32(0);
                                staffBid.workslotId = "" + reader.GetInt32(1);
                                staffBid.useraccountId = "" + reader.GetInt32(2);
                                staffBid.userName = reader.GetString(3);
                                staffBid.userEmail = reader.GetString(4);
                                staffBid.userPhone = reader.GetString(5);
                                staffBid.role = reader.GetString(6);
                                staffBid.status = reader.GetString(7);

                                listStaffBids.Add(staffBid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            return listStaffBids;
        }

        public List<StaffBid> ViewStaffBids(string useraccountId)
        {
            List<StaffBid> listStaffBids = new List<StaffBid>();
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                //string connectionString = "Data Source=.\\mssqlserver01;Initial Catalog=CSIT_Project;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT " +
                                "sa.id AS staffbidId, " +
                                "ws.id AS workslotId, " +
                                "ua.id AS useraccountId, " +
                                "ua.name, " +
                                "ua.email, " +
                                "ua.phone, " +
                                "ws.workRole, " +
                                "sa.status FROM staffbids sa " +
                                "INNER JOIN useraccounts ua ON sa.useraccountId = ua.id " +
                                "INNER JOIN workslots ws ON sa.workslotId = ws.id " +
                                "WHERE ua.useraccountId = @useraccountId;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@useraccountId", useraccountId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StaffBid staffBid = new StaffBid();
                                staffBid.id = "" + reader.GetInt32(0);
                                staffBid.workslotId = "" + reader.GetInt32(1);
                                staffBid.useraccountId = "" + reader.GetInt32(2);
                                staffBid.userName = reader.GetString(3);
                                staffBid.userEmail = reader.GetString(4);
                                staffBid.userPhone = reader.GetString(5);
                                staffBid.role = reader.GetString(6);
                                staffBid.status = reader.GetString(7);

                                listStaffBids.Add(staffBid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            return listStaffBids;
        }

        public List<StaffBid> ViewMyBids()
        {
            List<StaffBid> listStaffBids = new List<StaffBid>();
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                //string connectionString = "Data Source=.\\mssqlserver01;Initial Catalog=CSIT_Project;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * from staffbids WHERE useraccountId=@useraccountId";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@useraccountId", useraccountId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StaffBid staffBid = new StaffBid();
                                staffBid.id = "" + reader.GetInt32(0);
                                staffBid.workslotId = "" + reader.GetInt32(1);
                                staffBid.useraccountId = "" + reader.GetInt32(2);
                                staffBid.status = reader.GetString(3);
                                staffBid.workslot = new WorkSlot().getWorkSlot(staffBid.workslotId);

                                listStaffBids.Add(staffBid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            return listStaffBids;
        }

        public List<StaffBid> viewProcessingStaffBids()
        {
            List<StaffBid> listStaffBids = new List<StaffBid>();
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                //string connectionString = "Data Source=.\\mssqlserver01;Initial Catalog=CSIT_Project;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT " +
                                "sa.id AS staffbidId, " +
                                "ws.id AS workslotId, " +
                                "ua.id AS useraccountId, " +
                                "ua.name, " +
                                "ua.email, " +
                                "ua.phone, " +
                                "ws.workRole, " +
                                "sa.status FROM staffbids sa " +
                                "INNER JOIN useraccounts ua ON sa.useraccountId = ua.id " +
                                "INNER JOIN workslots ws ON sa.workslotId = ws.id " +
                                "WHERE sa.status = 'processing';";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StaffBid staffBid = new StaffBid();
                                staffBid.id = "" + reader.GetInt32(0);
                                staffBid.workslotId = "" + reader.GetInt32(1);
                                staffBid.useraccountId = "" + reader.GetInt32(2);
                                staffBid.userName = reader.GetString(3);
                                staffBid.userEmail = reader.GetString(4);
                                staffBid.userPhone = reader.GetString(5);
                                staffBid.role = reader.GetString(6);
                                staffBid.status = reader.GetString(7);

                                listStaffBids.Add(staffBid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            return listStaffBids;
        }

        public List<StaffBid> viewCompletedStaffBids()
        {
            List<StaffBid> listStaffBids = new List<StaffBid>();
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                //string connectionString = "Data Source=.\\mssqlserver01;Initial Catalog=CSIT_Project;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT " +
                                "sa.id AS staffbidId, " +
                                "ws.id AS workslotId, " +
                                "ua.id AS useraccountId, " +
                                "ua.name, " +
                                "ua.email, " +
                                "ua.phone, " +
                                "ws.workRole, " +
                                "sa.status FROM staffbids sa " +
                                "INNER JOIN useraccounts ua ON sa.useraccountId = ua.id " +
                                "INNER JOIN workslots ws ON sa.workslotId = ws.id " +
                                "WHERE sa.status != 'processing';";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@useraccountId", useraccountId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StaffBid staffBid = new StaffBid();
                                staffBid.id = "" + reader.GetInt32(0);
                                staffBid.workslotId = "" + reader.GetInt32(1);
                                staffBid.useraccountId = "" + reader.GetInt32(2);
                                staffBid.userName = reader.GetString(3);
                                staffBid.userEmail = reader.GetString(4);
                                staffBid.userPhone = reader.GetString(5);
                                staffBid.role = reader.GetString(6);
                                staffBid.status = reader.GetString(7);

                                listStaffBids.Add(staffBid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            return listStaffBids;
        }

        public void approveBid()
        {
            String errorMessage;

            try
            {
                //string connectionString = "Data Source=.\\mssqlserver01;Initial Catalog=CSIT_Project;Integrated Security=True";
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE staffbids " +
                                    "SET status = 'approved'" +
                                    "WHERE id = @id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            status = "accepted";
        }

        public void rejectBid()
        {
            String errorMessage;

            try
            {
                //String connectionString = "Data Source=.\\mssqlserver01;Initial Catalog=CSIT_Project;Integrated Security=True";
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE staffbids " +
                                    "SET status = 'rejected'" +
                                    "WHERE id = @id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            status = "rejected";
        }

        public int deleteStaffBid()
        {
            String errorMessage;

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                //String connectionString = "Data Source=.\\mssqlserver01;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "DELETE FROM staffbids " +
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

        public List<StaffBid> searchStaffBid(String search, String useraccountId)
        {
            List<StaffBid> staffbids = new List<StaffBid>();

            List<StaffBid> temp = new StaffBid().ViewStaffBids(useraccountId);
            search = search.ToLower();
            foreach (StaffBid staffBid in temp)
            {
                if (staffBid.workslot.workWeek.Contains(search) || staffBid.workslot.workDay.ToLower().Contains(search) || staffBid.workslot.startTime.Contains(search) || staffBid.workslot.endTime.Contains(search))
                    staffbids.Add(staffBid);
            }

            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM staffbids WHERE id LIKE '%' + @search + '%' OR status LIKE '%' + @search + '%' AND useraccountId=@useraccountId";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@search", "%" + search + "%");
                        command.Parameters.AddWithValue("@useraccountId", useraccountId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StaffBid staffBid = new StaffBid();
                                staffBid.getStaffBid("" + reader.GetInt32(0));

                                bool contains = false;
                                foreach(StaffBid sb in staffbids)
                                {
                                    if (sb.id.Equals(staffBid.id))
                                        contains = true;
                                }
                                    
                                if (!contains)
                                    staffbids.Add(staffBid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            
            return staffbids;
        }


        public List<StaffBid> searchMyBid(String search)
        {
            List<StaffBid> staffbids = new List<StaffBid>();
            List<StaffBid> temp = new ViewBidController().viewBid(useraccountId);
            search = search.ToLower();
            foreach (StaffBid staffBid in temp)
            {
                if (staffBid.workslot.workWeek.Contains(search) || staffBid.workslot.workDay.ToLower().Contains(search) || staffBid.workslot.startTime.Contains(search) || staffBid.workslot.endTime.Contains(search))
                    staffbids.Add(staffBid);
            }

            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM staffbids WHERE id LIKE '%' + @search + '%' OR status LIKE '%' + @search + '%' AND useraccountId=@useraccountId";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@search", "%" + search + "%");
                        command.Parameters.AddWithValue("@useraccountId", useraccountId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StaffBid staffBid = new StaffBid();
                                staffBid.id = "" + reader.GetInt32(0);
                                staffBid.workslotId = "" + reader.GetInt32(1);
                                staffBid.useraccountId = "" + reader.GetInt32(2);
                                staffBid.status = reader.GetString(3);
                                staffBid.workslot = workslot.getWorkSlot(staffBid.workslotId);

                                bool contains = false;
                                foreach (StaffBid sb in staffbids)
                                {
                                    if (sb.id.Equals(staffBid.id))
                                        contains = true;
                                }

                                if (!contains)
                                    staffbids.Add(staffBid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return staffbids;
        }

    
        public int editStaffBid()
        {
            String errorMessage;

            try
            {

                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CSIT_Project;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE staffbids SET workslotId=@workslotId, useraccountId=@useraccountId WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@workslotId", workslotId);
                        command.Parameters.AddWithValue("@useraccountId", useraccountId);
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

    }    
}

