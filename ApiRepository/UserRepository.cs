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
            DtoUser DtoUser = await db.Users.FirstOrDefaultAsync(x => x.Username == username);
            User user;
            if (DtoUser.UserCredebtials.Password == hashedPassword)
            {
                user = new User
                {
                    Id = DtoUser.Id,
                    EventId = DtoUser.EventId,
                    IsVoluntary = DtoUser.IsVoluntary,
                    Username = DtoUser.Username,
                    UserCredebtialsId = DtoUser.UserCredebtialsId,
                    UserInfoId = DtoUser.UserInfoId,
                };
            }
            else
            {
                return null;
            }
            return user;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            DtoUser dtoUser = new DtoUser
            {
                Id = user.Id,
                EventId = user.EventId,
                IsVoluntary = user.IsVoluntary,
                Username = user.Username,
                UserCredebtialsId = user.UserCredebtialsId,
                UserInfoId = user.UserInfoId,
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
                IsVoluntary = user.IsVoluntary,
                Username = user.Username,
                UserCredebtialsId = user.UserCredebtialsId,
                UserInfoId = user.UserInfoId,
            };
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
