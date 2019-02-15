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
    public class BakkieRequestRepository : BaseRepository, IBakkieRequestRepository
    {
        public BakkieRequestRepository(BakkieDbContext bakkieDbContex)
            :base(bakkieDbContex)
        {

        }

        public async Task<BakkieRequestModel> AddRequest(BakkieRequestModel bakkieRequestModel)
        {
            try
            {
                var _request = new BakkieRequest
                {
                    BakkieId = bakkieRequestModel.BakkieId,
                    BakkieRequestId = bakkieRequestModel.BakkieRequestId,
                    RequestDate = bakkieRequestModel.RequestDate,
                    CustomerId = bakkieRequestModel.CustomerId,
                    Address = bakkieRequestModel.Address,
                    Latitute = bakkieRequestModel.Latitute,
                    Longitude = bakkieRequestModel.Longitude,
                    RequestStatus = bakkieRequestModel.RequestStatus
                };
                var _added = await _bakkieDbContext.BakkieRequests.AddAsync(_request);
                await _bakkieDbContext.SaveChangesAsync();

                return bakkieRequestModel;

            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<bool> DeleteRequest(string BakkieRequestId)
        {
            try
            {
                var _item = await _bakkieDbContext.BakkieRequests.FirstOrDefaultAsync(p => p.BakkieRequestId == BakkieRequestId);
                if (_item != null)
                {
                    _bakkieDbContext.BakkieRequests.Remove(_item);
                    await _bakkieDbContext.SaveChangesAsync();
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

        public async Task<BakkieRequestModel> GetBakkieRequest(string BakkieRequestId)
        {
            try
            {
                var _bakkieRequest = await _bakkieDbContext.BakkieRequests.Include(f => f.Ticket).Include(f =>  f.Customer).Include(f => f.Rating).FirstOrDefaultAsync(p => p.BakkieRequestId == BakkieRequestId);
                return new BakkieRequestModel
                {
                    BakkieId = _bakkieRequest.BakkieId,
                    BakkieRequestId = _bakkieRequest.BakkieRequestId,
                    RequestDate = _bakkieRequest.RequestDate,
                    CustomerId = _bakkieRequest.CustomerId,
                    Address = _bakkieRequest.Address,
                    Latitute = _bakkieRequest.Latitute,
                    Longitude = _bakkieRequest.Longitude,
                    RequestStatus = _bakkieRequest.RequestStatus,
                    Ticket = _bakkieRequest.Ticket,
                    Customer = _bakkieRequest.Customer,
                    Rating = _bakkieRequest.Rating
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<BakkieRequestModel>> GetCustomerRequests(string CustomerId)
        {
            try
            {
                var _requests = await _bakkieDbContext.BakkieRequests.Where(p => p.CustomerId == p.CustomerId).ToListAsync();
                return _requests.Select(request => new BakkieRequestModel
                {
                    BakkieId = request.BakkieId,
                    BakkieRequestId = request.BakkieRequestId,
                    RequestDate = request.RequestDate,
                    CustomerId = request.CustomerId,
                    Address = request.Address,
                    Latitute = request.Latitute,
                    Longitude = request.Longitude,
                    RequestStatus = request.RequestStatus,
                    Ticket = request.Ticket,
                    Customer = request.Customer,
                    Rating = request.Rating

                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<BakkieRequestModel>> GetDriverRequests(string BakkieId)
        {
            try
            {
                try
                {
                    var _requests = await _bakkieDbContext.BakkieRequests.Where(p => p.BakkieId == BakkieId).ToListAsync();
                    return _requests.Select(request => new BakkieRequestModel
                    {
                        BakkieId = request.BakkieId,
                        BakkieRequestId = request.BakkieRequestId,
                        RequestDate = request.RequestDate,
                        CustomerId = request.CustomerId,
                        Address = request.Address,
                        Latitute = request.Latitute,
                        Longitude = request.Longitude,
                        RequestStatus = request.RequestStatus,
                        Ticket = request.Ticket,
                        Customer = request.Customer,
                        Rating = request.Rating

                    }).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BakkieRequestModel> UpdateRequest(BakkieRequestModel bakkieRequestModel)
        {
            try
            {
                var _item = await _bakkieDbContext.BakkieRequests.FirstOrDefaultAsync(p => p.BakkieRequestId == bakkieRequestModel.BakkieRequestId);
                if (_item != null)
                {
                    _item.RequestStatus = bakkieRequestModel.RequestStatus;
                    _bakkieDbContext.BakkieRequests.Update(_item);
                    await _bakkieDbContext.SaveChangesAsync();
                    return bakkieRequestModel;
                }
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}