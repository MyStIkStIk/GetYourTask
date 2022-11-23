using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DailyProg.Models
{
    public class GetTasks
    {
        public string CurrentDay { get; set; }
        public List<GetNTask> NTasks { get; set; }
        public List<GetETask> ETasks { get; set; }
        public List<GetETask> DTasks { get; set; }
        public GetTasks(IDbConnection connect)
        {
            using (IDbConnection database = connect)
            {
                NTasks = database.Query<GetNTask>("SELECT Task FROM dbo.NoTermTask").ToList();
                ETasks = database.Query<GetETask>("SELECT Time, Task FROM dbo.EverydayTask").ToList();
                DTasks = database.Query<GetETask>("SELECT Time, Task FROM dbo.DailyTask WHERE Date = CONVERT(date, SYSDATETIMEOFFSET())").ToList();
            }
            CurrentDay = DateTime.Now.ToString("dd.MM");
        }
    }
    public class GetNTask
    {
        public string Task { get; set; }
    }
    public class GetETask: GetNTask
    {
        public string Time { get; set; }
        public GetETask(TimeSpan time, string task)
        {
            if (time.Minutes == 0)
                Time = time.Hours + ":" + time.Minutes + "0";
            else if (time.Minutes > 0 && time.Minutes < 10)
                Time = time.Hours + ":0" + time.Minutes;
            else
                Time = time.Hours + ":" + time.Minutes;
            Task = task;
        }
    }
}
