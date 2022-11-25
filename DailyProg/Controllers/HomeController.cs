using DailyProg.Models;
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
using System.Threading.Tasks;

namespace DailyProg.Controllers
{
    public class HomeController : Controller
    {
        readonly DbConnect _connect;
        readonly Tasks _tasks;
        public HomeController(DbConnect connect, Tasks task)
        {
            _connect = connect;
            _tasks = task;
        }
        public IActionResult Index()
        {
            _tasks.GetAllTasks(_connect);
            return View(_tasks);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNTask(string Ntask)
        {
            var result = await _tasks.CreateNTask(_connect, Ntask);
            if (result.Status == Models.StatusCode.OK)
            {
                return Json("Ok");
            }
            else
            {
                return Error();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
