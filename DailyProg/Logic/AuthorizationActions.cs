using DailyProg.Models;
using System.Data;
using System.Threading.Tasks;
using System;
using Dapper;

namespace DailyProg.Logic
{
    public class AuthorizationActions : RegistrationModel
    {
        public async Task<BaseResponce<UserModel>> SignIn(DbConnect connect, RegistrationModel model)
        {
            BaseResponce<UserModel> baseResponce = new BaseResponce<UserModel>();
            try
            {
                using (IDbConnection database = connect.Connect)
                {
                    model = await database.QuerySingleAsync<RegistrationModel>("SELECT UserID, UserEmail FROM UserInfo WHERE UserEmail = @UserEmail AND UserPassword = @UserPassword", model);
                }
                baseResponce.Data = model;
                baseResponce.Status = StatusCode.OK;
            }
            catch (Exception ex)
            {
                model.Message = "Some value is incorrect";
                baseResponce.Message = ex.Message;
                baseResponce.Status = StatusCode.Error;
            }
            return baseResponce;
        }
        public async Task<BaseResponce<UserModel>> SignUp(DbConnect connect, RegistrationModel model)
        {
            BaseResponce<UserModel> baseResponce = new BaseResponce<UserModel>();
            try
            {
                using (IDbConnection database = connect.Connect)
                {
                    string regModel = await database.QueryFirstOrDefaultAsync<string>("SELECT UserEmail FROM UserInfo WHERE UserEmail = @UserEmail", model);
                    if (regModel == null || model.UserEmail != regModel)
                    {
                        await database.ExecuteAsync("INSERT INTO UserInfo VALUES (NewID(), @UserEmail, @UserPassword)", model);
                        model = await database.QuerySingleAsync<RegistrationModel>("SELECT UserID, UserEmail FROM UserInfo WHERE UserEmail = @UserEmail AND UserPassword = @UserPassword", model);
                        model.UserPassword = "";
                        model.PasswordConfirm = "";
                    }
                    else
                        new Exception();
                }
                baseResponce.Data = model;
                baseResponce.Status = StatusCode.OK;
            }
            catch (Exception ex)
            {
                model.Message = "There is already user with same email";
                baseResponce.Message = ex.Message;
                baseResponce.Status = StatusCode.Error;
            }
            return baseResponce;
        }
    }
}
