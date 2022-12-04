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
        public async Task<IActionResult> CreateDTask(DTask model)
        {
            if (ModelState.IsValid)
            {
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
