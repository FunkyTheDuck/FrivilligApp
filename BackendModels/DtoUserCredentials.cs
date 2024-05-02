using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendModels
{
    public class DtoUserCredentials
    {
        public int DtoId { get; set; }
        public int DtoUser_id { get; set; }
        public DtoUser DtoUser { get; set; }
        public string Dtopassword { get; set; }
    }
}
