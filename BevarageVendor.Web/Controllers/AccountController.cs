using Entities.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels;

public class AccountController : Controller
{
    private SignInManager<User> _signInManager;
    private UserManager<User> _userManager;
    public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel user)
    {
        if (ModelState.IsValid)
        {
            var userName = await _userManager.FindByEmailAsync(user.Email);
            var checkPassword  = await _userManager.CheckPasswordAsync(userName, user.Password);
            if (checkPassword)
            {
             var result =  await _signInManager.PasswordSignInAsync(userName.UserName,user.Password,user.RememberMe,  false);
            
                return Redirect(nameof(Dashboard)); 
            }
            

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

        }
        return View(user);
    }

    [Authorize(Roles = "ADMINISTRATOR")]
    [HttpGet]
    public IActionResult Dashboard()
    {
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Login");
    }
}
