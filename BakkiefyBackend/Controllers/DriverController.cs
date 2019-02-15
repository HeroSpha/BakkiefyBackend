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
    [RoutePrefix("api/drivers")]
    public class DriverController : ApiController
    {
        private readonly IDriverRepository _driverRepository;
        public DriverController(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        [Route("getdrivers")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDrivers()
        {
            try
            {
                var drivers = await _driverRepository.GetDrivers();
                return Ok(drivers);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddDriver(DriverModel driverModel)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var model =  await _driverRepository.AddDriver(driverModel);
                return Ok(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
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
        [Route("getdriver/{DriverId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDriver(string DriverId)
        {
            try
            {
                var driver = await _driverRepository.GetDriver(DriverId);
                return Ok(driver);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
    }
}
