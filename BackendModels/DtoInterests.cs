using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendModels
{
    public class DtoInterests
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Interest {  get; set; }
    }
}
