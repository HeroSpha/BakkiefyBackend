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
    public class OnlineRepository : BaseRepository, IOnlineRepository
    {
     
        public OnlineRepository(BakkieDbContext bakkieDbContext)
            : base(bakkieDbContext)
        {
          
        }
        public async Task<bool> DeleteOnline(string OnlineId)
        {
            try
            {
                var online = await _bakkieDbContext.Onlines.FirstOrDefaultAsync(p => p.OnlineId == OnlineId);
                if (online != null)
                {
                    _bakkieDbContext.Onlines.Remove(online);
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

        public async Task<List<OnlineModel>> GetList()
        {
            try
            {
                var onlines = await _bakkieDbContext.Onlines
                    .Include(f => f.Bakkie).ThenInclude(f => f.BakkieSize)
                    .Include(f => f.Bakkie).ThenInclude(f => f.Driver).ToListAsync();
                return onlines.Select(online => new OnlineModel
                {
                    OnlineId = online.OnlineId,
                    BakkieId = online.BakkieId,
                    DriverStatus = online.DriverStatus,
                    Latitude = online.Latitude,
                    Longitude = online.Longitude, 
                    Radius = online.Radius,
                    Status = online.Status,
                    Bakkie = online.Bakkie

                }).ToList();
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<OnlineModel> GoOffline(OnlineModel Online)
        {
            try
            {
                var online = await _bakkieDbContext.Onlines.FirstOrDefaultAsync(f => f.OnlineId == Online.OnlineId);
                if(online != null)
                {
                    online.Status = false;
                     _bakkieDbContext.Onlines.Update(online);
                    await _bakkieDbContext.SaveChangesAsync();
                    return new OnlineModel
                    {
                        OnlineId = online.OnlineId,
                        BakkieId = online.BakkieId,
                        DriverStatus = online.DriverStatus,
                        Latitude = online.Latitude,
                        Longitude = online.Longitude,
                        Radius = online.Radius,
                        Status = online.Status
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new  ApplicationException(ex.Message);
            }
        }

        public async Task<OnlineModel> GoOnline(OnlineModel Online)
        {
            try
            {
                var online = await _bakkieDbContext.Onlines.FirstOrDefaultAsync(f => f.OnlineId == Online.OnlineId);
                if(online != null)
                {
                    online.Status = true;
                    online.Radius = Online.Radius;
                    _bakkieDbContext.Onlines.Update(online);
                    await _bakkieDbContext.SaveChangesAsync();
                    return Online;
                }
                else
                {
                    var _online = new Online
                    {
                        OnlineId = Online.OnlineId,
                        BakkieId = Online.BakkieId,
                        DriverStatus = Online.DriverStatus,
                        Latitude = Online.Latitude,
                        Longitude = Online.Longitude,
                        Radius = Online.Radius,
                        Status = Online.Status
                    };
                    var added = await _bakkieDbContext.Onlines.AddAsync(_online);
                    await _bakkieDbContext.SaveChangesAsync();
                    return Online;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}