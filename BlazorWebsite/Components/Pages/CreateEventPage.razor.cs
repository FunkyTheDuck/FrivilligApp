using BlazorRepository;
using FrontendModels;
using System.ComponentModel;

namespace BlazorWebsite.Components.Pages
{
    partial class CreateEventPage
    {
        protected EventRepository eventRepo { get; set; }
        protected SkillsRepository skillRepo { get; set; }
        protected InterestsRepository interestsRepo { get; set; }
        public Event CreatedEvent { get; set; }
        public List<Skills> AllSkills { get; set; }
        public List<Interests> AllInterests { get; set; }

        public bool errorHappend = false;
        public bool succesHappend = false;
        public string message = string.Empty;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                eventRepo = new EventRepository();
                skillRepo = new SkillsRepository();
                interestsRepo = new InterestsRepository();
                CreatedEvent = new Event();
                CreatedEvent.EventInfo = new EventInfo();
                CreatedEvent.EventInfo.Skills = new List<Skills>();
                CreatedEvent.EventInfo.Interests = new List<Interests>();
                AllSkills = await skillRepo.GetAllAsync();
                AllInterests = await interestsRepo.GetAllAsync();
                StateHasChanged();
            }
        }
        public async void HandleValidSubmitAsync()
        {
            //validate info
            if(await ValidateEventModelAsync(CreatedEvent))
            {
                bool checkIfSucces;
                try
                {
                    checkIfSucces = await eventRepo.CreateAsync(CreatedEvent);
                }
                catch
                {
                    checkIfSucces = false;
                }
                if (checkIfSucces)
                {
                    SuccesHappendAsync("Begivenheden er nu oprettet");
                    //model is valid and has been created
                    return;
                }
                ErrorHappendAsync("Begivenheden kunne ikke blive oprettet i databasen, vendt lidt og prøv igen");
                //model is valid but couldn't be created
                return;
            }
            ErrorHappendAsync("Oplysningerne om begivenheden er ugyldige");
            //model is not valid
        }
        public async Task ChangeSkillByIdAsync(int id)
        {
            Skills clickedSkill = AllSkills.FirstOrDefault(x => x.Id == id);
            if(!CreatedEvent.EventInfo.Skills.Contains(clickedSkill))
            {
                //add skill
                CreatedEvent.EventInfo.Skills.Add(clickedSkill);
            }
            else
            {
                //remove skill
                CreatedEvent.EventInfo.Skills.Remove(clickedSkill);
            }
        }
        public async Task ChangeInterestsByIdAsync(int id)
        {
            Interests clickedInterests = AllInterests.FirstOrDefault(x => x.Id == id);
            if (!CreatedEvent.EventInfo.Interests.Contains(clickedInterests))
            {
                //add skill
                CreatedEvent.EventInfo.Interests.Add(clickedInterests);
            }
            else
            {
                //remove skill
                CreatedEvent.EventInfo.Interests.Remove(clickedInterests);
            }
        }
        private async Task<bool> ValidateEventModelAsync(Event model)
        {
            if(string.IsNullOrEmpty(model.Title) || model.Title.Length < 3 && model.Title.Length > 51)
            {
                return false;
            }
            if(string.IsNullOrEmpty(model.Description) || model.Description.Length < 3 && model.Description.Length > 501)
            {
                return false;
            }
            if(string.IsNullOrEmpty(model.ImageUrl) || model.ImageUrl.Length > 101)
            {
                return false;
            }
            if(string.IsNullOrEmpty(model.EventInfo.Address) || model.EventInfo.Address.Length < 3 && model.EventInfo.Address.Length > 101)
            {
                return false;
            }
            return true;
        }
        private async Task ErrorHappendAsync(string message)
        {
            errorHappend = true;
            this.message = message;
            StateHasChanged();
            MessageTimerAsync();
        }
        private async Task SuccesHappendAsync(string message)
        {
            succesHappend = true;
            this.message = message;
            StateHasChanged();
            MessageTimerAsync();
        }
        private async Task MessageTimerAsync()
        {
            await Task.Delay(5000);
            succesHappend = false;
            errorHappend = false;
            StateHasChanged();
        }
    }
}