using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BakkiefyBackend.Model;
using BakkiefyBackend.Models;
using BakkiefyBackend.Repositories.Interface;

namespace BakkiefyBackend.Repositories.Core
{
    public class CustomerBakkieBlackListRepository : BaseRepository, ICustomerBlackList
    {
        public CustomerBakkieBlackListRepository(BakkieDbContext bakkieDbContext)
            :base(bakkieDbContext)
        {

        }
        public Task<CustomerModel> AddCustomer(CustomerModel Customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomer(string CustomerId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerModel> GetCustomer(string CustomerId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerModel> UpdateCustomer(CustomerModel Customer)
        {
            throw new NotImplementedException();
        }
    }
}