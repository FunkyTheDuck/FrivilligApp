using BlazorRepository;
using BlazorWebsite.Utils;
using FrontendModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorWebsite.Components.Pages
{
    partial class ProfilePage
    {
        [Inject]
        protected IEventRepository eventRepo {  get; set; }
        [Inject]
        protected IRatingRepository ratingRepo { get; set; }
        [Inject]
        protected IUserRepository userRepo { get; set; }

        private DotNetObjectReference<LocalStorageHelper> localStorageHelper;

        public User User { get; set; }
        public List<Event> Events { get; set; }
        public List<Ratings> NewestRatings { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                localStorageHelper = DotNetObjectReference.Create(new LocalStorageHelper(JS));
                User = await userRepo.GetUserFromIdAsync(Convert.ToInt32(await localStorageHelper.Value.GetAsync("userId")));
                StateHasChanged();
                if(User != null)
                {
                    if (User.IsVoluntary)
                    {
                        Events = await eventRepo.GetVoluntaryEventsAsync(User.Id);
                    }
                    else
                    {
                        Events = await eventRepo.GetOwnersEventsAsync(User.Id);
                    }
                    StateHasChanged();
                    NewestRatings = await ratingRepo.GetNewestRatingsAsync(User.Id);
                    StateHasChanged();
                }
            }
        }
        public async Task RemoveUserFromEvent()
        {

        }
        public async Task ChangeInterestsAndSkills()
        {

        }
    }
}