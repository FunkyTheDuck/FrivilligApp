using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendModels
{
    public class DtoEventInfo
    {
        public int Id {  get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public List<DtoSkills>? Skills { get; set; }
        public List<DtoInterests>? Interests { get; set; }
        public double Distance { get; set; }
    }
}
