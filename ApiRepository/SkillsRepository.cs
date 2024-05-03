using ApiDBlayer;
using BackendModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository
{
    public class SkillsRepository
    {
        Database db;
        public SkillsRepository() 
        {
           db = new Database();
        }
        public async Task<List<DtoSkills>> GetSkills()
        {
            List<DtoSkills> skills = new List<DtoSkills>();
            return skills;
        }
    }
}
