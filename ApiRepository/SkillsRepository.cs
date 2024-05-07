using ApiDBlayer;
using DbModels;
using FrontendModels;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Skills>> GetSkillsAsync()
        {
            List<DtoSkills> dtoSkills = new List<DtoSkills>();
            List<Skills> skills = new List<Skills>();
            try
            {
                dtoSkills = await db.Skills.ToListAsync();
            }
            catch (Exception)
            {
                return new List<Skills>();
            }
            foreach (DtoSkills dto in dtoSkills)
            {
                Skills skill = new Skills
                {
                    Id = dto.Id,
                    Skill = dto.Skill
                };
                skills.Add(skill);
            }
            return skills;
        }
    }
}
