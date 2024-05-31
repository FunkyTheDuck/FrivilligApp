using BlazorRepository;
using Microsoft.AspNetCore.Components;

namespace BlazorWebsite.Components.Pages
{
    partial class SignInPage
    {
        [Inject]
        protected IUserRepository userRepo {  get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }

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
                    bool checkIfSucces = await userRepo.CreateUserAsync(Username, Password);
                    if(checkIfSucces)
                    {

                    }
                }
            }

        }
        public async Task GoBackToLogInAsync()
        {

        }
    }
}