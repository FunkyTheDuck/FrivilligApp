﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels
{
    public class DtoEventInfoInterests
    {
        public int EventInfoId { get; set; }
        public int InterestsId { get; set; }
        public DtoEventInfo EventInfo { get; set; }
        public DtoInterests Interests { get; set; }
    }
}
