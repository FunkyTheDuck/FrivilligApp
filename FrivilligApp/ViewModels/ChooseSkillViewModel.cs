using FrontendModels;
using MauiRepository;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrivilligApp.ViewModels
{
    public class ChooseSkillViewModel : BaseViewModels
    {
        SkillsRepository SkillsRepository { get; set; }
        InterestsRepository InterestsRepository { get; set; }
        UserRepository UserRepository { get; set; }
        public List<Skills> SkillsList { get; set; }
        public ObservableCollection<object> selectedSkills { get; set; } 
        public ObservableCollection<object> SelectedSkills
        {
            get
            {
                return selectedSkills;
            }
            set
            {
                if (selectedSkills != value)
                {
                    selectedSkills = value;
                }
            }
        }
        public List<Interests> InterestsList { get; set; }
        public ObservableCollection<object> selectedInterests { get; set; }
        public ObservableCollection<object> SelectedInterests
        {
            get
            {
                return selectedInterests;
            }
            set
            {
                if (selectedInterests != value)
                {
                    selectedInterests = value;
                }
            }
        }
        public User user { get; set; }
        public Command save {  get; set; }
        public ChooseSkillViewModel()
        {
            SkillsRepository = new SkillsRepository();
            InterestsRepository = new InterestsRepository();
            UserRepository = new UserRepository();
            save = new Command(Save);
            GetSkills();
        }
        public async void GetSkills()
        {
            string userId = await SecureStorage.Default.GetAsync("userId");
            user = await UserRepository.GetUserAsync(Convert.ToInt32(userId));
            OnPropChanged(nameof(user));
            SkillsList = await SkillsRepository.GetAllAsync();
            List<Skills> oldSkills = new List<Skills>();
            for (int i = 0; i < SkillsList.Count; i++)
            {
                if (user.UserInfo.Skills.Any(x => x.Skill == SkillsList[i].Skill))
                {
                    oldSkills.Add(SkillsList[i]);
                }
            }
            SelectedSkills = new ObservableCollection<object>(oldSkills);
            OnPropChanged(nameof(SkillsList));
            OnPropChanged(nameof(SelectedSkills));
            InterestsList = await InterestsRepository.GetAllAsync();
            List<Interests> oldInterests = new List<Interests>();
            for (int i = 0; i < InterestsList.Count; i++)
            {
                if (user.UserInfo.interests.Any(x => x.Interest == InterestsList[i].Interest))
                {
                    oldInterests.Add(InterestsList[i]);
                }
            }
            SelectedInterests = new ObservableCollection<object>(oldInterests);
            OnPropChanged(nameof(InterestsList));
            OnPropChanged(nameof(SelectedInterests));
        }
        public async void Save()
        {
            List<Skills> newSkill = SelectedSkills.OfType<Skills>().ToList();
            List<Interests> newInterest = SelectedInterests.OfType<Interests>().ToList();
            user.UserInfo.Skills.Clear();
            user.UserInfo.interests.Clear();
            for (int i = 0; i < newSkill.Count; i++)
            {
                user.UserInfo.Skills.Add(newSkill[i]);
            }
            for (int i = 0; i < newInterest.Count; i++)
            {
                user.UserInfo.interests.Add(newInterest[i]);
            }
            if (await UserRepository.UpdateUserAsync(user))
            {
                await Shell.Current.GoToAsync("//Events");
            }

        }
    }
}
