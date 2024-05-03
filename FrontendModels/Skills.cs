using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendModels
{
    public class Skills
    {
        public int Id {  get; set; }
        [MaxLength(30)]
        public string Skill {  get; set; }
    }
}
