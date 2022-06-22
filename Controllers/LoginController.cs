using netchill.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netchill.Model;
using Microsoft.AspNetCore.Cors;


namespace netchill.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
         private readonly UserManager<IdentityUser> _userInManager;

        public LoginController(SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userInManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginVm req)
        {

            if (ModelState.IsValid)
            {
                var identityResult = await _signInManager.PasswordSignInAsync(req.Username, req.Password, req.RememberMe, false);
               // identityResult.
               
                if ((User.IsInRole("superuser") || req.Username == "netchill_admin") && identityResult.Succeeded)
                {
                    return RedirectToAction("Index", "Superuser");

                }
               else if (identityResult.Succeeded) //REACT TEMPLATE REDIRECT
                {
                    return RedirectToAction("Ui", "");
                }

                ModelState.AddModelError("", "Username or Password incorrect!");
            }
            return View();
        }


        


    }
}
