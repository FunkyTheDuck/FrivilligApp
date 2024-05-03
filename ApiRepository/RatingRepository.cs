using ApiDBlayer;
using BackendModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository
{
    public class RatingRepository
    {
        Database db;
        public RatingRepository() 
        {
            db = new Database();
        }
        public async Task<bool> CreateRating(DtoRatings rating)
        {
            return true;
        }

        public async Task<bool> DeleteRating(int ratingId)
        {
            return true;
        }

        public async Task<List<DtoRatings>> GetUsersRating(int userId)
        {
            List<DtoRatings> Rating = new List<DtoRatings>();
            return Rating;
        }
    }
}
