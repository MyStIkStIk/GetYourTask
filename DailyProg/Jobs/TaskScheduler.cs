using Microsoft.AspNetCore.Mvc;
using Quartz;
using Quartz.Impl;
using System;

namespace DailyProg.Jobs
{
    public class TaskScheduler
    {
        public static async void Start(string connect)
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();
            IJobDetail job = JobBuilder.Create<TasksUpdater>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("updater", "group1")
                .UsingJobData("connect", connect)
                .StartAt(DateTimeOffset.Parse("00:01:00"))
                .EndAt(DateTimeOffset.Parse("00:02:00"))
                .WithSimpleSchedule(x => x
                   .WithIntervalInHours(24)
                   .RepeatForever())
                .Build();
            await scheduler.ScheduleJob(job, trigger);
        }
    }
}
