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
    [RoutePrefix("api/bakkie")]
    public class BakkieController : BaseController<MyHub.MyHub>
    {
        private readonly IBakkieRepository _bakkieRepository;
        public BakkieController(IBakkieRepository bakkieRepository)
        {
            _bakkieRepository = bakkieRepository;
        }
        [Route("addbakkie")]
        [HttpPost]
        public async Task<IHttpActionResult> AddBakkie(BakkieModel bakkieModel)
        {
            try
            {
                
                await _bakkieRepository.AddBakkie(bakkieModel);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
        [Route("deletebakkie")]
        public async Task<IHttpActionResult> DeleteBakkie()
        {
            return Ok();
        }
        [Route("updatebakkie")]
        public async Task<IHttpActionResult> UpdateBakkie()
        {
            return Ok();
        }
        [Route("getbakkies")]
        [HttpGet]
        public async Task<IHttpActionResult> GetBakkies()
        {
            try
            {
                var bakkies = await _bakkieRepository.GetBakkies();
                return Ok(bakkies);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
        [Route("getbakkie/{bakkieId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetBakkie(string bakkieId)
        {
            try
            {
                var bakkie = await _bakkieRepository.GetBakkie(bakkieId);
                return Ok(bakkie);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
    }
}
