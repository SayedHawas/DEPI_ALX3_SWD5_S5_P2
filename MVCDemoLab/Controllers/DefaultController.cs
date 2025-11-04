using Microsoft.AspNetCore.Mvc;

namespace MVCDemoLab.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DemoRouting(int id, string name)
        {
            return Content($"id {id} name {name}");
        }
    }
}
