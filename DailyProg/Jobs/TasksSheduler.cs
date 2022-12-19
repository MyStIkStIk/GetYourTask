using Quartz;
using Quartz.Impl;
using System;

namespace DailyProg.Jobs
{
    public class TasksSheduler
    {
        public TasksSheduler()
        {
            Start();
        }
        public static async void Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();
            IJobDetail job = JobBuilder.Create<TasksUpdater>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("updater", "group1")
                .StartAt(DateTimeOffset.Parse("00:00:00"))
                .WithSimpleSchedule(x => x
                   .WithIntervalInHours(24)
                   .RepeatForever())
                .Build();
            await scheduler.ScheduleJob(job, trigger);
        }
    }
}
