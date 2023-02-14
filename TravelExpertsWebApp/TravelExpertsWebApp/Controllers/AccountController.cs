//authors tim and arjun

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
            HttpContext.Session.SetString("CurrentFirstName", cst.CustFirstName);
            HttpContext.Session.SetString("CurrentLastName", cst.CustLastName);
            HttpContext.Session.SetString("CurrentAddress", cst.CustAddress);
            HttpContext.Session.SetString("CurrentCity", cst.CustCity);
            HttpContext.Session.SetString("CurrentProvince", cst.CustProv);
            HttpContext.Session.SetString("CurrentPostal", cst.CustPostal);
            HttpContext.Session.SetString("CurrentCountry", cst.CustCountry);
            HttpContext.Session.SetString("CurrentHomePhone", cst.CustHomePhone);
            HttpContext.Session.SetString("CurrentBusPhone", cst.CustBusPhone);
            HttpContext.Session.SetString("CurrentEmail", cst.CustEmail);
            HttpContext.Session.SetString("CurrentUsername", cst.Username);
            HttpContext.Session.SetString("CurrentPassword", cst.Password);

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
                ViewBag.CustomerId = (int)customerId;
            }
            string? customerFirstName = HttpContext.Session.GetString("CurrentFirstName");
            if (customerFirstName != null)
            {
                ViewBag.CustFirstName = (string)customerFirstName;
            }
            string? customerLastName = HttpContext.Session.GetString("CurrentLastName");
            if (customerLastName != null)
            {
                ViewBag.CustLastName = (string)customerLastName;
            }
            string? customerAddress = HttpContext.Session.GetString("CurrentAddress");
            if (customerAddress != null)
            {
                ViewBag.CustAddress = (string)customerAddress;
            }
            string? customerCity = HttpContext.Session.GetString("CurrentCity");
            if (customerCity != null)
            {
                ViewBag.CustCity = (string)customerCity;
            }
            string? customerProv = HttpContext.Session.GetString("CurrentProvince");
            if (customerProv != null)
            {
                ViewBag.CustProv = (string)customerProv;
            }
            string? customerPostal = HttpContext.Session.GetString("CurrentPostal");
            if (customerPostal != null)
            {
                ViewBag.CustPostal = (string)customerPostal;
            }
            string? customerCountry = HttpContext.Session.GetString("CurrentCountry");
            if (customerCountry != null)
            {
                ViewBag.CustCountry = (string)customerCountry;
            }
            string? customerHomePhone = HttpContext.Session.GetString("CurrentHomePhone");
            if (customerHomePhone != null)
            {
                ViewBag.CustHomePhone = (string)customerHomePhone;
            }
            string? customerBusPhone = HttpContext.Session.GetString("CurrentBusPhone");
            if (customerBusPhone != null)
            {
                ViewBag.CustBusPhone = (string)customerBusPhone;
            }
            string? customerEmail = HttpContext.Session.GetString("CurrentEmail");
            if (customerEmail != null)
            {
                ViewBag.CustEmail = (string)customerEmail;
            }
            string? customerUsername = HttpContext.Session.GetString("CurrentUsername");
            if (customerUsername != null)
            {
                ViewBag.CustUsername = (string)customerUsername;
            }
            string? customerPassword = HttpContext.Session.GetString("CurrentPassword");
            if (customerPassword != null)
            {
                ViewBag.CustPassword = (string)customerPassword;
            }
            return View(new Customer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Profile(Customer customer)
        {
            try
            {
                CustomerManager.Update(_context, customer);
                return RedirectToAction(nameof(ThankYou));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ThankYou()
        {
            return View();
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
