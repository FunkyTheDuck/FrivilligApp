using BackendModels;
using FrontendModels;
using MauiDBlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MauiRepository
{
    public class UserRepository
    {
        DBAccess db;
        public UserRepository() 
        {
            db = new DBAccess();
        }
        public async Task<bool> CreateUser(User user)
        {
            if (user != null)
            {
                DtoUser dtoUser = new DtoUser
                {
                    Events = new(),
                    IsVoluntary = user.IsVoluntary,
                    Username = user.Username,
                    UserCredebtials = new DtoUserCredentials
                    {
                        Password = user.UserCredebtials.Password
                    },
                    UserInfo = new DtoUserInfo
                    {
                        Skills = new(),
                        Interests = new(),
                        LocationX = 0,
                        LocationY = 0,
                    }
                };
                return await db.CreateUserAsync(dtoUser);
            }
            return false;
        }
        public async Task<User> GetUserAsync(string username, string password)
        {
            DtoUser dtoUser = await db.GetUserAsync(username, password);
            User user = GetUser(dtoUser);
            return user;
        }
        public async Task<User> GetUserAsync(int userId)
        {
            DtoUser dtoUser = await db.GetUserAsync(userId);
            User user = GetUser(dtoUser);
            return user;
        }
        public User GetUser(DtoUser dtoUser)
        {
            User user = new User
            {
                Id = dtoUser.Id,
                EventId = dtoUser.EventId,
                Events = new(),
                UserCredebtialsId = dtoUser.UserCredebtialsId,
                UserCredebtials = new UserCredentials{Id = dtoUser.UserCredebtials.Id, Password = dtoUser.UserCredebtials.Password },
                IsVoluntary = dtoUser.IsVoluntary,
                Username = dtoUser.Username,
                UserInfoId = dtoUser.UserInfoId,
                UserInfo = new UserInfo { Id = dtoUser.UserInfoId, Skills = new(), interests = new() }
            };
            if (dtoUser.Events != null)
            {
                for (int i = 0; i < dtoUser.Events.Count; i++)
                {
                    Event events = new Event
                    {
                        Title = dtoUser.Events[i].Title,
                        Description = dtoUser.Events[i].Description,
                        ImageUrl = dtoUser.Events[i].ImageUrl,
                        WantedVolunteers = dtoUser.Events[i].WantedVolunteers,
                        EventInfo = new EventInfo
                        {
                            Address = dtoUser.Events[i].EventInfo.Address,
                            CoordinateX = dtoUser.Events[i].EventInfo.CoordinateX,
                            CoordinateY = dtoUser.Events[i].EventInfo.CoordinateY,
                            Skills = new(),
                            Interests = new()
                        },
                        OwnerId = dtoUser.Events[i].OwnerId
                    };
                    if (dtoUser.Events[i].EventInfo.Skills != null)
                    {
                        for (int j = 0; j < events.EventInfo.Skills.Count; j++)
                        {
                            DtoSkills skill = new DtoSkills
                            {
                                Id = events.EventInfo.Skills[j].Id,
                                Skill = events.EventInfo.Skills[j].Skill
                            };
                            dtoUser.Events[i].EventInfo.Skills.Add(skill);
                        }
                    }
                    if (events.EventInfo.Interests != null)
                    {
                        for (int j = 0; j < events.EventInfo.Interests.Count; j++)
                        {
                            DtoInterests interest = new DtoInterests
                            {
                                Id = events.EventInfo.Interests[j].Id,
                                Interest = events.EventInfo.Interests[j].Interest
                            };
                            dtoUser.Events[i].EventInfo.Interests.Add(interest);
                        }
                    }
                }
            }
            if (dtoUser.UserInfo.Skills != null)
            {
                for (int i = 0; i < dtoUser.UserInfo.Skills.Count; i++)
                {
                    Skills skill = new Skills
                    {
                        Id = dtoUser.UserInfo.Skills[i].Id,
                        Skill = dtoUser.UserInfo.Skills[i].Skill
                    };
                    user.UserInfo.Skills.Add(skill);
                }
            }

            if (dtoUser.UserInfo.Interests != null)
            {
                for (int i = 0; i < dtoUser.UserInfo.Interests.Count; i++)
                {
                    Interests interest = new Interests
                    {
                        Id = dtoUser.UserInfo.Interests[i].Id,
                        Interest = dtoUser.UserInfo.Interests[i].Interest
                    };
                    user.UserInfo.interests.Add(interest);
                }
            }
            return user;
        }
        public async Task<bool> UpdateUserAsync(User user)
        {
            if (user != null)
            {
                DtoUser dtoUser = new DtoUser
                {
                    Id = user.Id,
                    EventId = user.EventId,
                    Events = new(),
                    IsVoluntary = user.IsVoluntary,
                    UserCredebtialsId = user.UserCredebtialsId,
                    UserCredebtials = new DtoUserCredentials { Id = user.UserCredebtials.Id, Password = user.UserCredebtials.Password},
                    Username = user.Username,
                    UserInfoId = user.UserInfoId,
                    UserInfo = new DtoUserInfo { Id = user.UserInfoId, Skills = new(), Interests = new() }
                };
                if (user.Events != null)
                {
                    for (int i = 0; i < user.Events.Count; i++)
                    {
                        DtoEvent events = new DtoEvent
                        {
                            Title = user.Events[i].Title,
                            Description = user.Events[i].Description,
                            ImageUrl = user.Events[i].ImageUrl,
                            WantedVolunteers = user.Events[i].WantedVolunteers,
                            EventInfo = new DtoEventInfo
                            {
                                Address = user.Events[i].EventInfo.Address,
                                CoordinateX = user.Events[i].EventInfo.CoordinateX,
                                CoordinateY = user.Events[i].EventInfo.CoordinateY,
                                Skills = new(),
                                Interests = new()
                            },
                            OwnerId = user.Events[i].OwnerId
                        };
                        if (user.Events[i].EventInfo.Skills != null)
                        {
                            for (int j = 0; j < events.EventInfo.Skills.Count; j++)
                            {
                                DtoSkills skill = new DtoSkills
                                {
                                    Id = events.EventInfo.Skills[j].Id,
                                    Skill = events.EventInfo.Skills[j].Skill
                                };
                                dtoUser.Events[i].EventInfo.Skills.Add(skill);
                            }
                        }
                        if (events.EventInfo.Interests != null)
                        {
                            for (int j = 0; j < events.EventInfo.Interests.Count; j++)
                            {
                                DtoInterests interest = new DtoInterests
                                {
                                    Id = events.EventInfo.Interests[j].Id,
                                    Interest = events.EventInfo.Interests[j].Interest
                                };
                                dtoUser.Events[i].EventInfo.Interests.Add(interest);
                            }
                        }
                    }
                }
                if (user.UserInfo.Skills != null)
                {
                    for (int i = 0; i < user.UserInfo.Skills.Count; i++)
                    {
                        DtoSkills skill = new DtoSkills
                        {
                            Id = user.UserInfo.Skills[i].Id,
                            Skill = user.UserInfo.Skills[i].Skill
                        };
                        dtoUser.UserInfo.Skills.Add(skill);
                    }
                }

                if (user.UserInfo.interests != null)
                {
                    for (int i = 0; i < user.UserInfo.interests.Count; i++)
                    {
                        DtoInterests interest = new DtoInterests
                        {
                            Id = user.UserInfo.interests[i].Id,
                            Interest = user.UserInfo.interests[i].Interest
                        };
                        dtoUser.UserInfo.Interests.Add(interest);
                    }
                }
                return await db.UpdateUserAsync(dtoUser);
            }
            return false;
        }
    }
}
