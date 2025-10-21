using Microsoft.AspNetCore.Mvc;
using MVCDemoLab.Data;
using MVCDemoLab.ViewModels;

namespace MVCDemoLab.Controllers
{
    public class UsersController : Controller
    {
        private readonly MVCDbContext _dbContext;

        public UsersController(MVCDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var entryUser = _dbContext.Users.
                 FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
            if (entryUser == null)
            {
                ViewBag.ErrorLogin = "UserName Or Password are inValid...";
                return View();
            }
            return RedirectToAction("Index", controllerName: "Home");
        }
    }
}
