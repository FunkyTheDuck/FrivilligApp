using BlazorRepository;
using FrontendModels;

namespace BlazorWebsite.Components.Pages
{
    partial class ProfilePage
    {
        protected EventRepository eventRepo {  get; set; }
        protected RatingRepository ratingRepo { get; set; }
        public User User { get; set; }
        public List<Event> Events { get; set; }
        public List<Ratings> NewestRatings { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                eventRepo = new EventRepository();
                ratingRepo = new RatingRepository();
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
    }
}