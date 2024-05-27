using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels
{
    public class DtoEventInfoSkills
    {
        public int EventInfoId { get; set; }
        public int SkillsId { get; set; }
        public DtoEventInfo EventInfo { get; set; }
        public DtoSkills Skills { get; set; }
    }
}
