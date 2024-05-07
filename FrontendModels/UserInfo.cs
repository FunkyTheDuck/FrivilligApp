using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendModels
{
    public class UserInfo
    {
        public int Id { get; set; }
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public List<Skills>? Skills { get; set; }
        public List<Interests>? interests { get; set; }
    }
}
