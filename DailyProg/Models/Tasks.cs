using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Policy;
using System.Threading.Tasks;

namespace DailyProg.Models
{
    public partial class TasksLogic : DTask
    {
        public List<NTask> NTasks { get; set; }
        public List<ETask> ETasks { get; set; }
        public List<ETask> DTasks { get; set; }
    }
    public class MyTask
    {
        [HiddenInput(DisplayValue = false)]
        public Guid UserID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int TaskID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool Done { get; set; }
    }
    public class NTask : MyTask
    {
        [Required(ErrorMessage = "Write down your task")]
        [StringLength(50, MinimumLength = 1, ErrorMessage ="String length must be 1-50")]
        [Display(Prompt = "Write down task")]
        public string Task { get; set; }
    }
    public class ETask : NTask
    {
        [Required(ErrorMessage = "Choose the time")]
        [Display(Prompt = "Write down time for task")]
        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }
    }
    public class DTask : ETask
    {
        [Required(ErrorMessage = "choose a date")]
        [Display(Prompt = "Write down date for task")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}

