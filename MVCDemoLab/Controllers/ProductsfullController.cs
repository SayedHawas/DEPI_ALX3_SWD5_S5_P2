using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MVCDemoLab.Controllers
{
    public class ProductsfullController : Controller
    {

        [TempData]
        public string MessageAdd { get; set; }
        [TempData]
        public string MessageDelete { get; set; }


        private readonly MVCDbContext _context;

        public ProductsfullController(MVCDbContext context)
        {
            _context = context;
        }

        // GET: Productsfull
        public async Task<IActionResult> Index()
        {
            var mVCDbContext = _context.Products.Include(p => p.Category);

            //ImagePath = 1.jpg
            // wwwroot/Images/Products/ 1.jpg

            List<Product> products = new List<Product>();
            foreach (var item in mVCDbContext)
            {
                if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", item.ImagePath)))
                {
                    products.Add(item);
                }
                else
                {
                    item.ImagePath = "";
                    products.Add(item);
                }
            }
            return View(products.ToList());
        }

        // GET: Productsfull/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            if (!System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", product.ImagePath)))
            {
                product.ImagePath = "";
            }
            return View(product);

        }

        // GET: Productsfull/Create
        public IActionResult Create()
        {
            ViewData["CategotyId"] = new SelectList(_context.Categories, "CategotyId", "Name");
            return View();
        }

        // POST: Productsfull/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ProductId,Name,Price,Description,ImagePath,CategotyId")] Product product)
        public async Task<IActionResult> Create([ModelBinder(typeof(ProductBinder))] Product product, IFormFile ImagePath)
        {
            //if (product.CategotyId == 0)
            //{
            //    ModelState.AddModelError("CategotyId", "Must Select Category");
            //    ViewData["CategotyId"] = new SelectList(_context.Categories, "CategotyId", "Name");
            //    return View(product);
            //}
            //Naming File On Server 
            string _Extenstion = Path.GetExtension(ImagePath.FileName);
            string _fileName = DateTime.Now.ToString("yyMMddhhmmssfff") + _Extenstion;


            //Upload File
            if (ImagePath != null && ImagePath.Length > 0)
            {
                //~
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", _fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImagePath.CopyToAsync(stream);
                }
                product.ImagePath = _fileName;
            }
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();

                    MessageAdd = $"Product {product.Name} added ...";
                    TempData.Keep("MessageAdd");
                    return RedirectToAction(nameof(Index));
                }
                ViewData["CategotyId"] = new SelectList(_context.Categories, "CategotyId", "Name", product.CategotyId);
                return View(product);
            }
            catch (Exception ex)
            {
                //All
                ModelState.AddModelError(string.Empty, ex.Message.ToString());
                return View(product);
            }
        }
        [Authorize]
        // GET: Productsfull/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            if (!System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", product.ImagePath)))
            {
                product.ImagePath = "";
            }
            ViewData["CategotyId"] = new SelectList(_context.Categories, "CategotyId", "Name", product.CategotyId);
            return View(product);
        }

        // POST: Productsfull/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product, IFormFile ImagePath)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }
            //Check If Image Exist Delete before Add New One 
            //Upload File
            if (ImagePath != null && ImagePath.Length > 0)
            {
                string _Extenstion = Path.GetExtension(ImagePath.FileName);
                string _fileName = DateTime.Now.ToString("yyMMddhhmmssfff") + _Extenstion;
                //~
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", _fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImagePath.CopyToAsync(stream);
                }
                product.ImagePath = _fileName;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ViewData["CategotyId"] = new SelectList(_context.Categories, "CategotyId", "Name", product.CategotyId);
                        return View(product);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategotyId"] = new SelectList(_context.Categories, "CategotyId", "Name", product.CategotyId);
            return View(product);
        }

        // GET: Productsfull/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            if (!System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", product.ImagePath)))
            {
                product.ImagePath = "";
            }
            return View(product);
        }

        // POST: Productsfull/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            TempData["MessageDelete"] = $"Product {product.Name} successfully deleted!";
            TempData.Keep("MessageDelete");
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        public async Task<IActionResult> Card(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", product.ImagePath)))
            {
                return View(product);
            }
            else
            {
                product.ImagePath = "";
                return View(product);
            }
        }
        //public async Task<IActionResult> Gallery()
        //{
        //    return View(await _context.Products.ToListAsync());
        //}
        public async Task<IActionResult> Gallery(int page = 1, int pageSize = 6)
        {
            var totalItems = await _context.Products.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var products = await _context.Products
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // var products = _context.Products.AsQueryable().Skip((page - 1) * pageSize).Take(pageSize) ;


            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItems = totalItems;


            return View(products);
        }

        //Validation Method 
        public IActionResult CheckPrice(decimal Price)
        {
            if (Price > 100)
            {
                return Json(true);
            }
            return Json(false);
        }

    }
}
