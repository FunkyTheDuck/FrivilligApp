using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendModels
{
    public class DtoRatings
    {
        public int Id {  get; set; }
        public int SenderId { get; set; }
        public DtoUser Sender { get; set; }
        public int ReceiverId { get; set; }
        public DtoUser Receiver { get; set; }
        public int Rating { get; set; }
        [MaxLength(200)]
        public string Reason { get; set; }

    }
}
