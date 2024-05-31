using FrontendModels;
using BlazorRepository;
using Microsoft.AspNetCore.Components;
using BlazorWebsite.Utils;
using Microsoft.JSInterop;

namespace BlazorWebsite.Components.Pages
{
    partial class ChangeInterestsSkillsPage
    {
        [Inject]
        protected ISkillsRepository skillsRepo {  get; set; }
        [Inject]
        protected IInterestsRepository interestsRepo { get; set; }
        [Inject]
        protected IUserRepository userRepo { get; set; }
        private DotNetObjectReference<LocalStorageHelper> localStorageHelper;


        public List<Skills> AllSkills { get; set; }
        public List<Interests> AllInterests { get; set; }

        public User User { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                localStorageHelper = DotNetObjectReference.Create(new LocalStorageHelper(JS));
                AllSkills = await skillsRepo.GetAllAsync();
                AllInterests = await interestsRepo.GetAllAsync();
                try
                {
                    User = await userRepo.GetUserFromIdAsync(Convert.ToInt32(await localStorageHelper.Value.GetAsync("userId")));
                }
                catch
                {
                    //error happend
                }
                if (User != null && User.UserInfo != null)
                {
                    if(User.UserInfo.interests == null)
                    {
                        User.UserInfo.interests = new List<Interests>();
                    }
                    if(User.UserInfo.Skills == null)
                    {
                        User.UserInfo.Skills = new List<Skills>();
                    }
                }
                else
                {
                    //error happend
                }
                StateHasChanged();
            }
        }
        public async Task AddTooSkillsAsync(Skills skill)
        {

        }
        public async Task RemoveFromSkillsAsync(Skills skill)
        {

        }
        public async Task AddTooInterestsAsync(Interests interest)
        {

        }
        public async Task RemoveFromInterestsAsync(Interests interest)
        {

        }
    }
}