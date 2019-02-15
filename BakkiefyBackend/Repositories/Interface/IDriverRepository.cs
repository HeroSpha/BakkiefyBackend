using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BakkiefyBackend.Model;
using BakkiefyBackend.Models;

namespace BakkiefyBackend.Repositories.Interface
{
    public interface IDriverRepository
    {
        Task<DriverModel> GetDriver(string DriverId);
        Task<List<DriverModel>> GetDrivers();
        Task<DriverModel> AddDriver(DriverModel Driver);
        Task<List<DriverModel>> GetList();
        Task<bool> DeleteDriver(string DriverId);

    }
}