
//Created By: Tim and Xavier
//Purpose: Controls the Home, Contact, Employees Contact, About, Packages, and Create Booking actions.


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelExpertsData;

namespace TravelExpertsWebApp.Controllers
{
    public class TravelExpertsController : Controller
    {
        private TravelExpertsContext _context { get; set; }
        // context inject to the contructor
        public TravelExpertsController (TravelExpertsContext context) { _context = context; }

        // GET: TravelExpertsController Homepage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Employees()
        {
            List<Employee> employees = null;
            try
            {
                employees = EmployeeManager.GetEmployees(_context);
            }
            catch (Exception)
            {
                TempData["Message"] = "Database connection error. Try again later.";
                TempData["IsError"] = true;
            }
            return View(employees);
        }


        public ActionResult Packages()
        {
            //List<Package> packages = PackageManager.GetPackages(_context);
            //var list = new SelectList(packages, "ID" "Name").ToList();
            //list.Insert(0, new SelectedItemList("All", "All"));
            //ViewBag.Packages = list;

            //List<Package> packages = PackageManager.GetPackages(_context);
            //return View(packages);

            List<Package> packages = PackageManager.GetPackages(_context);
            return View(packages);
        }


        [Authorize]
        // GET: AccountController/Create
        public ActionResult CreateBooking(int id)
        {
            int? custid = HttpContext.Session.GetInt32("CurrentCustomer");
            ViewBag.SelectedPackageId = id;
            ViewBag.MyCustID = custid;

            ViewData["CustomerId"] = new SelectList(_context.Bookings, "CustomerId");
            ViewData["PackageId"] = new SelectList(_context.Bookings, "PackageId");
            ViewData["TravelerCount"] = new SelectList(_context.Bookings, "Traveler Count");

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateBooking([Bind("CustomerId, PackageId, TravelerCount")] Booking newBooking)
        {
            _context.Add(newBooking);
            await _context.SaveChangesAsync();
            return RedirectToAction("MyBookings", "Account");
        }



        // GET: TravelExpertsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TravelExpertsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TravelExpertsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TravelExpertsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TravelExpertsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TravelExpertsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TravelExpertsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
