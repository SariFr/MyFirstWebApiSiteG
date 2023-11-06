using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories;

public class userRepository : IuserRepository
{
    private readonly WebElectricStoreContext _WebElectricStoreContext;


    public userRepository(WebElectricStoreContext WebElectricStoreContext)
    {
        _WebElectricStoreContext = WebElectricStoreContext;
    }

    public async Task<User> getUserByEmailAndPassword(string userName, string password)
    {

         var users= await _WebElectricStoreContext.Users.Where(user=>user.UserName== userName && user.Password==password).ToListAsync();
        if (users.Count() > 1)
            return null;
        return users.FirstOrDefault();

   
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
