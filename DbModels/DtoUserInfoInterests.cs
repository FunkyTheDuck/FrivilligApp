using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels
{
    public class DtoUserInfoInterests
    {
        public int UserInfoId { get; set; }
        public int InterestsId { get; set; }
        public DtoUserInfo UserInfo { get; set; }
        public DtoInterests Interests { get; set; }
    }
}
