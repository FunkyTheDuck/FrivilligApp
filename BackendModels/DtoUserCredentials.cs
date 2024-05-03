﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendModels
{
    public class DtoUserCredentials
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DtoUser User { get; set; }
        public string Password { get; set; }
    }
}
