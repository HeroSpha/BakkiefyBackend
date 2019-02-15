using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakkiefyBackend.Model;

namespace BakkiefyBackend.Repositories.Interface
{
    public interface IOnlineRepository
    {
        Task<OnlineModel> GoOnline(OnlineModel Online);
        Task<OnlineModel> GoOffline(OnlineModel Online);
        Task<bool> DeleteOnline(string OnlineId);
        Task<List<OnlineModel>> GetList();
    }
}
