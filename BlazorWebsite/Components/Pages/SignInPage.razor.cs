using BlazorRepository;
using BlazorWebsite.Utils;
using FrontendModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.ComponentModel;

namespace BlazorWebsite.Components.Pages
{
    partial class SignInPage
    {
        [Inject]
        protected IUserRepository userRepo {  get; set; }
        private DotNetObjectReference<LocalStorageHelper> localStorageHelper;

        public string Username { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
        public bool IsVoluntary { get; set; }
        public async Task SignUserUpAsync()
        {
            if(Username.Length > 3)
            {
                if(Password.Length < 8)
                {
                    return;
                }
                if(Password == RepeatedPassword)
                {
                    bool checkIfSucces = await userRepo.CreateUserAsync(Username, Password, IsVoluntary);
                    if(checkIfSucces)
                    {
                        localStorageHelper = DotNetObjectReference.Create(new LocalStorageHelper(JS));
                        User user = await userRepo.LogUserInAsync(Username, Password);
                        if(user != null)
                        {
                            await localStorageHelper.Value.SaveAsync("userId", user.Id.ToString());
                        }
                        navigationManager.NavigateTo("choose");
                    }
                }
            }

        }
        public async Task GoBackToLogInAsync()
        {
            navigationManager.NavigateTo("login");
        }
    }
}