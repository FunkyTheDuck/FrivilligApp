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
        [Inject]
        NavigationManager navigationManager { get; set; }
        [Parameter]
        public User User { get; set; }
        public async Task GoToProfilePageAsync()
        {
            if (User != null)
            {
                navigationManager.NavigateTo("profile");
            }
        }
        public async Task GoToHomePageAsync()
        {
            if(User != null)
            {
                navigationManager.NavigateTo("/");
            }
        }
    }
}