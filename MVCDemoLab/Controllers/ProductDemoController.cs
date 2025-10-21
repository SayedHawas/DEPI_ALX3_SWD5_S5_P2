using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCDemoLab.Data;
using MVCDemoLab.Models;

namespace MVCDemoLab.Controllers
{
    public class ProductDemoController : Controller
    {
        private readonly MVCDbContext _dbcontext;
        public ProductDemoController(MVCDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        // GET: ProductDemoController
        public ActionResult Index()
        {
            var products = _dbcontext.Products.Include("Category").AsNoTracking().ToList();
            return View(products);
        }

        // GET: ProductDemoController/Details/5
        public ActionResult Details(int id)
        {
            var product = _dbcontext.Products.Find(id);
            return View(product);
        }

        // GET: ProductDemoController/Create
        public ActionResult Create()
        {
            //var t = from product in _dbcontext.Products
            //        select new { product.CategotyId, product.Name };


            var cate = _dbcontext.Categories.ToList();
            ViewBag.CategotyId = new SelectList(cate, "CategotyId", "Name");
            return View();
        }

        // POST: ProductDemoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategotyId = new SelectList(_dbcontext.Categories.ToList(), "CategotyId", "Name", product.CategotyId);
                return View(product);
            }
            try
            {
                _dbcontext.Products.Add(product);
                _dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductDemoController/Edit/5
        public ActionResult Edit(int id)
        {


            var product = _dbcontext.Products.Find(id);
            ViewBag.CategotyId = new SelectList(_dbcontext.Categories.ToList(), "CategotyId", "Name", product.CategotyId);
            return View(product);
        }

        // POST: ProductDemoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
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

        // GET: ProductDemoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductDemoController/Delete/5
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
