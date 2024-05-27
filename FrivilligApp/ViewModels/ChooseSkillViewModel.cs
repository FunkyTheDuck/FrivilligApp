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
        public ObservableCollection<object> SelectedSkills { get; set; } = new();
        public List<Interests> InterestsList { get; set; }
        public ObservableCollection<object> SelectedInterests { get; set; } = new();
        public Command save {  get; set; }
        public ChooseSkillViewModel()
        {
            SkillsRepository = new SkillsRepository();
            InterestsRepository = new InterestsRepository();
            UserRepository = new UserRepository();
            save = new Command(Save);
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
        public async void Save()
        {
            string userId = await SecureStorage.Default.GetAsync("userId");
            User user = await UserRepository.GetUserAsync(Convert.ToInt32(userId));
            List<Skills> newSkill = SelectedSkills.OfType<Skills>().ToList();
            List<Interests> newInterest = SelectedInterests.OfType<Interests>().ToList();

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
