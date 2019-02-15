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
    public class CostRepository : BaseRepository, ICostRepository
    {
       
        public CostRepository(BakkieDbContext bakkieDbContext)
            :base(bakkieDbContext)
        {

        }
        public async Task<CostModel> AddCost(CostModel Cost)
        {
            try
            {
                var cost = new Cost
                {
                    CostId = Cost.CostId,
                    IsCurrent = Cost.IsCurrent,
                    Price = Cost.Price
                };
                var addCost = await _bakkieDbContext.Costs.AddAsync(cost);
                return Cost;
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }

        }

        public async Task<bool> DeleteCost(string CostId)
        {
            try
            {
                var _cost = await _bakkieDbContext.Costs.FirstOrDefaultAsync(p => p.CostId == CostId);
                if (_cost != null)
                {
                    _bakkieDbContext.Costs.Remove(_cost);
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

        public async Task<CostModel> GetCurrentCost()
        {
            try
            {
                var _cost = await _bakkieDbContext.Costs.FirstOrDefaultAsync(p => p.IsCurrent == true);
                if (_cost != null)
                    return new CostModel
                    {
                        CostId = _cost.CostId,
                        IsCurrent = _cost.IsCurrent,
                        Price = _cost.Price
                    };
                else
                    return null;
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
    }
}