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
        readonly TasksLogic _tasks;
        public HomeController(DbConnect connect, TasksLogic task)
        {
            _connect = connect;
            _tasks = task;
        }
        [Authorize]
        public IActionResult Index()
        {
            _tasks.GetAllTasks(_connect, Guid.Parse(HttpContext.User.Identity.Name));
            return View(_tasks);
        }
    }
}
