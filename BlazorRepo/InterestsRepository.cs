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
    public class InterestsRepository
    {
        DBAccess db {  get; set; }
        public InterestsRepository()
        {
            db = new DBAccess();
        }
        public async Task<List<Interests>> GetAllAsync()
        {
            List<DtoInterests> dtoInterests;
            try
            {
                dtoInterests = await db.GetAllInterestsAsync();
            }
            catch
            {
                return null;
            }
            if(dtoInterests != null && dtoInterests.Count != 0)
            {
                List<Interests> interests = new List<Interests>();
                foreach(DtoInterests dto in dtoInterests)
                {
                    Interests newInterest = new Interests
                    {
                        Id = dto.Id,
                        Interest = dto.Interest
                    };
                    interests.Add(newInterest);
                }
                return interests;
            }
            return null;
        }
    }
}
