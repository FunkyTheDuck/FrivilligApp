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
        public int EventId { get; set; }
        public Event Event { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        public int SkillsId { get; set; }
        public List<Skills> Skills { get; set; }
        public int InterestsId { get; set; }
        public List<Interests> Interests { get; set; }
    }
}
