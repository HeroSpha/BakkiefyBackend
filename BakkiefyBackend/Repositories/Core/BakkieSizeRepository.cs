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
    public class BakkieSizeRepository : BaseRepository, IBakkieSizeRepository
    {
        public BakkieSizeRepository(BakkieDbContext bakkieDbContext)
            :base(bakkieDbContext)
        {

        }
        public async Task<BakkieSizeModel> Add(BakkieSizeModel bakkieSizeModel)
        {
            try
            {
                var bakkieSize = new BakkieSize
                {
                    BakkieSizeId = bakkieSizeModel.BakkieSizeId,
                    ClassName = bakkieSizeModel.ClassName,
                    TonsRange = bakkieSizeModel.TonsRange,
                    Description = bakkieSizeModel.Description
                };
                var _added = await _bakkieDbContext.BakkieSizes.AddAsync(bakkieSize);
                await _bakkieDbContext.SaveChangesAsync();
                return bakkieSizeModel;
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<List<BakkieSizeModel>> BakkieSizes()
        {
            try
            {
                var sizes = await _bakkieDbContext.BakkieSizes.ToListAsync();
                return sizes.Select(size => new BakkieSizeModel
                {
                    BakkieSizeId = size.BakkieSizeId,
                    ClassName = size.ClassName,
                    TonsRange = size.TonsRange,
                    Description = size.Description
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(int BakkieSizeId)
        {
            try
            {
                var _deleted = await _bakkieDbContext.BakkieSizes.FirstOrDefaultAsync(p => p.BakkieSizeId == BakkieSizeId);
                if (_deleted != null)
                {
                    _bakkieDbContext.BakkieSizes.Remove(_deleted);
                    await _bakkieDbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
    }
}