using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendModels
{
    public class UserInfo
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public User User { get; set; }
        public string Location { get; set; }
        public int Skills_id { get; set; }
        public List<Skills> Skills { get; set; }
        public int Interests_id {  get; set; }
        public List<Interests> interests { get; set; }
    }
}
