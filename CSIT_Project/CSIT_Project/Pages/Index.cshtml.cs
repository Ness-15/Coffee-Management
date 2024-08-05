using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CSIT_Project.Pages.Entities;
using System.Data.SqlClient;
using System;
using System.IO;
using System.Numerics;
using CSIT_Project.Pages.NewControllers;
using CSIT_Project.Pages.NewControllers.SystemAdmin;
using CSIT_Project.Pages.NewControllers.CafeOwner;
using CSIT_Project.Pages.NewControllers.CafeStaff;

namespace CSIT_Project.Pages
{
    public class IndexModel : PageModel
    {
        public string id;
        public string email;
        public string password;
        public string stafftype;
        public bool success;
        LoginController loginController = new LoginController();
        UserAccount userInfo = new UserAccount();
        string[] loginData = { };

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Clear session on page load
            String useraccountId = HttpContext.Session.GetString("id");
            //generateTest();
        }

        public void OnPost()
        {
            email = Request.Form["email"];
            password = Request.Form["password"];
            stafftype = Request.Form["stafftype"];
            id = userInfo.getId(email, password, stafftype);


            if (loginData != null) // Check if login is successful
            {
                // Store user information in the session
                HttpContext.Session.SetString("email", email);
                HttpContext.Session.SetString("stafftype", stafftype);
                HttpContext.Session.SetString("id", id);
                Login();
            }
            
        }

        public void Login()
        {
            success = loginController.Login(email, password, stafftype);

            // Redirect the user to the appropriate page
            if (stafftype == "4" && success == true)
            {
                HttpContext.Session.Remove("errorMessage");
                Response.Redirect("SystemAdmin/UserAccounts/Index");

            }
            else if (stafftype == "1" && success == true)
            {
                HttpContext.Session.Remove("errorMessage");
                Response.Redirect("CafeOwner/WorkSlots/Index");
            }
            else if (stafftype == "3" && success == true)
            {
                HttpContext.Session.Remove("errorMessage");
                Response.Redirect("CafeStaff");
            }
            else if (stafftype == "2" && success == true)
            {
                HttpContext.Session.Remove("errorMessage");
                Response.Redirect("CafeManager");
            }
            else
            {
                // Invalid password, display a message to the user
                HttpContext.Session.SetString("errorMessage", "Invalid Info. Info is not matched. Please try again.");
                Response.Redirect("Index"); // Redirect to a login page or a page to display the error message.
            }

        }

        public void generateUsers()
        {
            string line;
            List<String> names = new List<String>();
            List<String> allAddress = new List<String>();
            String[] emailExtensions = { "@gmail.com", "@yahoo.com", "@msn.com", "@microsoft.com", "@icloud.com", "@apple.com", "@hotmail.com", "@outlook.com" };
            String[] allRoles = { "Chef", "Waiter", "Cashier" };

            try
            {
                StreamReader sr = new StreamReader("names.txt");
                line = sr.ReadLine();

                while (line!=null)
                {
                    names.Add(line);
                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                StreamReader sr = new StreamReader("address.txt");
                line = sr.ReadLine();

                while (line != null)
                {
                    allAddress.Add(line);
                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                int r1 = random.Next(names.Count());
                int r2 = random.Next(names.Count());
                int r3 = random.Next(emailExtensions.Count());
                int r4 = random.Next(allAddress.Count());
                int r5 = random.Next(allRoles.Count());

                string firstName = names[r1];
                string lastName = names[r2];

                string username = firstName + lastName;
                string password = "1234";
                string name = firstName + " " + lastName;
                string email = firstName + "." + lastName + emailExtensions[r3];
                string phone = "";
                for (int k=0; k<8; k++)
                {
                    int r = (int)new Random().NextInt64(0, 9);
                    phone = phone + r.ToString();
                }
                string address = allAddress[r4];
                int stafftypeId = (int)new Random().NextInt64(1, 4);
                string role = "";

                if (stafftypeId == 3)
                    role = allRoles[r5];

                int success = new CreateUserAccountController().createUserAccount(username, password, name, email, phone, address, stafftypeId, role);
            }

        }

        public void generateWorkSlots()
        {
            for (int i=1; i <=4; i++)
            {
                for (int j=0; j<7; j++)
                {
                    string workDay = "";

                    switch (j)
                    {
                        case 0:
                            workDay = "Monday";
                            break;
                        case 1:
                            workDay = "Tuesday";
                            break;
                        case 2:
                            workDay = "Wednesday";
                            break;
                        case 3:
                            workDay = "Thursday";
                            break;
                        case 4:
                            workDay = "Friday";
                            break;
                        case 5:
                            workDay = "Saturday";
                            break;
                        default:
                            workDay = "Sunday";
                            break;
                    }

                    int success1 = new CreateWorkSlotController().createWorkSlot("Chef", workDay, i.ToString(), "09:00:00", "17:00:00");
                    int success2 = new CreateWorkSlotController().createWorkSlot("Waiter", workDay, i.ToString(), "09:00:00", "17:00:00");
                    int success3 = new CreateWorkSlotController().createWorkSlot("Cashier", workDay, i.ToString(), "09:00:00", "17:00:00");
                }
            }
        }

        public void generateStaffBids()
        {
            List<UserAccount> cafeStaffs = new List<UserAccount>();
            cafeStaffs = new ViewCafeStaffController().viewStaff();
            List<String> cafeStaffIds = new List<String>();

            List<WorkSlot> workslots = new List<WorkSlot>();
            workslots = new CSIT_Project.Pages.NewControllers.CafeOwner.ViewWorkSlotController().viewAllWorkSlots();
            List<String> workslotsId = new List<String>();

            foreach(UserAccount staff in cafeStaffs)
            {
                cafeStaffIds.Add(staff.id);
            }

            foreach(WorkSlot workslot in workslots)
            {
                workslotsId.Add(workslot.id);
            }

            Random random = new Random();

            List<StaffBid> staffbids = new ViewStaffBidController().viewProcessingStaffBids();
            while (true)
            {
                if (staffbids.Count() < 100)
                {
                    int r1 = random.Next(cafeStaffIds.Count());
                    int r2 = random.Next(workslotsId.Count());

                    string useraccountId = cafeStaffIds[r1];
                    string workslotId = workslotsId[r2];

                    int success = new CreateStaffBidController().createStaffBid(workslotId, useraccountId);
                    staffbids = new ViewStaffBidController().viewProcessingStaffBids();                    
                }
                else
                    break;
            }
        }

        public void generateTest()
        {
            generateUsers();
            generateWorkSlots();
            generateStaffBids();
        }
        
    }
}
