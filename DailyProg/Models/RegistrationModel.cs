using DailyProg.Logic;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DailyProg.Models
{
    public class UserModel
    {
        public Guid UserID { get; set; }
        [Required(ErrorMessage = "Write down your email")]
        [RegularExpression(@"[A-Za-z0-9._]+@[A-Za-z0-9]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect address")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "Create a password")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{6,16}$", ErrorMessage = "You need to use at least one Uppercase and one number")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Password length must be from 6 to 16 symbols")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
    public class RegistrationModel : UserModel
    {
        [Required(ErrorMessage = "Repeat a password")]
        [Compare("UserPassword", ErrorMessage = "Passwords do not match")]
        [StringLength(16, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
        public string Message { get; set; }
    }
}
