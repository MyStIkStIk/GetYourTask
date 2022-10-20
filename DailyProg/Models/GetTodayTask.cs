using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DailyProg.Models
{
    public class GetTodayTask
    {
        public string CurrentDay { get; set; }
        public List<GetTask> Tasks { get; set; }
        string connection = "Server=VLAD1CK\\SQLEXPRESS;Database=Daily;Trusted_Connection=True;";
        public GetTodayTask()
        {
            CurrentDay = DateTime.Now.ToString("dd.MM");
            Tasks = new List<GetTask>();
            for (int i = 1; i <= 10; i++)
            {
                Tasks.Add(new GetTask(DateTime.Now.ToString("mm:ff"), "Написать ежедневник Написать ежедневник Написать ежедневник Написать ежедневник"));
            }
        }
    }
    public class GetTask
    {
        public string Time { get; set; }
        public string Task { get; set; }
        public GetTask(string time, string task)
        {
            Time = time;
            Task = task;
        }
    }
}
