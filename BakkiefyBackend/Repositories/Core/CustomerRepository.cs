using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BakkiefyBackend.Model;
using BakkiefyBackend.Models;
using BakkiefyBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BakkiefyBackend.Repositories.Core
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        
        public CustomerRepository(BakkieDbContext bakkieDbContext)
            :base(bakkieDbContext)
        {

        }
        public async Task<CustomerModel> AddCustomer(CustomerModel Customer)
        {
            try
            {

                var customer = await _bakkieDbContext.Customers.FirstOrDefaultAsync(p => p.CustomerId == Customer.CustomerId);
                if(customer != null)
                {
                    customer.Lastname = Customer.Lastname;
                    customer.Firstname = Customer.Firstname;
                    customer.PhoneNumber = Customer.PhoneNumber;
                    customer.Email = Customer.Email;
                    customer.Address = Customer.Address;

                    _bakkieDbContext.Update(customer);

                }
                else
                {
                    var _customer = new Customer
                    {
                        CustomerId = Customer.CustomerId,
                        Firstname = Customer.Firstname,
                        Lastname = Customer.Lastname,
                        PhoneNumber = Customer.PhoneNumber,
                        Email = Customer.Email,
                        Address = Customer.Address
                    };
                    var _added = await _bakkieDbContext.Customers.AddAsync(_customer);

                }
                await _bakkieDbContext.SaveChangesAsync();
                return Customer;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<bool> DeleteCustomer(string CustomerId)
        {
            try
            {
                var customer = await _bakkieDbContext.Customers.FirstOrDefaultAsync(p => p.CustomerId == CustomerId);
                if (customer != null)
                {
                    _bakkieDbContext.Customers.Remove(customer);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CustomerModel> GetCustomer(string CustomerId)
        {
            var customer = await _bakkieDbContext.Customers.Include(f  => f.BakkieRequests).FirstOrDefaultAsync(p => p.CustomerId == CustomerId);
            if (customer != null)
                return new CustomerModel
                {
                    CustomerId = customer.CustomerId,
                    Address = customer.Address,
                    Email = customer.Email,
                    Firstname = customer.Firstname,
                    Lastname = customer.Lastname,
                    PhoneNumber = customer.PhoneNumber,
                    BakkieRequests = customer.BakkieRequests
                   
                };
            else
                return null;
        }

        public Task<CustomerModel> UpdateCustomer(CustomerModel Customer)
        {
            throw new NotImplementedException();
        }
    }
}