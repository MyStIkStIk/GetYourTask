using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DailyProg.Models
{
    public class Tasks
    {
        [Display(Name = "Write down date for task")]
        [DataType(DataType.Date)]
        public string Date { get; set; }
        [Display(Name = "Write down time for task")]
        [DataType(DataType.Time)]
        public string Time { get; set; }
        [Display(Name = "Write down task")]
        public string Task { get; set; }

        public string CurrentDay { get; set; }
        public List<GetNTask> NTasks { get; set; }
        public List<GetETask> ETasks { get; set; }
        public List<GetETask> DTasks { get; set; }
        public void GetAllTasks(DbConnect connect)
        {
            using (IDbConnection database = connect.Connect)
            {
                NTasks = database.Query<GetNTask>("SELECT Task FROM dbo.NoTermTask").ToList();
                ETasks = database.Query<GetETask>("SELECT Time, Task FROM dbo.EverydayTask").ToList();
                DTasks = database.Query<GetETask>("SELECT Time, Task FROM dbo.DailyTask WHERE Date = CONVERT(date, SYSDATETIMEOFFSET())").ToList();
            }
            CurrentDay = DateTime.Now.ToString("dd.MM");
        }
        public async  Task<BaseResponce<bool>> CreateNTask(DbConnect connect, string task)
        {
            BaseResponce<bool> baseResponce = new BaseResponce<bool>();
            try
            {
                using (IDbConnection database = connect.Connect)
                {
                    await database.ExecuteAsync("INSERT INTO NoTermTask VALUES (@NTask)", new { NTask = task });
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
