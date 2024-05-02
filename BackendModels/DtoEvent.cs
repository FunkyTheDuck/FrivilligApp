using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendModels
{
    public class DtoEvent
    {
        public int DtoId { get; set; }
        public int DtoOwner_id { get; set; }
        public DtoUser DtoOwner { get; set; }
        public int DtoVoluntary_id { get; set; }
        public List<DtoUser> DtoVolunteers { get; set; }
        public string DtoTitle { get; set; }
        public string DtoDescription { get; set; }
        public string DtoImage_url { get; set; }
        public int DtoWanted_volunteers { get; set; }
    }
}
