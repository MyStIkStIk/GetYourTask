using DailyProg.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using DailyProg.Logic;

namespace DailyProg.Controllers
{
    public class AccountController : Controller
    {
        readonly DbConnect _connect;
        readonly AuthorizationActions _authorization;
        public AccountController(DbConnect connect, TasksLogic task, AuthorizationActions authorization)
        {
            _connect = connect;
            _authorization = authorization;
        }
        public IActionResult Register()
        {
            return View(new RegistrationModel());
        }
        private async Task SignInAsync(UserModel user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserID.ToString()),
                new Claim(ClaimTypes.Role, "User"),
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);
        }
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserModel model)
        {
            RegistrationModel resultModel = new RegistrationModel()
            {
                UserEmail = model.UserEmail,
                UserPassword = PasswordHasher.HashPassword(model.UserPassword)
            };
            if (ModelState.IsValid)
            {
                var result = await _authorization.SignIn(_connect, resultModel);
                if (result.Status == Models.StatusCode.OK)
                {
                    await SignInAsync(result.Data);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Register", resultModel);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserPassword = PasswordHasher.HashPassword(model.UserPassword);
                var result = await _authorization.SignUp(_connect, model);
                if (result.Status == Models.StatusCode.OK)
                {
                    await SignInAsync(result.Data);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Register", model);
        }
    }
}
