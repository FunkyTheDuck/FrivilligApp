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
    public class SkillsRepository : ISkillsRepository
    {
        DBAccess db { get; set; }
        public SkillsRepository()
        {
            db = new DBAccess();
        }
        public async Task<List<Skills>> GetAllAsync()
        {
            List<DtoSkills> dtoSkills;
            try
            {
                dtoSkills = await db.GetAllSkillsAsync();
            }
            catch
            {
                return null;
            }
            if (dtoSkills != null && dtoSkills.Count != 0)
            {
                List<Skills> skills = new List<Skills>();
                foreach (DtoSkills dto in dtoSkills)
                {
                    Skills newSkill = new Skills
                    {
                        Id = dto.Id,
                        Skill = dto.Skill
                    };
                    skills.Add(newSkill);
                }
                return skills;
            }
            return null;
        }
    }
}
