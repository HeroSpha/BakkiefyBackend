using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BakkiefyBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/customerblacklist")]
    public class CustomerBlackListController : BaseController<MyHub.MyHub>
    {
        [Route("addcustomer")]
        public async Task<IHttpActionResult> AddCustomer()
        {
            return Ok();
        }
        [Route("deletecustomer")]
        public async Task<IHttpActionResult> DeleteCustomer()
        {
            return Ok();
        }
        [Route("blacklistcustomer")]
        [HttpPost]
        public async Task<IHttpActionResult> BlackListCustomer()
        {
            return Ok();
        }
        [Route("updatecustomer")]
        [HttpPost]
        public async Task<IHttpActionResult> UpdateCustomer()
        {
            return Ok();
        }
        [Route("getcustomer")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCustomer()
        {
            return Ok();
        }
    }
}
