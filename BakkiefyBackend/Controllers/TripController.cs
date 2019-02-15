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
    [RoutePrefix("api/trip")]
    public class TripController : ApiController
    {
        [Route("create")]
        public async Task<IHttpActionResult> CreateTrip()
        {
            return Ok();
        }
        
    }
}
