using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels
{
    public class DtoEventUser
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DtoEvent Event { get; set; }
        public DtoUser User { get; set; }
    }
}
