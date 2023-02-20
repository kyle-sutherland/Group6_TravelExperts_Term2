//authors tim and arjun

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TravelExpertsData;

namespace TravelExpertsWebApp.Controllers
{
    public class AccountController : Controller
    {
        private TravelExpertsContext _context { get; set; }
        // context inject ot the contructor
        public AccountController(TravelExpertsContext context) { _context = context; }


        // Route: /Account/Login
        // GET: AccountController Login
        public ActionResult Login(string returnUrl ="")
        {
            if(returnUrl != null) { TempData["ReturnUrl"] = returnUrl; }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LoginAsync(Customer customer)
        {
            Customer cst = CustomerManager.Authenticate(_context, customer.Username, customer.Password);
            if (cst == null) // authentication failed
            { return View(); }

            //cst is not null
            // get session id of logged in customer
            HttpContext.Session.SetInt32("CurrentCustomer", cst.CustomerId);


            // need using System.Security.Claims
            List<Claim> claims = new List<Claim>() 
            { 
                new Claim(ClaimTypes.Name, cst.Username),
                new Claim("FirstName", cst.CustFirstName),
                new Claim("LastName", cst.CustLastName),
                new Claim(ClaimTypes.Role,"Customer")
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme); //"Cookies"
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            // et the authenticatino ticket
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            if (string.IsNullOrEmpty(TempData["ReturnUrl"].ToString()))
                return RedirectToAction("Index", "TravelExperts"); // default go to main page
            else return Redirect(TempData["ReturnUrl"].ToString());
        }

        public async Task<IActionResult> LogoutAsync()
        {
            // return the authentication ticket
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("CurrentCustomer");
            return RedirectToAction("Index", "TravelExperts"); // by default go to main page
        }

        // go to 


        public ActionResult Register() { return View(); }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            if (customer != null && ModelState.IsValid)
            {
                CustomerManager.RegisterNewCustomer(_context, customer);
                return RedirectToAction("Welcome", "Account");
            }
            else
            {
                return View(customer);
            }

        }

        public ActionResult Welcome()
        {
            return View();
        }

        //[HttpGet("{id}")]
        //public ActionResult Profile(int id)
        //{
        //    Customer customer = CustomerManager.Find(id);
        //    return View(customer);
        //}

        public ActionResult Profile()
        {
            int? customerId = HttpContext.Session.GetInt32("CurrentCustomer");
            if (customerId != null)
            {
                Customer currentCustomer = CustomerManager.GetCustomerById(_context, (int)customerId);
                if (currentCustomer != null)
                {
                    return View(currentCustomer);
                }
                else
                {
                    return View(new Customer());
                } 
            }
            else
            {
                return View(new Customer());
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Profile(Customer customer)
        {

            try
            {
                CustomerManager.Update(_context, customer);
                ViewBag.Thanks = "Thanks for updating your information!";
                //return RedirectToAction("LogOutUpdateAsync", "Account");
                return View(customer);
                //return RedirectToAction("ThankYou", "Account");
            }
            catch
            {
                return View(customer);
            }
        }
        [Authorize]
        public ActionResult MyBookings()
        {
            int? customerId = HttpContext.Session.GetInt32("CurrentCustomer");
            //List<MyBookingsDTO> list = MyBookingsManager.GetMyBookingsByID(_context, (int)customerId);
            List<PackageDTO> list = MyBookingsManager.GetCustomersPackage(_context, (int)customerId);

            decimal sum = 0;
            foreach (PackageDTO item in list)
            {
                sum += item.PkgBasePrice;
            }
            ViewBag.TotalSum = sum.ToString("c");
            return View(list);
        }

        [Authorize]
        public IActionResult MyBookingsDetails(int id)
        {
            MyBookingsDTO details = MyBookingsManager.GetMyBookingDetailsByBookingID(_context, id);
            return View(details);
        }

        // will uncomment when needed
        //// GET: AccountController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: AccountController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: AccountController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AccountController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: AccountController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AccountController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: AccountController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
