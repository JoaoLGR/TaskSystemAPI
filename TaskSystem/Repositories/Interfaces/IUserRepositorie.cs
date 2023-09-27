using TaskSystem.Models;

namespace TaskSystem.Repositories.Interfaces
{
    public interface IUserRepositorie
    {
        Task<List<UserModel>> GetUsers();

        Task<UserModel> SearchForId(int id);

        Task<UserModel> AddUser(UserModel user);

        Task<UserModel> UpdateUser(UserModel user, int id);

        Task<bool> DeleteUser(int id);
    }
}
