using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendModels
{
    public class UserInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [MaxLength(50)]
        public string Location { get; set; }
        public int SkillsId { get; set; }
        public List<Skills> Skills { get; set; }
        public int InterestsId {  get; set; }
        public List<Interests> interests { get; set; }
    }
}
