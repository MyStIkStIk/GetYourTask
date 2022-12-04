using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DailyProg.Models
{
    public class AuthorizationActions : RegistrationModel
    {
        public async Task<BaseResponce<bool>> Login(DbConnect connect, RegistrationModel model)
        {
            BaseResponce<bool> baseResponce = new BaseResponce<bool>();
            try
            {
                using(IDbConnection database = connect.Connect)
                {
                    await database.ExecuteAsync("UPDATE NoTermTask SET Done = 1 WHERE TaskID = @TaskID", model);
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
        public async Task<BaseResponce<bool>> Login(DbConnect connect, LoginModel model)
        {
            BaseResponce<bool> baseResponce = new BaseResponce<bool>();
            try
            {
                using(IDbConnection database = connect.Connect)
                {
                    await database.ExecuteAsync("UPDATE NoTermTask SET Done = 1 WHERE TaskID = @TaskID", model);
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
    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class RegistrationModel : LoginModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
