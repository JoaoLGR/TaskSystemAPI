using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    public class UserRepositorie : IUserRepositorie
    {
        private readonly TaskSystemDbContext _dbContext;
        public UserRepositorie(TaskSystemDbContext taskSystemDbContext) 
        {
            _dbContext = taskSystemDbContext;
        }
        public async Task<List<UserModel>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<UserModel> SearchForId(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userForId = await SearchForId(id);

            if(userForId == null)
            {
                throw new Exception($"O usuário para o ID: {id} não foi encontrado.");
            }

            userForId.Name = user.Name;
            userForId.Email = user.Email;

            _dbContext.Users.Update(userForId);
            await _dbContext.SaveChangesAsync();

            return userForId;
        }
        public async Task<bool> DeleteUser(int id)
        {
            UserModel userForId = await SearchForId(id);

            if (userForId == null)
            {
                throw new Exception($"O usuário para o ID: {id} não foi encontrado.");
            }

            _dbContext.Users.Remove(userForId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        
    }
}
