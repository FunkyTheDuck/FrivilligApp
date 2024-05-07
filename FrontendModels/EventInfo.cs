using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendModels
{
    public class EventInfo
    {
        public int Id {  get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public List<Skills>? Skills { get; set; }
        public List<Interests>? Interests { get; set; }
        public double Distance {  get; set; }     

    }
}
