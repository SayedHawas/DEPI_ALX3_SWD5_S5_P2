using Microsoft.AspNetCore.Mvc;

namespace MVCDemoLab.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Welcome in Test With MVC ";
            return View();
        }

        public double div(double x, double y)
        {
            return x / y;
        }
    }
}
