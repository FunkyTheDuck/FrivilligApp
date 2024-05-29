using ApiDBlayer;
using DbModels;
using FrontendModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ApiRepository
{
    public class RatingRepository
    {
        Database db;
        public RatingRepository() 
        {
            db = new Database();
        }
        public async Task<bool> CreateRatingAsync(Ratings rating)
        {
            DtoRatings ratings = new DtoRatings
            {
                Id = rating.Id,
                SenderId = rating.SenderId,
                ReceiverId = rating.ReceiverId,
                Rating = rating.Rating,
                Reason = rating.Reason,
            };
            await db.Ratings.AddAsync(ratings);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteRatingAsync(int ratingId)
        {
            DtoRatings dtoRating = await db.Ratings.FirstOrDefaultAsync(e => e.Id == ratingId);
            db.Ratings.Remove(dtoRating);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Ratings>> GetUsersRatingAsync(int userId)
        {
            List<DtoRatings> DtoRating = await db.Ratings.Where(x => x.ReceiverId == userId).Include(u => u.Sender).ToListAsync();
            List<Ratings> ratings = new List<Ratings>();
            foreach (DtoRatings dto in DtoRating) 
            {
                Ratings rating = new Ratings
                {
                    Id = dto.Id,
                    Sender = new User
                    {
                        Id = dto.Sender.Id,
                        Username = dto.Sender.Username
                    },
                    SenderId = dto.SenderId,
                    ReceiverId = dto.ReceiverId,
                    Rating = dto.Rating,
                    Reason = dto.Reason,
                };
                ratings.Add(rating);
            }
            return ratings;
        }
        public async Task<List<Ratings>> GetUsersNewestRatingsAsync(int userId)
        {
            List<DtoRatings> dtoRatings = await db.Ratings.Where(x => x.ReceiverId == userId).Include(u => u.Sender).OrderByDescending(x => x.Id).Take(3).ToListAsync();
            List<Ratings> ratings = new List<Ratings>();
            foreach(DtoRatings dto in dtoRatings)
            {
                Ratings rating = new Ratings
                {
                    Id = dto.Id,
                    Sender = new User
                    {
                        Id = dto.Sender.Id,
                        Username = dto.Sender.Username
                    },
                    SenderId = dto.SenderId,
                    ReceiverId = dto.ReceiverId,
                    Rating = dto.Rating,
                    Reason = dto.Reason
                };
                ratings.Add(rating);
            }
            return ratings;
        }
    }
}
