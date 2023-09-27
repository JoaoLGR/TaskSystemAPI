using TaskSystem.Models;

namespace TaskSystem.Repositories.Interfaces
{
    public interface ITaskRepositorie
    {
        Task<List<TaskModel>> GetTasks();

        Task<TaskModel> SearchForId(int id);

        Task<TaskModel> AddTask(TaskModel task);

        Task<TaskModel> UpdateTask(TaskModel task, int id);

        Task<bool> DeleteTask(int id);
    }
}
