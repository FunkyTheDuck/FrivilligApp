using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendModels
{
    public class Event
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public User? Owner { get; set; }
        public int VoluntaryId { get; set; }
        public List<User>? Volunteers { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(101)]
        public string? ImageUrl { get; set; }
        public int WantedVolunteers { get; set; }
        public int EventInfoId { get; set; }
        public EventInfo EventInfo { get; set; }
    }
}
