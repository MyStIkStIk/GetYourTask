using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DailyProg.Models
{
    public class GetNotermTask
    {
        public string CurrentDay { get; set; }
        public List<GetNTask> Tasks { get; set; }
        public GetNotermTask(IDbConnection connect)
        {
            using (IDbConnection database = connect)
            {
                Tasks = database.Query<GetNTask>("SELECT Task FROM dbo.NoTermTask").ToList();
            }
        }
    }
    public class GetNTask
    {
        public string Task { get; set; }
        public GetNTask(string time, string task)
        {
            Task = task;
        }
    }
}
