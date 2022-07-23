using BugTrackerWeb.Data;
using BugTrackerWeb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BugTrackerWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult RegisterAccount()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult RegisterAccount(Account acc)
        {
            foreach(Account account in _db.Accounts)
            {
                if (account.UserName == acc.UserName)
                {
                    TempData["ErrorUserName"] = "Anzeigename ist bereits vergeben";
                    return View("RegisterAccount");
                    
                }
                if(account.Email == acc.Email)
                {
                    TempData["ErrorEmail"] = "E-Mail ist bereits vergeben";
                    return View("RegisterAccount");
                }
            }
            if (ModelState.IsValid)
            {
                _db.Update(acc);
                _db.SaveChanges();
            }
            ViewData["Success"] = "Registrierung Erfolgreich";
            return View("Login");
        }
        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");

        }
        [HttpPost("login")]
        public async Task<IActionResult> Validate(string username, string password, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (username == "Daniel" && password == "Apfel")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("username", username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                claims.Add(new Claim(ClaimTypes.Name, username));   
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                
            }
            else
            {
                foreach(Account acc in _db.Accounts)
                {
                    if(acc.UserName == username && acc.Password == password)
                    {
                        var claims = new List<Claim>();
                        claims.Add(new Claim("username", username));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                        claims.Add(new Claim(ClaimTypes.Name, acc.UserName));   
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        if (returnUrl != null)
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            TempData["Error"] = "Error, Username oder Passwort ist inkorrekt";
            return View("login");
        }
    }
}
