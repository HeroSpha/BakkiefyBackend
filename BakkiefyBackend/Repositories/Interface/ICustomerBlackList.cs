using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BakkiefyBackend.Model;

namespace BakkiefyBackend.Repositories.Interface
{
    public interface ICustomerBlackList
    {
        Task<CustomerModel> GetCustomer(string CustomerId);
        Task<CustomerModel> AddCustomer(CustomerModel Customer);
        Task<bool> DeleteCustomer(string CustomerId);
        Task<CustomerModel> UpdateCustomer(CustomerModel Customer);

    }
}