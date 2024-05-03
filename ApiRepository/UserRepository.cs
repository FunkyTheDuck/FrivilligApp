using ApiDBlayer;
using BackendModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository
{
    public class UserRepository
    {
        Database db;
        public UserRepository() 
        { 
            db = new Database();
        }
        public async Task<DtoUser> LogUserIn(string username, string hashedPassword)
        {
            DtoUser user = new DtoUser();
            return user;
        }

        public async Task<bool> CreateUser(DtoUser user)
        {
            return true;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            return true;
        }

        public async Task<bool> UpdateUser(DtoUser user)
        {
            return true;
        }
    }
}
