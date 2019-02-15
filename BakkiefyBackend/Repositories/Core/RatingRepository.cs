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
    public class RatingRepository : BaseRepository, IRatingRepository
    {
       
        public RatingRepository(BakkieDbContext bakkieDbContext)
            :base(bakkieDbContext)
        {
            
        }
        public async Task<RatingModel> AddRating(RatingModel ratingModel)
        {
            try
            {
                var rating = new Rating
                {
                    RatingsId = ratingModel.RatingsId,
                    BakkieRequestId = ratingModel.BakkieRequestId,
                    Rate = ratingModel.Rate,
                    Notes = ratingModel.Notes
                };
                var rate = await _bakkieDbContext.Ratings.AddAsync(rating);
                await _bakkieDbContext.SaveChangesAsync();
                return ratingModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<RatingModel> GetRatingModel(string RatingId)
        {
            var rating = await _bakkieDbContext.Ratings.FirstOrDefaultAsync(p => p.RatingsId == RatingId);
            if (rating != null)
            {
                return new RatingModel
                {
                    RatingsId = rating.RatingsId,
                    BakkieRequestId = rating.BakkieRequestId,
                    Rate = rating.Rate,
                    Notes = rating.Notes
                };
            }
            else
                return null;
        }

        public Task<List<RatingModel>> Getratings()
        {
            throw new NotImplementedException();
        }
    }
}