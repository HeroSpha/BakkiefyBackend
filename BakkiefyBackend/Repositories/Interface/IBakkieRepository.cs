using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakkiefyBackend.Model;

namespace BakkiefyBackend.Repositories.Interface
{
    public interface IBakkieRepository
    {
        Task AddBakkie(BakkieModel Bakkie);
        Task<List<BakkieModel>> GetOnlineBakkies();
        Task<List<BakkieModel>> GetClosekkies();
        Task<bool> DeleteBack(string BakkieId);
        Task<BakkieModel> UpdateBakkie(BakkieModel Bakkie);
        Task<List<BakkieModel>> GetBakkies();
        Task<BakkieModel> GetBakkie(string BakkieId);
    }
}
