using Microsoft.AspNetCore.Mvc;

namespace MVCDemoLab.Controllers
{
    public class StatueDemoController : Controller
    {

        public IActionResult Index(string x)
        {
            var name = HttpContext.Request.Query["name"];
            //ViewBag.Name = name;
            return Content($" form Query string {name} ");

        }
        public IActionResult SetTempData()
        {
            TempData["AppName"] = "Smart software";
            return Content("Save Data into Temp Data ");
        }
        //public IActionResult GetFirst()
        //{
        //    string name = "Empty Name ";
        //    if (TempData.ContainsKey("AppName"))
        //    {
        //        //normal read
        //        name = TempData["AppName"].ToString();
        //    }

        //    return Content(" get Data " + name + " Please check cookies ...");
        //}

        // Peek
        public IActionResult GetFirst()
        {
            string name = "Empty Name ";
            if (TempData.ContainsKey("AppName"))
            {
                name = TempData.Peek("AppName").ToString();

            }
            return Content(" get Data " + name + " Please check cookies ...");
        }

        public IActionResult GetSecond()
        {
            string name = "No Name";
            if (TempData.ContainsKey("AppName"))
            {
                name = TempData["AppName"].ToString();
            }
            return Content(" get Data " + name + " Please check cookies ...");
        }


        public IActionResult SetCookies()
        {
            Response.Cookies.Append("AppName", "Smart software");  //Session Cookies 20 Min
            Response.Cookies.Append("Number", "120");

            return Content("Cookies Saving ....");
        }

        public IActionResult GetCookies()
        {
            string appName = Request.Cookies["AppName"];
            int Number = int.Parse(Request.Cookies["Number"]);

            return Content($"Cookies:{appName} & {Number}");
        }

        public IActionResult SetCookiesPersistent()
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTimeOffset.Now.AddDays(15);
            //cookieOptions.Expires = DateTimeOffset.Now.AddDays(-1);
            Response.Cookies.Append("CompanyName", "Smart software", cookieOptions);

            return Content("Cookies Persistent Saving ....");
        }

        public IActionResult RemoveCookies()
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTimeOffset.Now.AddDays(-1);
            Response.Cookies.Append("CompanyName", "Smart software", cookieOptions);
            return Content("Cookies Remove ....");
        }


        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("name", "Sayed");
            HttpContext.Session.SetInt32("Counter", 100);
            return Content("Save Session ");
        }
        public IActionResult GetSession()
        {
            string name = HttpContext.Session.GetString("name");
            int? counter = HttpContext.Session.GetInt32("Counter");
            return Content($"Name {name} & Counter {counter}  ");
        }

    }
}
