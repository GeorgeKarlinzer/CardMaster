using CardMaster.Data;
using CardMaster.Server.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CardMaster.Server.Controllers
{
    public class AccountController : Controller
    {
        private CardMasterContext context;

        public AccountController(CardMasterContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm]LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var hash = Encryption.CalculatePasswordHash(loginModel.Password, loginModel.Username);
                
                User user = await context.Users.FirstOrDefaultAsync(u => u.Username == loginModel.Username && u.PasswordHash == hash);
                if (user != null)
                {
                    await Authenticate(user.Id); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Incorrect username or password");
            }

            return View(loginModel);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var isTaken = await context.Users.AnyAsync(u => u.Email == model.Email || u.Username == model.Username);
                if (!isTaken)
                {
                    var hash = Encryption.CalculatePasswordHash(model.Password, model.Username);

                    var user = new User { Username = model.Username, Email = model.Email, PasswordHash = hash, Created = DateTime.UtcNow };

                    context.Users.Add(user);
                    await context.SaveChangesAsync();

                    return RedirectToAction("Login", "Account");
                }
                else
                    ModelState.AddModelError("", "Username or Email is already taken");
            }
            return View(model);
        }

        private async Task Authenticate(int Id_User)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, Id_User.ToString())
            };
            // создаем объект ClaimsIdentity
            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
