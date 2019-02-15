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
    [RoutePrefix("api/requests")]
    public class BakkieRequestController : BaseController<MyHub.MyHub>
    {
        private readonly IBakkieRequestRepository _bakkieRequestRepository;
        public BakkieRequestController(IBakkieRequestRepository bakkieRequestRepository)
        {
            _bakkieRequestRepository = bakkieRequestRepository;
        }

        [HttpPost]
        [Route("reponse")]
        public async Task<IHttpActionResult> RequestResponse(BakkieRequestModel bakkieRequestModel)
        {
            try
            {
                var _item = await _bakkieRequestRepository.UpdateRequest(bakkieRequestModel);
                if(_item != null)
                {
                    var subscribed = Hub.Clients.Group(bakkieRequestModel.CustomerId);
                    subscribed.driverResponse(bakkieRequestModel.RequestStatus);
                    return Ok(_item);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        [HttpPost]
        [Route("request/{driverId}")]
        public async Task<IHttpActionResult> AddRequest(string driverId, BakkieRequestModel bakkieRequestModel)
        {
            try
            {
                //var subscribed = Hub.Clients.Group(driverId);
                //subscribed.requestBakkie(bakkieRequestModel);
                //return Ok(bakkieRequestModel);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                bakkieRequestModel.BakkieRequestId = Guid.NewGuid().ToString();
                var request = await _bakkieRequestRepository.AddRequest(bakkieRequestModel);
                if (request != null)
                {
                    var subscribed = Hub.Clients.Group(driverId);
                    subscribed.requestBakkie(request);
                    return Ok(request);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
        [HttpPost]
        [Route("delete/{BakkieRequestId}")]
        public async Task<IHttpActionResult> Delete(string BakkieRequestId)
        {
            try
            {
               
                var request = await _bakkieRequestRepository.DeleteRequest(BakkieRequestId);
                return Ok(request);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
        [HttpPost]
        [Route("customerrequests")]
        public async Task<IHttpActionResult> CustomerRequest(string CustomerId)
        {
            try
            {
               
                var request = await _bakkieRequestRepository.GetCustomerRequests(CustomerId);
                return Ok(request);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
        [HttpPost]
        [Route("driverrequests/{BakkieId}")]
        public async Task<IHttpActionResult> DriverRequest(string BakkieId)
        {
            try
            {

                var request = await _bakkieRequestRepository.GetDriverRequests(BakkieId);
                return Ok(request);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
    }
}
