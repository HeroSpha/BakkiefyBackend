using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BakkiefyBackend.Model;

namespace BakkiefyBackend.Repositories.Interface
{
    public interface IRatingRepository
    {
        Task<RatingModel> AddRating(RatingModel ratingModel);
        Task<RatingModel> GetRatingModel(string RatingId);
        Task<List<RatingModel>> Getratings();
    }
}