using FrontendModels;
using MauiRepository;
using Microsoft.Maui.Devices.Sensors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrivilligApp.ViewModels
{
    public class ProfileViewModel : BaseViewModels
    {
        EventRepository EventRepository { get; set; }
        UserRepository UserRepository { get; set; }
        public ObservableCollection<Event> Events { get; set; }
        public List<Event> AllEvents { get; set; }
        public User User { get; set; }
        public string interests { get; set; }
        public string skills { get; set; }
        public Command meldTil { get; set; }
        public Command profil { get; set; }
        public Command home { get; set; }
        public Command change { get; set; }
        public Command addEvent { get; set; }
        public ProfileViewModel()
        {
            EventRepository = new EventRepository();
            UserRepository = new UserRepository();
            GetEvents();
            meldTil = new Command<Event>(MeldTil);
            profil = new Command(Profil);
            home = new Command(Home);
            change = new Command(Change);
            addEvent = new Command(AddEvent);
        }
        private async void GetEvents()
        {
            string userId = await SecureStorage.Default.GetAsync("userId");
            User = await UserRepository.GetUserAsync(Convert.ToInt32(userId));
            OnPropChanged(nameof(User));
            if (User.IsVoluntary == true)
            {
                for (int i = 0; i < User.UserInfo.Skills.Count; i++)
                {
                    if (i != User.UserInfo.Skills.Count - 1)
                    {
                        skills += User.UserInfo.Skills[i].Skill + ", ";
                    }
                    else
                    {
                        skills += User.UserInfo.Skills[i].Skill;
                    }
                }
                for (int i = 0; i < User.UserInfo.interests.Count; i++)
                {
                    if (i != User.UserInfo.interests.Count - 1)
                    {
                        interests += User.UserInfo.interests[i].Interest + ", ";
                    }
                    else
                    {
                        interests += User.UserInfo.interests[i].Interest;
                    }
                }
                OnPropChanged(nameof(interests));
                OnPropChanged(nameof(skills));
                AllEvents = await EventRepository.GetEventToUserAsync(User.Id);
            }
            else
            {
                AllEvents = await EventRepository.GetEventToOwnerAsync(User.Id);
            }
            Location location = await Geolocation.Default.GetLocationAsync();
            Events = new ObservableCollection<Event>();
            for (int i = 0; i < AllEvents.Count; i++)
            {
                Events.Add(AllEvents[i]);
                Events[i].EventInfo.Distance = GetDistance(location.Latitude, location.Longitude, Events[i].EventInfo.CoordinateX, Events[i].EventInfo.CoordinateY);
            }
            OnPropChanged(nameof(Events));
        }
        private int GetDistance(double lat1, double lon1, double lat2, double lon2)
        {
            int R = 6371; // Radius of the earth in km
            double dLat = deg2rad(lat2 - lat1);  // deg2rad below
            double dLon = deg2rad(lon2 - lon1);
            double a =
              Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
              Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) *
              Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
              ;
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = R * c; // Distance in km
            return Convert.ToInt32(d);
        }
        private double deg2rad(double deg)
        {
            return deg * (Math.PI / 180);
        }
        private async void MeldTil(Event choseEvent)
        {
            if (User.IsVoluntary == true)
            {
                EventRepository.RemoveVoluntaryFromEvent(User.Id, choseEvent.Id);
                Events.Remove(choseEvent);
            }
            else
            {
                await Shell.Current.GoToAsync("//AddEvent");
            }
        }
        private async void Profil()
        {
            await Shell.Current.GoToAsync("//Profile", false);
        }
        private async void Home()
        {
            await Shell.Current.GoToAsync("//Events");
        }
        private async void Change() 
        {
            await Shell.Current.GoToAsync("//ChooseSkill");
        }
        private async void AddEvent()
        {
            await Shell.Current.GoToAsync("//AddEvent");
        }
    }
}
