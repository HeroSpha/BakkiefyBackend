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
    public class BakkieRepository : BaseRepository, IBakkieRepository
    {

        public BakkieRepository(BakkieDbContext bakkieDbContext) : base(bakkieDbContext) { }
       
        public async Task AddBakkie(BakkieModel Bakkie)
        {
            try
            {
                var bakkie = new Bakkie
                {
                    BakkieId = Bakkie.BakkieId,
                    Model = Bakkie.Model,
                    Color = Bakkie.Color,
                    DriverId = Bakkie.DriverId,
                    RegNumber = Bakkie.RegNumber,
                    Make = Bakkie.Make,
                    BakkieSizeId = Bakkie.BakkieSizeId

                };
                var _bakkie = await _bakkieDbContext.Bakkies.FirstOrDefaultAsync(p => p.DriverId == Bakkie.DriverId);

                if(_bakkie != null)
                {
                    _bakkie.Make = Bakkie.Make;
                    _bakkie.Model = Bakkie.Model;
                    _bakkie.Color = Bakkie.Color;
                    _bakkie.BakkieSizeId = Bakkie.BakkieSizeId;
                    _bakkie.RegNumber = Bakkie.RegNumber;

                    _bakkieDbContext.Bakkies.Update(_bakkie);
                }
                else
                {
                    await _bakkieDbContext.Bakkies.AddAsync(bakkie);
                }

               
                await _bakkieDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
            
        }

        public async Task<bool> DeleteBack(string BakkieId)
        {
            try
            {
                var bakkie = await _bakkieDbContext.Bakkies.FirstOrDefaultAsync(f => f.BakkieId == BakkieId);
                if (bakkie != null)
                {
                    _bakkieDbContext.Bakkies.Remove(bakkie);
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

        public async Task<BakkieModel> GetBakkie(string BakkieId)
        {
            try
            {
                var bakkie = await _bakkieDbContext.Bakkies.Include(f=> f.Driver).Include(f => f.Online).FirstOrDefaultAsync(f => f.BakkieId == BakkieId);
                if (bakkie != null)
                    return new BakkieModel
                    {
                        BakkieId = bakkie.BakkieId,
                        Model = bakkie.Model,
                        Color = bakkie.Color,
                        DriverId = bakkie.DriverId,
                        RegNumber = bakkie.RegNumber,
                        Make = bakkie.Make,
                        BakkieSizeId = bakkie.BakkieSizeId,
                        Driver = bakkie.Driver,
                        BakkieSize = bakkie.BakkieSize
                    };
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<BakkieModel>> GetBakkies()
        {
            try
            {
                var bakkies = await _bakkieDbContext.Bakkies.Include(f => f.Driver).Include(f => f.BakkieSize).ToListAsync();
                return bakkies.Select(bakkie => new BakkieModel
                {
                    BakkieId = bakkie.BakkieId,
                    Model = bakkie.Model,
                    Color = bakkie.Color,
                    DriverId = bakkie.DriverId,
                    RegNumber = bakkie.RegNumber,
                    Make = bakkie.Make,
                    BakkieSizeId = bakkie.BakkieSizeId,
                    Driver = bakkie.Driver,
                    BakkieSize = bakkie.BakkieSize
                }).ToList();
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public Task<List<BakkieModel>> GetClosekkies()
        {
            throw new NotImplementedException();
        }

        public Task<List<BakkieModel>> GetOnlineBakkies()
        {
            throw new NotImplementedException();
        }

        public async Task<BakkieModel> UpdateBakkie(BakkieModel Bakkie)
        {
            try
            {
                var bakkie = await _bakkieDbContext.Bakkies.FirstOrDefaultAsync(f => f.BakkieId == Bakkie.BakkieId);
                if(bakkie != null)
                {
          
                    bakkie.Color = Bakkie.Color;
                    bakkie.DriverId = Bakkie.DriverId;
                    bakkie.Make = Bakkie.Make;
                    bakkie.Model = Bakkie.Model;
                    bakkie.RegNumber = Bakkie.RegNumber;
                    _bakkieDbContext.Update(bakkie);
                    await _bakkieDbContext.SaveChangesAsync();

                }
                return Bakkie;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}