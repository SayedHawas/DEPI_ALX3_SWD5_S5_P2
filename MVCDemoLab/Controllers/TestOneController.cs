using Microsoft.AspNetCore.Mvc;

namespace MVCDemoLab.Controllers
{
    public class TestOneController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("session1", "welcome in My site Until Brower Closes");
            //send data Between
            TempData["FullRequest"] = "TempData";
            ViewData["ViewDataVal"] = "View Data ";
            ViewBag.viewbagval = "View bag ";

            return RedirectToAction("Show");
        }

        public ActionResult Show()
        {
            return View();
        }
    }
}
