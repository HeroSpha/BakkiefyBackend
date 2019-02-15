using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakkiefyBackend.Model;

namespace BakkiefyBackend.Repositories.Interface
{
    public interface IBakkieRequestRepository
    {
        Task<BakkieRequestModel> AddRequest(BakkieRequestModel bakkieRequestModel);
        Task<BakkieRequestModel> UpdateRequest(BakkieRequestModel bakkieRequestModel);
        Task<BakkieRequestModel> GetBakkieRequest(string BakkieRequestId);
        Task<bool> DeleteRequest(string BakkieRequestId);
        Task<List<BakkieRequestModel>> GetCustomerRequests(string CustomerId);
        Task<List<BakkieRequestModel>> GetDriverRequests(string BakkieId);
    }
}
