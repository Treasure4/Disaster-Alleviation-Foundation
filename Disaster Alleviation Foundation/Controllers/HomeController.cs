using Disaster_Alleviation_Foundation.Models;
using Disaster_Alleviation_Foundation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using NuGet.Packaging.Signing;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Alleviation_Foundation.Controllers
{
    public class HomeController : Controller
    {

        public string connectionString = "Server=tcp:st10102544.database.windows.net,1433;Initial Catalog=dlpromwebsite;Persist Security Info=False;User ID=djadmin;Password=Biggie4life;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private readonly ILogger<HomeController> _logger;
        private readonly DisasterContext _context;

        public HomeController(ILogger<HomeController> logger, DisasterContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(UsersModel users)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO Users (name, Password,Email) VALUES (@name, @Password, @Email)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", users.Name);
            cmd.Parameters.AddWithValue("@Password", UsersModel.HashPassword(users.Password));
            cmd.Parameters.AddWithValue("@Email", users.Email);
            cmd.ExecuteNonQuery();
            conn.Close();


            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsersModel Users)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE name = @name AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", Users.Name);
                cmd.Parameters.AddWithValue("@Password", UsersModel.HashPassword(Users.Password));

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    // Successful login, redirect to a dashboard or another page
                    return RedirectToAction("Index");
                }
                else
                {
                    // Invalid login, return to the login page with an error message
                    ModelState.AddModelError(string.Empty, "Invalid credentials");
                    return View("LogIn");
                }
            }
        }
        [HttpGet]
        public IActionResult GoodsDonation() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult GoodsDonation(GoodsDonationModel goods)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO GoodsDonation (Name, Date, NumOfItems, Category, Description) VALUES (@Name, @Date, @NumOfItems, @Category, @Description)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", goods.Name);
            cmd.Parameters.AddWithValue("@Date", goods.Date);
            cmd.Parameters.AddWithValue("@NumOfItems", goods.NumOfItems);
            cmd.Parameters.AddWithValue("@Category", goods.Category);
            cmd.Parameters.AddWithValue("@Description", goods.Description); 
            cmd.ExecuteNonQuery();
            conn.Close();

            return View("Index");
        }

        [HttpGet]
        public IActionResult GoodsDonationList()
        {
            var goods = _context.GoodsDonation.ToList();

            return View(goods);
        }

        [HttpGet]
        public IActionResult MonetaryDonation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MonetaryDonation(MonetaryDonationModel monetary)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO MonetaryDonation (Name, Date, Amount) VALUES (@Name, @Date, @Amount)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", monetary.Name);
            cmd.Parameters.AddWithValue("@Date", monetary.Date);
            cmd.Parameters.AddWithValue("@Amount", monetary.Amount);
            cmd.ExecuteNonQuery();
            conn.Close();


            return View("Index");
        }

        [HttpGet]
        public IActionResult MonetaryDonationList()
        {
            var monetary = _context.MonetaryDonation.ToList();

            return View(monetary);
        }

        [HttpGet]
        public IActionResult Disaster()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Disaster(DisasterModel disaster)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO Disasters (StartDate, EndDate, Location, Description, AidType, ActiveDisasters) VALUES (@StartDate, @EndDate, @Location, @Description, @AidType,@ActiveDisasters)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@StartDate", disaster.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", disaster.EndDate);
            cmd.Parameters.AddWithValue("@Location", disaster.Location);
            cmd.Parameters.AddWithValue("@Description", disaster.Description);
            cmd.Parameters.AddWithValue("@AidType", disaster.AidType);
            cmd.Parameters.AddWithValue("@ActiveDisasters", disaster.ActiveDisasters);
            cmd.ExecuteNonQuery();
            conn.Close();


            return View("Index");
        }

        [HttpGet]
        public IActionResult DisasterList()
        {
            var Disaster = _context.Disasters.ToList();
            return View(Disaster);
        }

        [HttpGet]
        public IActionResult Categories()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Categories(CategoryModel category)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO Categories (Name) VALUES (@Name)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", category.Name);
            cmd.ExecuteNonQuery();
            conn.Close();


            return View("Index");
        }

        [HttpGet]
        public IActionResult Allocation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Allocation(AllocationsModel allocations)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO Allocations (Allocation, GoodsCategory ) VALUES (@Allocation, @GoodsCategory )";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Allocation", allocations.Allocation);
            cmd.Parameters.AddWithValue("@GoodsCategory", allocations.GoodsCategory);

            cmd.ExecuteNonQuery();
            conn.Close();

            return View("Index");
        }

        [HttpGet]
        public IActionResult GoodsAllocation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AllocationSuccess()
        {
            return View();
        }

        public ActionResult AllocateGoods(GoodsAllocationModel goodsAllocation)
        {
            if (ModelState.IsValid)
            { 
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "INSERT INTO GoodsAllocation (GoodsDescription, Quantity) " +
                                    "VALUES (@GoodsDescription, @Quantity)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@GoodsDescription", goodsAllocation.GoodsDescription);
                        cmd.Parameters.AddWithValue("@Quantity", goodsAllocation.Quantity);

                        cmd.ExecuteNonQuery();
                    }
                }
                    return RedirectToAction("AllocationSuccess"); 
            }
            return View(goodsAllocation);
        }

        [HttpGet]
        public ActionResult CapturePurchase()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Purchase(PurchaseModel purchaseModel)
        {
            decimal avaMoney = CulAvaMoney();

            if (purchaseModel.TotalCost > avaMoney)
            {
                return RedirectToAction("Index");
            }

            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO Purchase (Quantity,Description, TotalCost) VALUES (@Quantity,@Description, @TotalCost)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Description", purchaseModel.Quantity);
            cmd.Parameters.AddWithValue("@Quantity", purchaseModel.Description);
            cmd.Parameters.AddWithValue("@TotalCost", purchaseModel.TotalCost);
            cmd.ExecuteNonQuery();
            conn.Close();

            UpdateAvaMoney(avaMoney - purchaseModel.TotalCost);
            decimal update = avaMoney- purchaseModel.TotalCost;
            ViewBag.update = update;

            return View("PurchaseSuccess");


            decimal CulAvaMoney()
            {
                decimal AvaMoney = 12000;


                return AvaMoney;
            }

        }

        private void UpdateAvaMoney(decimal newMoney)
        {

        }

        [HttpGet]
        public ActionResult Purchase()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PurchaseSuccess()
        {
            return View();
        }

        public async Task<IActionResult> PublicInfo()
{
    var model = new PublicInfoViewModel();

    // Calculate total monetary donations
    decimal totalMonetaryDonations = await _context.MonetaryDonation.SumAsync(d => d.Amount);
    model.TotalMonetaryDonations = (int)totalMonetaryDonations; // Explicit conversion to int

    // Calculate total goods received
    model.TotalGoodsReceived = await _context.GoodsDonation.SumAsync(d => d.NumOfItems);

    // Get currently active disasters with money and goods allocated
    //model.ActiveDisasters = await _context.Disasters
    //    .Where(d => d.EndDate >= DateTime.Now)
    //    //.Include(d => d.MoneyAllocations)
    //    //.Include(d => d.GoodsAllocation)
    //    .ToListAsync();

    return View(model);
}

    }
}