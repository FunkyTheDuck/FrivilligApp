using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendModels
{
    public class UserCookie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Token { get; set; }
        public DateTime? TokenExpires { get; set; }
    }
}
