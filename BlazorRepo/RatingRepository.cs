using BackendModels;
using BlazorDBlayer;
using FrontendModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRepository
{
    public class RatingRepository
    {
        protected DBAccess db { get; set; }

        public RatingRepository()
        {
            db = new DBAccess();
        }
        public async Task<List<Ratings>> GetNewestRatingsAsync(int userId)
        {
            List<DtoRatings> dtoRatings;
            try
            {
                dtoRatings = await db.GetNewestRatingsAsync(userId);
            }
            catch
            {
                return null;
            }
            if(dtoRatings != null && dtoRatings.Count != 0)
            {
                List<Ratings> ratings = new List<Ratings>();
                for(int i = 0; i < dtoRatings.Count; i++)
                {
                    Ratings rating = ConvertFromDto(dtoRatings[i]);
                    ratings.Add(rating);
                }
                return ratings;
            }
            return null;
        }
        public async Task<List<Ratings>> GetAllUsersRatinigsAsync(int userId)
        {
            List<DtoRatings> dtoRatings;
            try
            {
                dtoRatings = await db.GetAllUsersRatingsAsync(userId);
            }
            catch
            {
                return null;
            }
            if (dtoRatings != null && dtoRatings.Count != 0)
            {
                List<Ratings> ratings = new List<Ratings>();
                for (int i = 0; i < dtoRatings.Count; i++)
                {
                    Ratings rating = ConvertFromDto(dtoRatings[i]);
                    ratings.Add(rating);
                }
                return ratings;
            }
            return null;
        }


        private Ratings ConvertFromDto(DtoRatings dtoRating)
        {
            Ratings newRating = new Ratings
            {
                Id = dtoRating.Id,
                Sender = new User
                {
                    Id = dtoRating.Sender.Id,
                    Username = dtoRating.Sender.Username
                },
                SenderId = dtoRating.SenderId,
                ReceiverId = dtoRating.ReceiverId,
                Rating = dtoRating.Rating,
                Reason = dtoRating.Reason,
            };
            return newRating;
        }
        private DtoRatings ConvertToDto(Ratings rating)
        {
            DtoRatings newDtoRating = new DtoRatings
            {
                Id = rating.Id,
                SenderId = rating.SenderId,
                ReceiverId = rating.ReceiverId,
                Rating = rating.Rating,
                Reason = rating.Reason,
            };
            return newDtoRating;
        }
    }
}