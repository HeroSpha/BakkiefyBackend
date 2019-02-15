using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using BakkiefyBackend.Models;
using BakkiefyBackend.Repositories.Interface;

namespace BakkiefyBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/registration")]
    public class RegisterController : BaseController<MyHub.MyHub>
    {
        private readonly IAuthRepository _authRepository;
        public RegisterController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [HttpPost]
        [Route("register/{Role}")]
        public async Task<IHttpActionResult> Register(Usermodel model, string Role)
        {
            try
            {
                var credentials = await _authRepository.RegisterUser(model, Role);
                return Ok(credentials);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
        [HttpPost]
        [Route("getcode")]
        public async Task<IHttpActionResult> GetCode(Usermodel model)
        {
            try
            {
                string _auth = "a9ca84f4c4e402b0955d5b7ff111f055";
                string _ssid = "ACc9ae3fc69477812254ce7758f8341cea";
               var code = await _authRepository.GetCode(model, _ssid, _auth);
                return Ok(code);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
