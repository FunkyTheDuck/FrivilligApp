using BlazorRepository;
using FrontendModels;

namespace BlazorWebsite.Components.Pages
{
    partial class CreateEvent
    {
        EventRepository repo { get; set; }
        public Event CreatedEvent { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                CreatedEvent = new Event();
                CreatedEvent.EventInfo = new EventInfo();
                repo = new EventRepository();
                StateHasChanged();
            }
        }
        public async Task HandleValidSubmit()
        {
            bool checkIfSucces;
            try
            {
                checkIfSucces = await repo.CreateAsync(CreatedEvent);
            }
            catch
            {
                checkIfSucces = false;
            }
            if(checkIfSucces)
            {

            }
        }
    }
}