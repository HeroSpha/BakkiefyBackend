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
    [RoutePrefix("api/driverblacklist")]
    public class DriverBlackListController : ApiController
    {
        [Route("adddriver")]
        public async Task<IHttpActionResult> AddDriver()
        {
            return Ok();
        }
        [Route("deletedriver")]
        public async Task<IHttpActionResult> DeleteDriver()
        {
            return Ok();
        }
       
        [Route("updatedriver")]
        [HttpPost]
        public async Task<IHttpActionResult> UpdateDriverr()
        {
            return Ok();
        }
        [Route("getdriver")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDriver()
        {
            return Ok();
        }
    }
}
