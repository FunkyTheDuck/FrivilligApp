using FrontendModels;
using MauiRepository;
using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FrivilligApp.ViewModels
{
    public class SignUpViewModel : BaseViewModels
    {
        public string username { get; set; }
        public string password { get; set; }
        public string repeatPassword { get; set; }
        public Command goBack { get; set; }
        public Command signUp { get; set; }
        public UserRepository UserRepository { get; set; }

        public SignUpViewModel() 
        {
            goBack = new Command(GoBack);
            signUp = new Command(SignUp);
            UserRepository = new UserRepository();
        }
        private async void GoBack()
        {
            await Shell.Current.GoToAsync("//Login");
        }
        private async void SignUp()
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(repeatPassword))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please fill in all fields", "ok");
                return;
            }
            else if (password != repeatPassword)
            {
                await App.Current.MainPage.DisplayAlert("Error", "make sure the password are the same", "ok");
                return;
            }
            else if (!(password.Length >= 8 && ContainsUppercaseLetter(password) && ContainsNumber(password)))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Password must be 8 characters long and contain at least one uppercase letter and one number.", "ok");
                return;
            }
            User user = new User
            {
                Username = username,
                UserCredebtials = new UserCredentials
                {
                    Password = BCrypt.Net.BCrypt.HashPassword(password),
                }

            };
            bool created = await UserRepository.CreateUser(user);
            if (created) 
            {
                User createdUser = await UserRepository.GetUserAsync(username, password);
                await SecureStorage.Default.SetAsync("userId", createdUser.Id.ToString());

                await Shell.Current.GoToAsync("//ChooseSkill");
            }
        }
        private bool ContainsUppercaseLetter(string password)
        {
            return password.Any(char.IsUpper);
        }
        private bool ContainsNumber(string password)
        {
            return password.Any(char.IsDigit);
        }
    }
}
