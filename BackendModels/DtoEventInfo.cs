using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendModels
{
    public class DtoEventInfo
    {
        public int DtoId {  get; set; }
        public int DtoEvent_id { get; set; }
        public DtoEvent DtoEvent { get; set; }
        public string DtoAddress { get; set; }
        public int DtoSkills_id { get; set; }
        public List<DtoSkills> DtoSkills { get; set; }
        public int DtoInterests_id { get; set; }
        public List<DtoInterests> DtoInterests { get; set; }
    }
}
