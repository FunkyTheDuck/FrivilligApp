using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendModels
{
    public class DtoUserInfo
    {
        public int DtoId { get; set; }
        public int DtoUserId { get; set; }
        public DtoUser DtoUser { get; set; }
        public string DtoLocation { get; set; }
        public int DtoSkillsId { get; set; }
        public List<DtoSkills> DtoSkills { get; set; }
        public int DtoInterests_id {  get; set; }
        public List<DtoInterests> DtoInterests { get; set; }
    }
}
