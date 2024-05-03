﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendModels
{
    public class UserCredentials
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Password { get; set; }
    }
}
