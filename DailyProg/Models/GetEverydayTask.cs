using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DailyProg.Models
{
    public class GetEverydayTask
    {
        public string CurrentDay { get; set; }
        public List<GetETask> Tasks { get; set; }
        public GetEverydayTask(IDbConnection connect)
        {
            using (IDbConnection database = connect)
            {
                Tasks = database.Query<GetETask>("SELECT Time, Task FROM dbo.EverydayTask").ToList();
            }
        }
    }
    public class GetETask
    {
        public TimeSpan Time { get; set; }
        public string Task { get; set; }
        public GetETask(TimeSpan time, string task)
        {
            Time = time;
            Task = task;
        }
    }
}
