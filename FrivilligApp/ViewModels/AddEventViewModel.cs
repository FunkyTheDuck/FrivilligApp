using FrontendModels;
using MauiRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FrivilligApp.ViewModels
{
    public class AddEventViewModel : BaseViewModels
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }

        public ICommand addEvent {  get; set; }
        EventRepository EventRepository { get; set; }
        SkillsRepository SkillsRepository { get; set; }
        InterestsRepository InterestsRepository { get; set; }
        public List<Skills> SkillsList { get; set; }
        public ObservableCollection<object> SelectedSkills { get; set; } = new();
        public List<Interests> InterestsList { get; set; }
        public ObservableCollection<object> SelectedInterests { get; set; } = new();
        public AddEventViewModel() 
        {
            EventRepository = new EventRepository();
            SkillsRepository = new SkillsRepository();
            InterestsRepository = new InterestsRepository();
            addEvent = new Command(CreateEvent);
            GetSkills();
            GetInterests();
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
            //List<Skills> newSkills = new List<Skills>();
            //foreach (Skills item in SelectedSkills) 
            //{
            //    Skills newSkill = new Skills
            //    {
            //        Id = item.Id,
            //        Skill = item.Skill,
            //    };
            //    newSkills.Add(newSkill);
            //}
            //List<Interests> newInterests = new List<Interests>();
            //foreach (Interests item in SelectedInterests)
            //{
            //    Interests newInterest = new Interests
            //    {
            //        Id = item.Id,
            //        Interest = item.Interest,
            //    };
            //    newInterests.Add(newInterest);
            //}
            Event events = new Event
            {
                OwnerId = 1,
                Title = Title,
                Description = Description,
                ImageUrl = ImageUrl,
                WantedVolunteers = 10,
                EventInfo = new EventInfo
                {
                    Address = Address,
                    Skills = SelectedSkills.OfType<Skills>().ToList(),
                    Interests = SelectedInterests.OfType<Interests>().ToList()
                }
            };
            EventRepository.CreateAsync(events);
        }
    }
}
