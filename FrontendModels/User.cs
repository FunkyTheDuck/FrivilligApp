﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendModels
{
    public class User
    {
        public int Id { get; set; }
        public int Event_id { get; set; }
        public List<Event>? Events { get; set; }
        public bool IsVoluntary { get; set; }
        public string Username { get; set; }
    }
}
