using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Repositories;
using System.Text.Json;

namespace Repository
{
    public class userRepository : IuserRepository
    {
        private readonly WebElectricStoreContext _WebElectricStoreContext;

        public userRepository(WebElectricStoreContext WebElectricStoreContext)
        {
            _WebElectricStoreContext = WebElectricStoreContext;
        }

        //private readonly string filePath = "../Users.txt";
        public async Task<User> getUserByEmailAndPassword(string userName, string password)
        {
            return await _WebElectricStoreContext.Users.Where(user => user.UserName == userName && user.Password == password).FirstOrDefaultAsync();
            
        }


        public async Task<User> getUserById(int id)
        { 
            return await _WebElectricStoreContext.Users.FindAsync(id);
        }

        public async Task<User> addUser(User user)
        {

            await _WebElectricStoreContext.Users.AddAsync(user);
            await _WebElectricStoreContext.SaveChangesAsync();

            return user;
        }


        public async Task updateUser(int id, User user)
        {
            _WebElectricStoreContext.Update(user);
            await _WebElectricStoreContext.SaveChangesAsync();
        }
    }
}