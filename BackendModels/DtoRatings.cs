using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendModels
{
    public class DtoRatings
    {
        public int DtoId {  get; set; }
        public int DtoSenderId { get; set; }
        public DtoUser DtoSender { get; set; }
        public int DtoReceiverId { get; set; }
        public DtoUser DtoReceiver { get; set; }
        public int DtoRating { get; set; }
        public string DtoReason { get; set; }

    }
}
