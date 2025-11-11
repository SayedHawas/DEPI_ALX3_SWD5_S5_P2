using Microsoft.AspNetCore.Mvc;

namespace MVCDemoLab.Controllers
{
    public class FullCategoriesController : Controller
    {
        private readonly IServiceCategory _service;
        public FullCategoriesController(IServiceCategory service)
        {
            this._service = service;
        }
        // GET: FullCategories
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetCategoriesAsync());
        }
        // GET: FullCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await _service.GetCategoryByIDAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        // GET: FullCategories/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: FullCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _service.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        // GET: FullCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await _service.GetCategoryByIDAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        // POST: FullCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.CategotyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.UpdateCategory(category);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message.ToString());
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        // GET: FullCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await _service.GetCategoryByIDAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        // POST: FullCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _service.GetCategoryByIDAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _service.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
