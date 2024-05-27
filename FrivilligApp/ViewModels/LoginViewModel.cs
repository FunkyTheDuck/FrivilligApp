using FrontendModels;
using MauiRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrivilligApp.ViewModels
{
    public class LoginViewModel : BaseViewModels
    {
        public string username { get; set; }
        public string password { get; set; }
        public Command goToSignUp { get; set; }
        public Command login { get; set; }
        public UserRepository UserRepository { get; set; }
        public LoginViewModel() 
        {
            goToSignUp = new Command(GoToSignUp);
            login = new Command(Login);
            UserRepository = new UserRepository();
        }
        private async void GoToSignUp()
        {
            await Shell.Current.GoToAsync("//SignUp");
        }
        private async void Login()
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please fill in all fields", "ok");
                return;
            }
            try
            {
                User user = await UserRepository.GetUserAsync(username, password);
                if (user != null)
                {
                    await SecureStorage.Default.SetAsync("userId", user.Id.ToString());

                    await Shell.Current.GoToAsync("//Events");
                }
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Username or password is incorrect", "ok");
                return;
            }
        }
    }
}
