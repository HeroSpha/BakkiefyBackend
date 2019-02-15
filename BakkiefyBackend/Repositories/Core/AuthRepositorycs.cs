using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BakkiefyBackend.Model;
using BakkiefyBackend.Models;
using BakkiefyBackend.Repositories.Interface;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using Twilio.Rest.Api.V2010.Account;

namespace BakkiefyBackend.Repositories.Core
{
    public class AuthRepository : IDisposable, IAuthRepository
    {
        private AuthContext _ctx;

        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
        public AuthRepository()
        {
            var provider = new DpapiDataProtectionProvider("bakkiefy");
            _ctx = new AuthContext();
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AuthContext()));
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
            _userManager.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser>(provider.Create("passwordReset"));
        }
        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }
        public async Task<Result> GetCode(Usermodel model, string accountSid, string authToken)
        {
            try
            {
                var random = new Random();
                var num = random.Next(100000, 1000000);

                Result result = new Result();
                result.Code = "000000";
                //Twilio.TwilioClient.Init(accountSid, authToken);
                //var message = await MessageResource.CreateAsync(
                //    to: new Twilio.Types.PhoneNumber(model.PhoneNumber),
                //    from: new Twilio.Types.PhoneNumber("+15594646077 "),
                //    body: $"{num} is your Bakkiefy verification code.");
                return await Task.FromResult(result);
                //sms the code to user
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public Task<IdentityUser> GetUser(string PhoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> RegisterUser(Usermodel model, string Role)
        {
            try
            {
                if (!await _roleManager.RoleExistsAsync(Role))
                {
                    var identityRole = new IdentityRole();
                    identityRole.Name = Role;
                    var results = await _roleManager.CreateAsync(identityRole);
                    if (!results.Succeeded)
                        return null;
                }

                var _user = await _userManager.FindByNameAsync(model.Username);
                if(_user == null)
                {
                    IdentityUser user = new IdentityUser
                    {
                        UserName = model.Username,
                        PhoneNumber = model.Username,
                        PhoneNumberConfirmed = true

                    };

                    var password = Guid.NewGuid();
                    model.Password = password.ToString();
                    var result = await _userManager.CreateAsync(user, password.ToString());
                    if (result.Succeeded)
                    {
                        var roleAdded = await _userManager.AddToRolesAsync(user.Id, Role);
                        if (!roleAdded.Succeeded)
                            return null;
                        else
                            return result;
                    }
                    else
                        return result;
                }
                else
                    return null;



            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }


    
    }
}