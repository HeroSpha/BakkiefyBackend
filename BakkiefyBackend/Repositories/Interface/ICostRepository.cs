using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakkiefyBackend.Model;

namespace BakkiefyBackend.Repositories.Interface
{
    public interface ICostRepository
    {
        Task<CostModel> AddCost(CostModel Cost);
        Task<CostModel> GetCurrentCost();
        Task<bool> DeleteCost(string CostId);
       
    }
}
