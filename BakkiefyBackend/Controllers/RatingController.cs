using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using BakkiefyBackend.Model;
using BakkiefyBackend.Repositories.Interface;

namespace BakkiefyBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/rates")]
    public class RatingController : BaseController<MyHub.MyHub>
    {
        private readonly IRatingRepository _ratingRepository;
        public RatingController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        [Route("raterequest")]
        public async Task<IHttpActionResult> RateRequest(RatingModel ratingsModel)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var _rated = await _ratingRepository.AddRating(ratingsModel);
                return Ok(_rated);
            }
            catch (Exception)
            {

                throw;
            }
        }
       
    }
}
