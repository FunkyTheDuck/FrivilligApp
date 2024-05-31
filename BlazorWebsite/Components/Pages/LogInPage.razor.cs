using BlazorRepository;
using FrontendModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using BlazorWebsite;
using Microsoft.JSInterop;
using BlazorWebsite.Utils;

namespace BlazorWebsite.Components.Pages
{
    partial class LogInPage
    {
        [Inject]
        protected IUserRepository userRepo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public User User { get; set; }

        private DotNetObjectReference<LocalStorageHelper> localStorageHelper;

        public async Task LogUserInAsync()
        {
            localStorageHelper = DotNetObjectReference.Create(new LocalStorageHelper(JS));
            User = await userRepo.LogUserInAsync(Username, Password);
            if (User != null)
            {
                //await AuthenticationStateProvider.MarkUserAsAuthenticated(User.Username);
                await localStorageHelper.Value.SaveAsync("userId", User.Id.ToString());
                navigationManager.NavigateTo("/");
                //login
            }
            //failed
        }
        public async Task GoToSignUpAsync()
        {
            navigationManager.NavigateTo("signup");
        }
    }
}