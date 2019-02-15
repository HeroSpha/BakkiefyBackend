using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BakkiefyBackend.Model;
using BakkiefyBackend.Repositories.Interface;

namespace BakkiefyBackend.Controllers
{
    [RoutePrefix("api/bakkiesizes")]
    public class BakkieSizeController : BaseController<MyHub.MyHub>
    {
        private readonly IBakkieSizeRepository _bakkieSizeRepository;
        public BakkieSizeController(IBakkieSizeRepository bakkieSizeRepository)
        {
            _bakkieSizeRepository = bakkieSizeRepository;
        }
        [Route("add")]
        [HttpPost]
        public async Task<IHttpActionResult> Add(BakkieSizeModel bakkieSizeModel)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var _added = await _bakkieSizeRepository.Add(bakkieSizeModel);
                return Ok(_added);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
        [Route("delete")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int BakkieSizeId)
        {
            try
            {
                var _isdeleted = await _bakkieSizeRepository.Delete(BakkieSizeId);
                return Ok(_isdeleted);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
        [HttpGet]
        [Route("sizes")]
        public async Task<IHttpActionResult> GetSizes()
        {
            try
            {
                var _sizes = await _bakkieSizeRepository.BakkieSizes();
                return Ok(_sizes);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
    }
}
