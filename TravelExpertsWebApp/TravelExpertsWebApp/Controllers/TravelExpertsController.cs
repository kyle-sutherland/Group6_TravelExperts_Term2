using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelExpertsData;

namespace TravelExpertsWebApp.Controllers
{
    public class TravelExpertsController : Controller
    {
        private TravelExpertsContext _context { get; set; }
        // context inject ot the contructor
        public TravelExpertsController (TravelExpertsContext context) { _context = context; }

        // GET: TravelExpertsController Homepage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Packages()
        {
            //List<Package> packages = PackageManager.GetPackages(_context);
            //var list = new SelectList(packages, "ID" "Name").ToList();
            //list.Insert(0, new SelectedItemList("All", "All"));
            //ViewBag.Packages = list;

            //List<Package> packages = PackageManager.GetPackages(_context);
            //return View(packages);



            return View();
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
