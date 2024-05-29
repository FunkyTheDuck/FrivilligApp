using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendModels
{
    public class DtoUser
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public List<DtoEvent>? Events { get; set; }
        public bool IsVoluntary { get; set; }
        [MaxLength(20)]
        public string Username { get; set; }
        public int UserCredebtialsId { get; set; }  
        public DtoUserCredentials UserCredebtials { get; set;}
        public int UserInfoId {  get; set; }
        public DtoUserInfo UserInfo { get; set; }
    }
}
