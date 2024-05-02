using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendModels
{
    public class Event_info
    {
        public int Id {  get; set; }
        public int Event_id { get; set; }
        public Event Event { get; set; }
        public string Address { get; set; }
        public int Skills_id { get; set; }
        public List<Skills> Skills { get; set; }
        public int Interests_id { get; set; }
        public List<Interests> Interests { get; set; }
    }
}
