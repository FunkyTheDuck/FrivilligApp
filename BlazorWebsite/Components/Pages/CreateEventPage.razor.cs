using FrontendModels;

namespace BlazorWebsite.Components.Pages
{
    partial class CreateEventPage
    {
        public Event CreatedEvent { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                CreatedEvent = new Event();
                CreatedEvent.EventInfo = new EventInfo();
                StateHasChanged();
            }
        }
        public async void HandleValidSubmit()
        {

        }
    }
}