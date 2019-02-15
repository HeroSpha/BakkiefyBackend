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
    [RoutePrefix("api/online")]
    public class OnlineController : BaseController<MyHub.MyHub>
    {
        private readonly IOnlineRepository _onlineRepository;
        public OnlineController(IOnlineRepository onlineRepository)
        {
            _onlineRepository = onlineRepository;
        }
        [Route("getlist")]
        [HttpGet]
        public async Task<IHttpActionResult> GetList()
        {
            try
            {
                var _list = await _onlineRepository.GetList();
                return Ok(_list);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        [Route("goonline")]
        [HttpPost]
        public async Task<IHttpActionResult> GoOnline(OnlineModel onlineModel)
        {
            try
            {
                var _online = await _onlineRepository.GoOnline(onlineModel);
                return Ok(_online);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
        [Route("gooffline")]
        [HttpPost]
        public async Task<IHttpActionResult> GoOffOnline(OnlineModel onlineModel)
        {
            try
            {
                var _offline = await _onlineRepository.GoOffline(onlineModel);
                return Ok(_offline);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Route("deleteonline")]
        public async Task<IHttpActionResult> DeleteOnline()
        {
            return Ok();
        }
        [HttpPost]
        [Route("requestqoute/{driverId}")]
        public async Task<IHttpActionResult> RequestQoute(string driverId, Qoutation qoutation)
        {
            var subscribed = Hub.Clients.Group(driverId);
            subscribed.requestQoute(qoutation);
            return Ok(qoutation);
          
        }

        [HttpPost]
        [Route("qouteresponse/{customerId}/{amount}")]
        public async Task<IHttpActionResult> QouteResponse(string customerId, string amount)
        {
            var subscribed = Hub.Clients.Group(customerId);
            subscribed.qouteResponse(amount);
            return Ok(amount);

        }



    }
}
