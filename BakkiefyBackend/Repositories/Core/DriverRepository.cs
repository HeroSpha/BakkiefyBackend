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
    public class DriverRepository : BaseRepository, IDriverRepository
    {
       
        public DriverRepository(BakkieDbContext bakkieDbContext)
            :base(bakkieDbContext)
        {
           
        }
        public async Task<DriverModel> AddDriver(DriverModel Driver)
        {
            try
            {
                var driver = new Driver
                {
                    DriverId = Driver.DriverId,
                    Email = Driver.Email,
                    Firstname = Driver.Firstname,
                    Lastname = Driver.Lastname,
                    PhoneNumber = Driver.PhoneNumber,
                    Photo = Driver.Photo
                };
                var _driver = await _bakkieDbContext.Drivers.FirstOrDefaultAsync(p => p.DriverId == Driver.DriverId);
                if(_driver == null)
                {
                    await _bakkieDbContext.Drivers.AddAsync(driver);
                    await _bakkieDbContext.SaveChangesAsync();
                    return Driver;
                }
                else
                {
                    _driver.Email = Driver.Email;
                    _driver.Firstname = Driver.Firstname;
                    _driver.Lastname = Driver.Lastname;
                    _driver.PhoneNumber = Driver.PhoneNumber;
                    _driver.Photo = driver.Photo;
                    _bakkieDbContext.Drivers.Update(_driver);
                    await _bakkieDbContext.SaveChangesAsync();
                    return new DriverModel
                    {
                        DriverId = _driver.DriverId,
                        Email = _driver.Email,
                        Firstname = _driver.Firstname,
                        Lastname = _driver.Lastname,
                        PhoneNumber = _driver.PhoneNumber,
                        Photo = _driver.Photo
                    };
                }
              
               
                
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<bool> DeleteDriver(string DriverId)
        {
            try
            {
                var driver = await _bakkieDbContext.Drivers.FirstOrDefaultAsync(p => p.DriverId == DriverId);
                if (driver != null)
                {
                    _bakkieDbContext.Drivers.Remove(driver);
                    await _bakkieDbContext.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<DriverModel> GetDriver(string DriverId)
        {
            try
            {
                var driver = await _bakkieDbContext.Drivers.FirstOrDefaultAsync(p => p.DriverId == DriverId);
                if(driver != null)
                {
                    return new DriverModel
                    {
                        DriverId = driver.DriverId,
                        Email = driver.Email,
                        Firstname = driver.Firstname,
                        Lastname = driver.Lastname,
                        PhoneNumber = driver.PhoneNumber,
                        Photo = driver.Photo,
                        Bakkie = driver.Bakkie
                    };
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

        public async Task<List<DriverModel>> GetDrivers()
        {
            try
            {
                var drivers = await _bakkieDbContext.Drivers.ToListAsync();
                return drivers.Select(driver => new DriverModel
                {
                    DriverId = driver.DriverId,
                    Email = driver.Email,
                    Firstname = driver.Firstname,
                    Lastname = driver.Lastname,
                    PhoneNumber = driver.PhoneNumber,
                    Photo = driver.Photo,
                    Bakkie = driver.Bakkie
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<DriverModel>> GetList()
        {
            try
            {
                var drivers = await _bakkieDbContext.Drivers.Include(f => f.Bakkie).ThenInclude(f => f.BakkieRequests).ToListAsync();
                return drivers.Select(driver => new DriverModel
                {
                    DriverId = driver.DriverId,
                    Email = driver.Email,
                    Firstname = driver.Firstname,
                    Lastname = driver.Lastname,
                    PhoneNumber = driver.PhoneNumber,
                    Photo = driver.Photo,
                    Bakkie = driver.Bakkie
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}