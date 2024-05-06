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
        [MaxLength(50)]
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public int SkillsId { get; set; }
        public List<Skills> Skills { get; set; }
        public int InterestsId { get; set; }
        public List<Interests> interests { get; set; }
    }
}
