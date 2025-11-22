using Microsoft.AspNetCore.Mvc;

namespace MVCDemoLab.Controllers
{
    //[Authorize]
    //[HandlerError]
    public class FilterDemoController : Controller
    {
        //[Authorize]
        //[AllowAnonymous]
        [CustomFilter]
        public IActionResult Index()
        {
            return View();
        }
        //[Authorize]
        public IActionResult ShowData()
        {
            return View();
        }
        //[HandlerError]
        public IActionResult Error()
        {
            throw new Exception();
        }
        //[HandlerError]
        public IActionResult ErrorTwo()
        {
            throw new Exception();
        }
    }
}
