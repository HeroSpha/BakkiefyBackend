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
    [RoutePrefix("api/customers")]
    public class CustomerController : BaseController<MyHub.MyHub>
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [Route("add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddCustomer(CustomerModel customerModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var _added = await _customerRepository.AddCustomer(customerModel);
                if (_added != null)
                    return Ok(_added);
                else
                    return null;
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
        [Route("deletecustomer/{customerId}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCustomer(string customerId)
        {
            try
            {
                var _deleted = await _customerRepository.DeleteCustomer(customerId);
                if (_deleted)
                    return Ok(_deleted);
                else
                    return Ok(false);
            }
            catch (Exception)
            {

                throw;
            }
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
        [Route("getcustomer/{customerId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCustomer(string customerId)
        {
            try
            {
                var customer = await _customerRepository.GetCustomer(customerId);
                return Ok(customer);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
