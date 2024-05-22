using FrontendModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    partial class NavbarComp
    {
        [Parameter]
        public User User { get; set; }

    }
}