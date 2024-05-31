using BlazorRepository;
using FrontendModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorWebsite.Components.Pages
{
    partial class Home
    {
        [Inject]
        CustomAuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }
        [Inject]
        protected IEventRepository eventRepo { get; set; }
        public List<Event> Events {  get; set; }
        public User User { get; set; }


        public bool errorHappend;
        public bool succesHappend;
        public string message = string.Empty;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                User = new User
                {
                    Id = 3,
                    Username = "Simon Jensen"
                };
                StateHasChanged();
                Events = await eventRepo.GetAllEventsAsync(1, User.Id, 1, 1);
                StateHasChanged();
            }
        }
        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                navigationManager.NavigateTo("/login");
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