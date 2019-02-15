using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakkiefyBackend.Model;

namespace BakkiefyBackend.Repositories.Interface
{
    public interface IBakkieSizeRepository
    {
        Task<BakkieSizeModel> Add(BakkieSizeModel bakkieSizeModel);


        Task<List<BakkieSizeModel>> BakkieSizes();
        Task<bool> Delete(int BakkieSizeId);
    }
}
