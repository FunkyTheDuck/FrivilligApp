using BlazorRepository;
using FrontendModels;

namespace BlazorWebsite.Components.Pages
{
    partial class CreateEvent
    {
        EventRepository repo { get; set; }
        public Event CreatedEvent { get; set; }
        protected async void OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                repo = new EventRepository();
            }
        }
        public async void CreateEventAsync()
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