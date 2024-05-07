using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendModels
{
    public class DtoSkills
    {
        public int Id {  get; set; }
        [MaxLength(30)]
        public string Skill {  get; set; }
        public List<DtoUserInfo> UserInfo { get; set; }
        public List<DtoEventInfo> EventInfo { get; set; }
    }
}
