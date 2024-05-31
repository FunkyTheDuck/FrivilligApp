using BlazorRepository;
using FrontendModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using BlazorWebsite;

namespace BlazorWebsite.Components.Pages
{
    partial class LogInPage
    {
        [Inject]
        public CustomAuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        public IHttpContextAccessor HttpContextAccessor { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        protected IUserRepository userRepo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public User User { get; set; }

        public async Task LogUserInAsync()
        {
            User = await userRepo.LogUserInAsync(Username, Password);
            if (User != null)
            {
                //await AuthenticationStateProvider.MarkUserAsAuthenticated(User.Username);
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