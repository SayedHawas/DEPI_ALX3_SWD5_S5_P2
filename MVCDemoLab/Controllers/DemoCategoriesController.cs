using Microsoft.AspNetCore.Mvc;
using MVCDemoLab.Data;
using MVCDemoLab.Models;

namespace MVCDemoLab.Controllers
{
    public class DemoCategoriesController : Controller
    {
        private readonly MVCDbContext _dbContext;
        public DemoCategoriesController(MVCDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IActionResult Index()
        {
            //ViewData object Case
            //ViewBag  Dynamic

            ViewData["AppName"] = "Welcome in View Data";
            ViewData.Add("Number1", 150);
            ViewData.Add("Number2", 150);

            ViewBag.N1 = 2548;
            ViewBag.N2 = 150;

            //Model
            var list = _dbContext.Categories.ToList();
            return View("Views/DemoCategories/IndexDemo.cshtml", list);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category newCategory)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.IsValid.ToString();
                return View(newCategory);
            }
            _dbContext.Categories.Add(newCategory);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
