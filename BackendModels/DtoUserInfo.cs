using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendModels
{
    public class DtoUserInfo
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public List<DtoSkills>? Skills { get; set; }
        public List<DtoInterests>? Interests { get; set; }
    }
}
