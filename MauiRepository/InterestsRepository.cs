using BackendModels;
using FrontendModels;
using MauiDBlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiRepository
{
    public class InterestsRepository
    {
        DBAccess db;
        public InterestsRepository()
        {
            db = new DBAccess();
        }
        public async Task<List<Interests>> GetAllAsync()
        {
            List<Interests> interests = new List<Interests>();
            List<DtoInterests> dtoInterests = await db.GetInterestsAsync();
            foreach (DtoInterests inter in dtoInterests)
            {
                Interests Interest = new Interests
                {
                    Id = inter.Id,
                    Interest = inter.Interest
                };
                interests.Add(Interest);
            }
            return interests;
        }
    }
}
