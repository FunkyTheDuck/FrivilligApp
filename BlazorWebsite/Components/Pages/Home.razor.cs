using BlazorRepository;
using BlazorWebsite.Utils;
using FrontendModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace BlazorWebsite.Components.Pages
{
    partial class Home
    {
        [Inject]
        protected IEventRepository eventRepo { get; set; }
        [Inject]
        protected IUserRepository userRepo { get; set; }
        public List<Event> Events {  get; set; }
        public User User { get; set; }
        private DotNetObjectReference<LocalStorageHelper> localStorageHelper;

        public bool errorHappend;
        public bool succesHappend;
        public string message = string.Empty;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                localStorageHelper = DotNetObjectReference.Create(new LocalStorageHelper(JS));
                User = await userRepo.GetUserFromIdAsync(Convert.ToInt32(await localStorageHelper.Value.GetAsync("userId")));
                if(User != null)
                {
                    StateHasChanged();
                    Events = await eventRepo.GetAllEventsAsync(1, User.Id, 1, 1);
                }
                StateHasChanged();
            }
        }
        public async Task MeldBrugerTilAsync(int eventId)
        {
            bool checkIfSucces;
            try
            {
                checkIfSucces = await eventRepo.AddVoluntaryToEventAsync(User.Id, eventId);
            }
            catch
            {
                checkIfSucces = false;
            }
            if(checkIfSucces)
            {
                SuccesHappendAsync("Du er nu tilmeldt begivenheden");
            } 
            else
            {
                ErrorHappendAsync("Kunne ikke tilmelde dig til begivenheden");
            }
        }


        private async Task ErrorHappendAsync(string message)
        {
            errorHappend = true;
            this.message = message;
            StateHasChanged();
            MessageTimerAsync();
        }
        private async Task SuccesHappendAsync(string message)
        {
            succesHappend = true;
            this.message = message;
            StateHasChanged();
            MessageTimerAsync();
        }
        private async Task MessageTimerAsync()
        {
            await Task.Delay(5000);
            succesHappend = false;
            errorHappend = false;
            StateHasChanged();
        }
    }
}