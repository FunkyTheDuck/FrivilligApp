using ApiDBlayer;
using BackendModels;
using FrontendModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository
{
    public class InterestsRepository
    {
        Database db;
        public InterestsRepository()
        {
            db = new Database();
        }
        public async Task<List<Interests>> GetInterestsAsync()
        {
            List<DtoInterests> dtointerests = new List<DtoInterests>();
            List<Interests> interests = new List<Interests>();
            try
            {
                dtointerests = await db.Interests.ToListAsync();
            }
            catch (Exception)
            {
                return new List<Interests>();
            }
            foreach (DtoInterests dto in dtointerests) 
            {
                Interests interest = new Interests
                {
                    Id = dto.Id,
                    Interest = dto.Interest
                };
                interests.Add(interest);
            }
            return interests;
        }
    }
}
