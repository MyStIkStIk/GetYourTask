using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Threading.Tasks;

namespace DailyProg.Models
{
    public class Tasks : DTask
    {
        public List<NTask> NTasks { get; set; }
        public List<ETask> ETasks { get; set; }
        public List<ETask> DTasks { get; set; }
        public void GetAllTasks(DbConnect connect)
        {
            using (IDbConnection database = connect.Connect)
            {
                NTasks = database.Query<NTask>("SELECT TaskID,Task FROM NoTermTask").ToList();
                ETasks = database.Query<ETask>("SELECT TaskID, Time, Task FROM EverydayTask").ToList();
                DTasks = database.Query<ETask>("SELECT TaskID, Time, Task FROM DailyTask WHERE MONTH(Date) = MONTH(GETDATE()) AND DAY(Date) = DAY(GETDATE()) AND YEAR(Date) <= YEAR(GETDATE())").ToList();
            }
        }
        public async Task<BaseResponce<bool>> CreateNTask(DbConnect connect, NTask task)
        {
            BaseResponce<bool> baseResponce = new BaseResponce<bool>();
            try
            {
                using (IDbConnection database = connect.Connect)
                {
                    await database.ExecuteAsync("INSERT INTO NoTermTask VALUES (1, @Task, 0)", task);
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
                    await database.ExecuteAsync("INSERT INTO EverydayTask VALUES (1, @Time, @Task, 0)", task);
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
                    await database.ExecuteAsync("INSERT INTO DailyTask VALUES (1, @Date, @Time, @Task, 0)", task);
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
        public int TaskID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int Done { get; set; }
    }
    public class NTask : MyTask
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        [Display(Prompt = "Write down task")]
        public string Task { get; set; }
    }
    public class ETask : NTask
    {
        [Required]
        [Display(Prompt = "Write down time for task")]
        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }
    }
    public class DTask : ETask
    {
        [Required]
        [Display(Prompt = "Write down date for task")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}

