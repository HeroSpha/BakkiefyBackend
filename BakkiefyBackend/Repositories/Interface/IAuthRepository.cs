using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakkiefyBackend.Model;
using BakkiefyBackend.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BakkiefyBackend.Repositories.Interface
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterUser(Usermodel model, string Role);
        Task<IdentityUser> GetUser(string PhoneNumber);
        Task<Result> GetCode(Usermodel model, string accountSid, string authToken);
    }
}
