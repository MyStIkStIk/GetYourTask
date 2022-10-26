using System;
using System.Data;

namespace DailyProg.Models
{
    public class GetTasks
    {
        public GetDailyTask DailyTasks { get; }
        public GetEverydayTask EverydayTasks { get; }
        public GetDailyTask NotermsTasks { get; }
        public GetTasks(IDbConnection connect)
        {
            DailyTasks = new GetDailyTask(connect);
            EverydayTasks = new GetEverydayTask(connect);
            NotermsTasks = new GetDailyTask(connect);
        }
    }
}
