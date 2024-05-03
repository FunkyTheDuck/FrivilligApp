using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendModels
{
    public class DtoUser
    {
        public int DtoId { get; set; }
        public int DtoEventÍd { get; set; }
        public List<DtoEvent>? DtoEvents { get; set; }
        public bool DtoIsVoluntary { get; set; }
        public string DtoUsername { get; set; }
    }
}
