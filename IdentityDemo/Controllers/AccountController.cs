using IdentityDemo.Models;
using IdentityDemo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registry()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registry(RegisterUserViewModel regUser)
        {
            //Check ModelState
            if (!ModelState.IsValid)
            {
                return View(regUser);
            }
            //DB
            //Mapping 
            ApplicationUser newUser = new ApplicationUser()
            {
                UserName = regUser.UserName,
                Email = regUser.Email,
                //PasswordHash = ,
                Address = regUser.Address,
                FirstName = regUser.FirstName,
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, regUser.Password);
            if (result.Succeeded)
            {
                //routing
                return RedirectToAction("Login");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }
            //routing
            return View(regUser);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel logUser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await _userManager.FindByNameAsync(logUser.Username);

                if (currentUser != null)
                {
                    bool userFound = await _userManager.CheckPasswordAsync(currentUser, logUser.Password);
                    if (userFound)
                    {
                        await _signInManager.SignInAsync(currentUser, logUser.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "User Name Or Password Invalid ....");
            }
            return View(logUser);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
