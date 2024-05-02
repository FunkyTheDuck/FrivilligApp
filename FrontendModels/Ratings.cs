using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendModels
{
    public class Ratings
    {
        public int Id {  get; set; }
        public int Sender_id { get; set; }
        public User Sender { get; set; }
        public int Receiver_id { get; set; }
        public User Receiver { get; set; }
        public int Rating { get; set; }
        public string Reason { get; set; }

    }
}
