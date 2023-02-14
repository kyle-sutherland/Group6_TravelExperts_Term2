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

        public ActionResult Profile()
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
