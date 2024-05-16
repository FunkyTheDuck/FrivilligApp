using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels
{
    public class DtoUserInfoSkills
    {
        public int UserInfoId { get; set; }
        public int SkillsId { get; set; }
        public DtoUserInfo UserInfo { get; set; }
        public DtoSkills Skills { get; set; }
    }
}
