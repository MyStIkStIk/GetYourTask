using System.Data;
using System.Threading.Tasks;
using System;
using Dapper;
using System.Linq;
using System.Collections.Generic;

namespace DailyProg.Models
{
    public partial class TasksLogic : DTask
    {
        public void GetAllTasks(DbConnect connect, Guid Id)
        {
            using (IDbConnection database = connect.Connect)
            {
                NTasks = database.Query<NTask>("SELECT TaskID,Task, Done FROM NoTermTask WHERE UserID = @UserId", new { UserId = Id }).ToList();
                ETasks = database.Query<ETask>("SELECT TaskID, Time, Task, Done FROM EverydayTask  WHERE UserID = @UserId", new { UserId = Id }).ToList();
                DTasks = database.Query<ETask>("SELECT TaskID, Time, Task, Done FROM DailyTask WHERE MONTH(Date) = MONTH(GETDATE()) AND DAY(Date) = DAY(GETDATE()) AND YEAR(Date) <= YEAR(GETDATE()) AND UserID = @UserId", new { UserId = Id }).ToList();
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
                    if (task.Done == false)
                    {
                        await database.ExecuteAsync("UPDATE NoTermTask SET Done = 1 WHERE TaskID = @TaskID", task);
                    }
                    if (task.Done == true)
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
                    if (task.Done == false)
                    {
                        await database.ExecuteAsync("UPDATE EverydayTask SET Done = 1 WHERE TaskID = @TaskID", task);
                    }
                    if (task.Done == true)
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
                    if (task.Done == false)
                    {
                        await database.ExecuteAsync("UPDATE DailyTask SET Done = 1 WHERE TaskID = @TaskID", task);
                    }
                    if (task.Done == true)
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
}
