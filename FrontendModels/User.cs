using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendModels
{
    public class User
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public List<Event>? Events { get; set; }
        public bool IsVoluntary { get; set; }
        [MaxLength(20)]
        public string Username { get; set; }
    }
}
