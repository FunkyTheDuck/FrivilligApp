using ApiDBlayer;
using BackendModels;
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
        public async Task<List<DtoInterests>> GetInterestsAsync()
        {
            List<DtoInterests> interests = new List<DtoInterests>();
            return interests;
        }
    }
}
