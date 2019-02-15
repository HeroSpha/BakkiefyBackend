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
    [RoutePrefix("api/cost")]
    public class CostController : BaseController<MyHub.MyHub>
    {
        [Route("addcost")]
        public async Task<IHttpActionResult> AddCost()
        {
            return Ok();
        }
        [Route("deletecost")]
        public async Task<IHttpActionResult> DeleteCost()
        {
            return Ok();
        }
        [Route("updatecost")]
        public async Task<IHttpActionResult> UpdateCost()
        {
            return Ok();
        }

        [Route("getcost")]
        public async Task<IHttpActionResult> GetCost()
        {
            return Ok();
        }
    }
}
