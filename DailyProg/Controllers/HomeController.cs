using DailyProg.Logic;
using DailyProg.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.Reflection;

namespace DailyProg.Controllers
{
    public class HomeController : Controller
    {
        readonly DbConnect _connect;
        readonly Tasks _tasks;
        readonly AuthorizationActions _authorization;
        public HomeController(DbConnect connect, Tasks task, AuthorizationActions authorization)
        {
            _connect = connect;
            _tasks = task;
            _authorization = authorization;
        }
        public IActionResult Register()
        {
            return View(new RegistrationModel());
        }
        [Authorize]
        public IActionResult Index()
        {
            _tasks.GetAllTasks(_connect, Guid.Parse(HttpContext.User.Identity.Name));
            return View(_tasks);
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
                    return RedirectToAction("Index");
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
                    return RedirectToAction("Index");
                }
            }
            return View("Register", model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDTask(DTask model)
        {
            if (ModelState.IsValid)
            {
                model.UserID = Guid.Parse(HttpContext.User.Identity.Name);
                var result = await _tasks.CreateDTask(_connect, model);
                if (result.Status == Models.StatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
            }
            return Error();
        }
        [HttpPost]
        public async Task<IActionResult> CreateETask(ETask model)
        {
            if (ModelState.IsValid)
            {
                model.UserID = Guid.Parse(HttpContext.User.Identity.Name);
                var result = await _tasks.CreateETask(_connect, model);
                if (result.Status == Models.StatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
            }
            return Error();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNTask(NTask model)
        {
            model.UserID = Guid.Parse(HttpContext.User.Identity.Name);
            var result = await _tasks.CreateNTask(_connect, model);
            if (result.Status == Models.StatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Error();
            }
        }
        [HttpPost]
        public async Task<IActionResult> ChangeDTask(DTask model)
        {
            if (ModelState.IsValid)
            {
                var result = await _tasks.ChangeDTask(_connect, model);
                if (result.Status == Models.StatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
            }
            return Error();
        }
        [HttpPost]
        public async Task<IActionResult> ChangeETask(ETask model)
        {
            if (ModelState.IsValid)
            {
                var result = await _tasks.ChangeETask(_connect, model);
                if (result.Status == Models.StatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
            }
            return Error();
        }
        [HttpPost]
        public async Task<IActionResult> ChangeNTask(NTask model)
        {
            var result = await _tasks.ChangeNTask(_connect, model);
            if (result.Status == Models.StatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Error();
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteDTask(int TaskID)
        {
            if (ModelState.IsValid)
            {
                var result = await _tasks.DeleteDTask(_connect, TaskID);
                if (result.Status == Models.StatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
            }
            return Error();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteETask(int TaskID)
        {
            if (ModelState.IsValid)
            {
                var result = await _tasks.DeleteETask(_connect, TaskID);
                if (result.Status == Models.StatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
            }
            return Error();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteNTask(int TaskID)
        {
            var result = await _tasks.DeleteNTask(_connect, TaskID);
            if (result.Status == Models.StatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Error();
            }
        }
        [HttpPost]
        public async Task<IActionResult> DoneDTask(MyTask model)
        {
            if (ModelState.IsValid)
            {
                var result = await _tasks.DoneDTask(_connect, model);
                if (result.Status == Models.StatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
            }
            return Error();
        }
        [HttpPost]
        public async Task<IActionResult> DoneETask(MyTask model)
        {
            if (ModelState.IsValid)
            {
                var result = await _tasks.DoneETask(_connect, model);
                if (result.Status == Models.StatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
            }
            return Error();
        }
        [HttpPost]
        public async Task<IActionResult> DoneNTask(MyTask model)
        {
            var result = await _tasks.DoneNTask(_connect, model);
            if (result.Status == Models.StatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Error();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
