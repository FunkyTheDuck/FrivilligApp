
using BlazorRepository;
using FrontendModels;

namespace BlazorWebsite.Components.Pages
{
    partial class Home
    {
        protected EventRepository eventRepo { get; set; }
        public List<Event> Events {  get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                eventRepo = new EventRepository();
                Events = await eventRepo.GetAllEventsAsync(1, 1, 1);
            }
        }
    }
}
