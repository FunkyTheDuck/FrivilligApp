using FrontendModels;
using MauiRepository;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrivilligApp.ViewModels
{
    public class EventsViewModel : BaseViewModels
    {
        EventRepository EventRepository { get; set; }
        UserRepository UserRepository { get; set; }
        public int distance { get; set; }
        public ObservableCollection<Event> Events { get; set; }
        public List<Event> AllEvents { get; set; }
        public List<Event> UserEvent { get; set; }
        public User User { get; set; }
        public Command meldTil {  get; set; }
        public Command profil { get; set; }
        public Command home { get; set; }
        public EventsViewModel() 
        {
            EventRepository = new EventRepository();
            UserRepository = new UserRepository();
            GetEvents();
            meldTil = new Command<Event>(MeldTil);
            profil = new Command(Profil);
            home = new Command(Home);
        }
        private async void GetEvents()
        {
            string userId = await SecureStorage.Default.GetAsync("userId");
            User = await UserRepository.GetUserAsync(Convert.ToInt32(userId));
            UserEvent = await EventRepository.GetEventToUserAsync(User.Id);
            OnPropChanged(nameof(User));
            Location location = await Geolocation.Default.GetLocationAsync();
            Events = new ObservableCollection<Event>();
            AllEvents = await EventRepository.GetFromUserInteretsAsync(1, User.Id, location.Latitude, location.Longitude);
            for (int i = 0; i < AllEvents.Count; i++)
            {
                Events.Add(AllEvents[i]);
                Events[i].EventInfo.Distance = GetDistance(location.Latitude, location.Longitude, Events[i].EventInfo.CoordinateX, Events[i].EventInfo.CoordinateY);
                if (UserEvent.Any(x => x.Id == AllEvents[i].Id))
                {
                    Events[i].chosen = true;
                }
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
            if (choseEvent.chosen == false)
            {
                choseEvent.chosen = true;
                EventRepository.AddVoluntaryToEvent(User.Id, choseEvent.Id);
            }
            else
            {
                choseEvent.chosen = false;
                EventRepository.RemoveVoluntaryFromEvent(User.Id, choseEvent.Id);
            }
        }
        private async void Profil()
        {
            await Shell.Current.GoToAsync("//Profile");
        }
        private async void Home()
        {
            await Shell.Current.GoToAsync("//Events");
        }
    }
}
