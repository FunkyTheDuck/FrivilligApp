using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels
{
    public class DtoEvent
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        [NotMapped]
        public DtoUser Owner { get; set; }
        public int VoluntaryId { get; set; }
        public List<DtoUser>? Volunteers { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(101)]
        public string? ImageUrl { get; set; }
        public int WantedVolunteers { get; set; }
        public int EventInfoId { get; set; }
        public DtoEventInfo EventInfo { get; set; }
    }
}
