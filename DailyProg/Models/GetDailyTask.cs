using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DailyProg.Models
{
    public class GetDailyTask
    {
        public string CurrentDay { get; set; }
        public List<GetDTask> Tasks { get; set; }
        public GetDailyTask(IDbConnection connect)
        {
            using(IDbConnection database = connect)
            {
                Tasks = database.Query<GetDTask>("SELECT Time, Task FROM dbo.DailyTask WHERE Date = CONVERT(date, SYSDATETIMEOFFSET())").ToList();
            }
            CurrentDay = DateTime.Now.ToString("dd.MM");
        }
    }
    public class GetDTask
    {
        public TimeSpan Time { get; set; }
        public string Task { get; set; }
        public GetDTask(TimeSpan time, string task)
        {
            Time = time;
            Task = task;
        }
    }
}
