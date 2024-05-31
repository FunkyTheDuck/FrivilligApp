using BackendModels;
using BlazorDBlayer;
using FrontendModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRepository
{
    public class UserRepository : Encryption, IUserRepository
    {
        protected DBAccess db { get; set; }
        public UserRepository()
        {
            db = new DBAccess();
        }
        public async Task<User> LogUserInAsync(string username, string password)
        {
            DtoUser dtoUser;
            try
            {
                dtoUser = await db.LogUserInAsync(username, password);
            }
            catch
            {
                return null;
            }
            if (dtoUser != null)
            {
                return ConvertFromDto(dtoUser);
            }
            return null;
        }
        public async Task<bool> CreateUserAsync(string username, string password)
        {
            User user = new User
            {
                Username = username,
                UserCredebtials = new UserCredentials
                {
                    Password = HashPassword(password)
                },
                UserInfo = new UserInfo(),


            };
            DtoUser dtoUser = ConvertToDto(user);
            bool checkIfSucces;
            try
            {
                checkIfSucces = await db.CreateUserAsync(dtoUser);
            }
            catch
            {
                return false;
            }
            return checkIfSucces;
        }
        private User ConvertFromDto(DtoUser dtoUser)
        {
            User user = new User
            {
                Id = dtoUser.Id,
                IsVoluntary = dtoUser.IsVoluntary,
                Username = dtoUser.Username,
                UserCredebtialsId = dtoUser.UserCredebtialsId,
                UserCredebtials = new UserCredentials
                {
                    Id = dtoUser.UserCredebtials.Id,
                    Password = dtoUser.UserCredebtials.Password
                },
                UserInfoId = dtoUser.UserInfoId,
                UserInfo = new UserInfo
                {
                    Id = dtoUser.UserInfo.Id,
                    LocationX = dtoUser.UserInfo.LocationX,
                    LocationY = dtoUser.UserInfo.LocationY,
                }
            };
            if (dtoUser.UserInfo != null)
            {
                if (dtoUser.UserInfo.Interests != null)
                {
                    user.UserInfo.interests = new();
                    for (int i = 0; i < dtoUser.UserInfo.Interests.Count; i++)
                    {
                        Interests interests = new Interests
                        {
                            Id = dtoUser.UserInfo.Interests[i].Id,
                            Interest = dtoUser.UserInfo.Interests[i].Interest
                        };
                        user.UserInfo.interests.Add(interests);
                    }
                }
                if (dtoUser.UserInfo.Skills != null)
                {
                    user.UserInfo.Skills = new();
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
            }
            return user;
        }
        private DtoUser ConvertToDto(User user)
        {
            DtoUser dtoUser = new DtoUser
            {
                Id = user.Id,
                IsVoluntary = user.IsVoluntary,
                Username = user.Username,
                UserCredebtialsId = user.UserCredebtialsId,
                UserCredebtials = new DtoUserCredentials
                {
                    Id = user.UserCredebtials.Id,
                    Password = user.UserCredebtials.Password
                },
                UserInfoId = user.UserInfoId,
                UserInfo = new DtoUserInfo
                {
                    Id = user.UserInfo.Id,
                    LocationX = user.UserInfo.LocationX,
                    LocationY = user.UserInfo.LocationY,
                }
            };
            if (user.UserInfo != null)
            {
                if (user.UserInfo.interests != null)
                {
                    dtoUser.UserInfo.Interests = new();
                    for (int i = 0; i < user.UserInfo.interests.Count; i++)
                    {
                        DtoInterests interests = new DtoInterests
                        {
                            Id = user.UserInfo.interests[i].Id,
                            Interest = user.UserInfo.interests[i].Interest
                        };
                        dtoUser.UserInfo.Interests.Add(interests);
                    }
                }
                if (user.UserInfo.Skills != null)
                {
                    dtoUser.UserInfo.Skills = new();
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
            }
            return dtoUser;
        }
    }
}