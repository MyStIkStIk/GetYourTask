using DailyProg.Models;
using Dapper;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DailyProg.Jobs
{
    public class TasksUpdater : IJob
    {
        List<Guid> DUsers;
        List<Guid> EUsers;
        List<Guid> NUsers;
        List<Done> Done;
        DbConnect _connect;
        public TasksUpdater([FromServices] DbConnect connect)
        {
            _connect = connect;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            using(IDbConnection connect = _connect.Connect)
            {
                DUsers = connect.Query<Guid>("SELECT UserID FROM DailyTask WHERE Done = 1").ToList();
                EUsers = connect.Query<Guid>("SELECT UserID FROM EverydayTask WHERE Done = 1").ToList();
                NUsers = connect.Query<Guid>("SELECT UserID FROM NoTermTask WHERE Done = 1").ToList();
                Done = connect.Query<Done>("SELECT UserID, TasksDone FROM UserInfo").ToList();
                List<Guid> Users = new List<Guid>();
                Users.AddRange(DUsers);
                Users.AddRange(EUsers);
                Users.AddRange(NUsers);
                foreach (var item in Done)
                {
                    if (Users.Contains(item.UserID))
                    {
                        int count = Users.FindAll(delegate (Guid user)
                        {
                            return user == item.UserID;
                        }).Count;
                        item.TasksDone += count;
                        await connect.ExecuteAsync("UPDATE UserInfo SET TasksDone = @TasksDone WHERE UserID = @UserID", item);
                    }
                }
                await connect.ExecuteAsync("DELETE FROM DailyTask WHERE Done = 1 OR Date < CONVERT(date, GETDATE())");
                await connect.ExecuteAsync("UPDATE EverydayTask SET Done = 0 WHERE Done = 1");
                await connect.ExecuteAsync("DELETE FROM NoTermTask WHERE Done = 1");
            }
        }
    }
    class Done
    {
        public Guid UserID { get; set; }
        public int TasksDone { get; set; }
    }
}
