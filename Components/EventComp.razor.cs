using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontendModels;
using Microsoft.AspNetCore.Components;

namespace Components
{
    partial class EventComp
    {
        [Parameter]
        public Event ShownEvent { get; set; }
        [Parameter]
        public string ButtonName { get; set; }
        [Parameter]
        public EventCallback AddVoluntaryToEvent { get; set; }
        [Parameter]
        public EventCallback RemoveVoluntaryFromEvent { get; set ; }
        [Parameter]
        public EventCallback EditEvent { get; set; }
        
        public async Task AddVoluntaryToEventAsync()
        {
            await AddVoluntaryToEvent.InvokeAsync();
        }
        public async Task RemoveVoluntaryFromEventAsync()
        {
            await AddVoluntaryToEvent.InvokeAsync();
        }
        public async Task EditEventAsync()
        {
            await AddVoluntaryToEvent.InvokeAsync();
        }
    }
}