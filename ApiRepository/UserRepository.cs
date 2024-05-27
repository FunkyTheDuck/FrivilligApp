using ApiDBlayer;
using FrontendModels;
using DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiRepository
{
    public class UserRepository
    {
        Database db;
        public UserRepository() 
        { 
            db = new Database();
        }
        public async Task<User> LogUserInAsync(string username, string hashedPassword)
        {
            DtoUser DtoUser = await db.Users.Include(x => x.UserCredebtials).FirstOrDefaultAsync(x => x.Username == username);
            User user;
            
            if (BCrypt.Net.BCrypt.Verify(hashedPassword, DtoUser.UserCredebtials.Password))
            {
                user = new User
                {
                    Id = DtoUser.Id,
                    EventId = DtoUser.EventId,
                    IsVoluntary = DtoUser.IsVoluntary,
                    Username = DtoUser.Username,
                    UserCredebtialsId = DtoUser.UserCredebtialsId,
                    UserCredebtials = new UserCredentials { Id = DtoUser.UserCredebtialsId, Password = DtoUser.UserCredebtials.Password },
                    UserInfoId = DtoUser.UserInfoId,
                    UserInfo = new UserInfo { Id = DtoUser.UserInfoId}
                };
            }
            else
            {
                return null;
            }
            return user;
        }
        public async Task<User> GetUserAsync(int userId)
        {
            DtoUser dtoUser = await db.Users.Include(x => x.UserInfo).Include(x => x.UserCredebtials).FirstOrDefaultAsync(x => x.Id == userId);
            User user = new User
            {
                Id = dtoUser.Id,
                EventId = dtoUser.EventId,
                Events = new(),
                UserCredebtialsId = dtoUser.UserCredebtialsId,
                UserCredebtials = new UserCredentials {Id = dtoUser.UserCredebtials.Id, Password = dtoUser.UserCredebtials.Password },
                IsVoluntary = dtoUser.IsVoluntary,
                Username = dtoUser.Username,
                UserInfoId = dtoUser.UserInfoId,
                UserInfo = new UserInfo { Id = dtoUser.UserInfo.Id, Skills = new(), interests = new()}
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
                            Skills skill = new Skills
                            {
                                Id = events.EventInfo.Skills[j].Id,
                                Skill = events.EventInfo.Skills[j].Skill
                            };
                            user.Events[i].EventInfo.Skills.Add(skill);
                        }
                    }
                    if (events.EventInfo.Interests != null)
                    {
                        for (int j = 0; j < events.EventInfo.Interests.Count; j++)
                        {
                            Interests interest = new Interests
                            {
                                Id = events.EventInfo.Interests[j].Id,
                                Interest = events.EventInfo.Interests[j].Interest
                            };
                            user.Events[i].EventInfo.Interests.Add(interest);
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
                        Id = user.UserInfo.Skills[i].Id,
                        Skill = user.UserInfo.Skills[i].Skill
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
                        Id = user.UserInfo.interests[i].Id,
                        Interest = user.UserInfo.interests[i].Interest
                    };
                    user.UserInfo.interests.Add(interest);
                }
            }
            return user;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            if (user != null)
            {
                DtoUser dtoUser = new DtoUser
                {
                    Id = user.Id,
                    EventId = user.EventId,
                    IsVoluntary = user.IsVoluntary,
                    Username = user.Username,
                    UserCredebtialsId = user.UserCredebtialsId,
                    UserCredebtials = new DtoUserCredentials { Id = user.UserCredebtialsId, Password = user.UserCredebtials.Password},
                    UserInfoId = user.UserInfoId,
                    UserInfo = new DtoUserInfo {Id = user.UserInfoId, LocationX = user.UserInfo.LocationX, LocationY = user.UserInfo.LocationY}
                };
                await db.Users.AddAsync(dtoUser);
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            DtoUser dtoUser = await db.Users.FirstOrDefaultAsync(e => e.Id == userId);
            db.Users.Remove(dtoUser);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            DtoUser dtoUser = new DtoUser
            {
                Id = user.Id,
                EventId = user.EventId,
                Events = new(),
                IsVoluntary = user.IsVoluntary,
                UserCredebtialsId = user.UserCredebtialsId,
                UserCredebtials = new DtoUserCredentials {Id = user.UserCredebtials.Id, Password = user.UserCredebtials.Password },
                Username = user.Username,
                UserInfoId = user.UserInfoId,
                UserInfo = new DtoUserInfo { Id = user.UserInfo.Id, Skills = new(), Interests = new() }
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
            db.Users.Update(dtoUser);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
