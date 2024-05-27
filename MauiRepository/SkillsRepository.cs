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
    public class SkillsRepository
    {
        DBAccess db;
        public SkillsRepository() 
        {
            db = new DBAccess();
        }
        public async Task<List<Skills>> GetAllAsync()
        {
            List<Skills> skills = new List<Skills>();
            List<DtoSkills> dtoSkills = await db.GetSkillsAsync();
            foreach (DtoSkills sk in dtoSkills)
            {
                Skills skill = new Skills
                {
                    Id = sk.Id,
                    Skill = sk.Skill
                };
                skills.Add(skill);
            }
            return skills;
        }
    }
}
