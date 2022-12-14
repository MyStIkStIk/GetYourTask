using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Policy;
using System.Threading.Tasks;

namespace DailyProg.Models
{
    public class Tasks : DTask
    {
        public List<NTask> NTasks { get; set; }
        public List<ETask> ETasks { get; set; }
        public List<ETask> DTasks { get; set; }
        public void GetAllTasks(DbConnect connect, Guid Id)
        {
            using (IDbConnection database = connect.Connect)
            {
                NTasks = database.Query<NTask>("SELECT TaskID,Task FROM NoTermTask WHERE UserID = @UserId", new { UserId = Id }).ToList();
                ETasks = database.Query<ETask>("SELECT TaskID, Time, Task FROM EverydayTask  WHERE UserID = @UserId", new { UserId = Id }).ToList();
                DTasks = database.Query<ETask>("SELECT TaskID, Time, Task FROM DailyTask WHERE MONTH(Date) = MONTH(GETDATE()) AND DAY(Date) = DAY(GETDATE()) AND YEAR(Date) <= YEAR(GETDATE()) AND UserID = @UserId", new { UserId = Id }).ToList();
            }
        }
        public async Task<BaseResponce<bool>> CreateNTask(DbConnect connect, NTask task)
        {
            BaseResponce<bool> baseResponce = new BaseResponce<bool>();
            try
            {
                using (IDbConnection database = connect.Connect)
                {
                    await database.ExecuteAsync("INSERT INTO NoTermTask VALUES (@UserID, @Task, 0)", task);
                }
                baseResponce.Data = true;
                baseResponce.Status = StatusCode.OK;
            }
            catch (Exception ex)
            {
                baseResponce.Message = ex.Message;
                baseResponce.Status = StatusCode.Error;
            }
            return baseResponce;
        }
        public async Task<BaseResponce<bool>> CreateETask(DbConnect connect, ETask task)
        {
            BaseResponce<bool> baseResponce = new BaseResponce<bool>();
            try
            {
                using (IDbConnection database = connect.Connect)
                {
                    await database.ExecuteAsync("INSERT INTO EverydayTask VALUES (@UserID, @Time, @Task, 0)", task);
                }
                baseResponce.Data = true;
                baseResponce.Status = StatusCode.OK;
            }
            catch (Exception ex)
            {
                baseResponce.Message = ex.Message;
                baseResponce.Status = StatusCode.Error;
            }
            return baseResponce;
        }
        public async Task<BaseResponce<bool>> CreateDTask(DbConnect connect, DTask task)
        {
            BaseResponce<bool> baseResponce = new BaseResponce<bool>();
            try
            {
                using (IDbConnection database = connect.Connect)
                {
                    await database.ExecuteAsync("INSERT INTO DailyTask VALUES (@UserID, @Date, @Time, @Task, 0)", task);
                }
                baseResponce.Data = true;
                baseResponce.Status = StatusCode.OK;
            }
            catch (Exception ex)
            {
                baseResponce.Message = ex.Message;
                baseResponce.Status = StatusCode.Error;
            }
            return baseResponce;
        }
        public async Task<BaseResponce<bool>> ChangeNTask(DbConnect connect, NTask task)
        {
            BaseResponce<bool> baseResponce = new BaseResponce<bool>();
            try
            {
                using (IDbConnection database = connect.Connect)
                {
                    await database.ExecuteAsync("UPDATE NoTermTask SET Task = @Task WHERE TaskID = @TaskID", task);
                }
                baseResponce.Data = true;
                baseResponce.Status = StatusCode.OK;
            }
            catch (Exception ex)
            {
                baseResponce.Message = ex.Message;
                baseResponce.Status = StatusCode.Error;
            }
            return baseResponce;
        }
        public async Task<BaseResponce<bool>> ChangeETask(DbConnect connect, ETask task)
        {
            BaseResponce<bool> baseResponce = new BaseResponce<bool>();
            try
            {
                using (IDbConnection database = connect.Connect)
                {
                    await database.ExecuteAsync("UPDATE EverydayTask SET Task = @Task, Time = @Time WHERE TaskID = @TaskID", task);
                }
                baseResponce.Data = true;
                baseResponce.Status = StatusCode.OK;
            }
            catch (Exception ex)
            {
                baseResponce.Message = ex.Message;
                baseResponce.Status = StatusCode.Error;
            }
            return baseResponce;
        }
        public async Task<BaseResponce<bool>> ChangeDTask(DbConnect connect, DTask task)
        {
            BaseResponce<bool> baseResponce = new BaseResponce<bool>();
            try
            {
                using (IDbConnection database = connect.Connect)
                {
                    await database.ExecuteAsync("UPDATE DailyTask SET Task = @Task, Time = @Time, Date = @Date WHERE TaskID = @TaskID", task);
                }
                baseResponce.Data = true;
                baseResponce.Status = StatusCode.OK;
            }
            catch (Exception ex)
            {
                baseResponce.Message = ex.Message;
                baseResponce.Status = StatusCode.Error;
            }
            return baseResponce;
        }
        public async Task<BaseResponce<bool>> DeleteNTask(DbConnect connect, int task)
        {
            BaseResponce<bool> baseResponce = new BaseResponce<bool>();
            try
            {
                using (IDbConnection database = connect.Connect)
                {
                    await database.ExecuteAsync("DELETE FROM NoTermTask WHERE TaskID = @TaskID", new { TaskID = task });
                }
                baseResponce.Data = true;
                baseResponce.Status = StatusCode.OK;
            }
            catch (Exception ex)
            {
                baseResponce.Message = ex.Message;
                baseResponce.Status = StatusCode.Error;
            }
            return baseResponce;
        }
        public async Task<BaseResponce<bool>> DeleteETask(DbConnect connect, int task)
        {
            BaseResponce<bool> baseResponce = new BaseResponce<bool>();
            try
            {
                using (IDbConnection database = connect.Connect)
                {
                    await database.ExecuteAsync("DELETE FROM EverydayTask WHERE TaskID = @TaskID", new { TaskID = task });
                }
                baseResponce.Data = true;
                baseResponce.Status = StatusCode.OK;
            }
            catch (Exception ex)
            {
                baseResponce.Message = ex.Message;
                baseResponce.Status = StatusCode.Error;
            }
            return baseResponce;
        }
        public async Task<BaseResponce<bool>> DeleteDTask(DbConnect connect, int task)
        {
            BaseResponce<bool> baseResponce = new BaseResponce<bool>();
            try
            {
                using (IDbConnection database = connect.Connect)
                {
                    await database.ExecuteAsync("DELETE FROM DailyTask WHERE TaskID = @TaskID", new { TaskID = task });
                }
                baseResponce.Data = true;
                baseResponce.Status = StatusCode.OK;
            }
            catch (Exception ex)
            {
                baseResponce.Message = ex.Message;
                baseResponce.Status = StatusCode.Error;
            }
            return baseResponce;
        }
        public async Task<BaseResponce<bool>> DoneNTask(DbConnect connect, MyTask task)
        {
            BaseResponce<bool> baseResponce = new BaseResponce<bool>();
            try
            {
                using (IDbConnection database = connect.Connect)
                {
                    if (task.Done == 0)
                    {
                        await database.ExecuteAsync("UPDATE NoTermTask SET Done = 1 WHERE TaskID = @TaskID", task);
                    }
                    if (task.Done == 1)
                    {
                        await database.ExecuteAsync("UPDATE NoTermTask SET Done = 0 WHERE TaskID = @TaskID", task);
                    }
                }
                baseResponce.Data = true;
                baseResponce.Status = StatusCode.OK;
            }
            catch (Exception ex)
            {
                baseResponce.Message = ex.Message;
                baseResponce.Status = StatusCode.Error;
            }
            return baseResponce;
        }
        public async Task<BaseResponce<bool>> DoneETask(DbConnect connect, MyTask task)
        {
            BaseResponce<bool> baseResponce = new BaseResponce<bool>();
            try
            {
                using (IDbConnection database = connect.Connect)
                {
                    if (task.Done == 0)
                    {
                        await database.ExecuteAsync("UPDATE EverydayTask SET Done = 1 WHERE TaskID = @TaskID", task);
                    }
                    if (task.Done == 1)
                    {
                        await database.ExecuteAsync("UPDATE EverydayTask SET Done = 0 WHERE TaskID = @TaskID", task);
                    }
                }
                baseResponce.Data = true;
                baseResponce.Status = StatusCode.OK;
            }
            catch (Exception ex)
            {
                baseResponce.Message = ex.Message;
                baseResponce.Status = StatusCode.Error;
            }
            return baseResponce;
        }
        public async Task<BaseResponce<bool>> DoneDTask(DbConnect connect, MyTask task)
        {
            BaseResponce<bool> baseResponce = new BaseResponce<bool>();
            try
            {
                using (IDbConnection database = connect.Connect)
                {
                    if (task.Done == 0)
                    {
                        await database.ExecuteAsync("UPDATE DailyTask SET Done = 1 WHERE TaskID = @TaskID", task);
                    }
                    if (task.Done == 1)
                    {
                        await database.ExecuteAsync("UPDATE DailyTask SET Done = 0 WHERE TaskID = @TaskID", task);
                    }
                }
                baseResponce.Data = true;
                baseResponce.Status = StatusCode.OK;
            }
            catch (Exception ex)
            {
                baseResponce.Message = ex.Message;
                baseResponce.Status = StatusCode.Error;
            }
            return baseResponce;
        }
    }
    public class MyTask
    {
        [HiddenInput(DisplayValue = false)]
        public Guid UserID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int TaskID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int Done { get; set; }
    }
    public class NTask : MyTask
    {
        [Required(ErrorMessage = "Write down your task")]
        [StringLength(50, MinimumLength = 1, ErrorMessage ="String length must be 1-50")]
        [Display(Prompt = "Write down task")]
        public string Task { get; set; }
    }
    public class ETask : NTask
    {
        [Required(ErrorMessage = "Choose the time")]
        [Display(Prompt = "Write down time for task")]
        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }
    }
    public class DTask : ETask
    {
        [Required(ErrorMessage = "choose a date")]
        [Display(Prompt = "Write down date for task")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}

