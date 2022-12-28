using Employee_Signing_System.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Signing_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManage;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager)
        {
            this.userManage = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Guard");
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(Register_VM model)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                };
                var result = await userManage.CreateAsync(user, model.Password); 

                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Guard");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }   

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Index", "Guard");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("login")]
        public async Task<IActionResult> Login(Login_VM model)
        {
            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent:model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Guard");
                }
                
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                    
            }
            return View(model);
        }

    }
}
