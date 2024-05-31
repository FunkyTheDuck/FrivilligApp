using BlazorRepository;
using FrontendModels;
using Microsoft.AspNetCore.Components;

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
        public User User { get; set; }
        public List<Event> Events { get; set; }
        public List<Ratings> NewestRatings { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                User = new User
                {
                    Id = 3,
                    Username = "Simon Jensen",
                    IsVoluntary = true
                };
                StateHasChanged();
                if(User.IsVoluntary)
                {
                    Events = await eventRepo.GetVoluntaryEventsAsync(User.Id);
                } else
                {
                    Events = await eventRepo.GetOwnersEventsAsync(User.Id);
                }
                StateHasChanged();
                NewestRatings = await ratingRepo.GetNewestRatingsAsync(User.Id);
                StateHasChanged();
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