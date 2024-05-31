using FrontendModels;
using GoogleMaps.LocationServices;
using MauiRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Location = Microsoft.Maui.Devices.Sensors.Location;

namespace FrivilligApp.ViewModels
{
    [QueryProperty(nameof(EventId), "eventId")]
    public class AddEventViewModel : BaseViewModels
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        private int _eventId;
        public int EventId
        {
            get => _eventId;
            set => _eventId = value;
        }
        public ICommand addEvent {  get; set; }
        EventRepository EventRepository { get; set; }
        SkillsRepository SkillsRepository { get; set; }
        InterestsRepository InterestsRepository { get; set; }
        UserRepository UserRepository { get; set; }
        public User User { get; set; }
        public List<Skills> SkillsList { get; set; }
        public ObservableCollection<object> SelectedSkills { get; set; } = new();
        public List<Interests> InterestsList { get; set; }
        public ObservableCollection<object> SelectedInterests { get; set; } = new();
        public AddEventViewModel() 
        {
            EventRepository = new EventRepository();
            SkillsRepository = new SkillsRepository();
            InterestsRepository = new InterestsRepository();
            UserRepository = new UserRepository();
            addEvent = new Command(CreateEvent);
            Load();
            GetSkills();
            GetInterests();
        }
        public async void Load()
        {
            User = await UserRepository.GetUserAsync(Convert.ToInt32(await SecureStorage.Default.GetAsync("userId")));
            OnPropChanged(nameof(User));
        }
        public async void GetSkills()
        {
            SkillsList = await SkillsRepository.GetAllAsync();
            OnPropChanged(nameof(SkillsList)); 
        }
        public async void GetInterests()
        {
            InterestsList = await InterestsRepository.GetAllAsync();
            OnPropChanged(nameof(InterestsList));
        }
        private async void CreateEvent()
        {
            IEnumerable<Location> locations = await Geocoding.Default.GetLocationsAsync(Address);

            Location location = locations?.FirstOrDefault();
            Event events = new Event
            {
                OwnerId = User.Id,
                Owner = User,
                Title = Title,
                Description = Description,
                ImageUrl = ImageUrl,
                WantedVolunteers = 10,
                EventInfo = new EventInfo
                {
                    Address = Address,
                    CoordinateX = location.Latitude,
                    CoordinateY = location.Longitude,
                    Skills = SelectedSkills.OfType<Skills>().ToList(),
                    Interests = SelectedInterests.OfType<Interests>().ToList()
                }
            };
            EventRepository.CreateAsync(events);
            await Shell.Current.GoToAsync("//Events");
        }
    }
}
