using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendModels
{
    public class DtoUserInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DtoUser User { get; set; }
        [MaxLength(50)]
        public string Location { get; set; }
        public int SkillsId { get; set; }
        public List<DtoSkills> Skills { get; set; }
        public int InterestsId {  get; set; }
        public List<DtoInterests> Interests { get; set; }
    }
}
