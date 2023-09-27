using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    public class TaskRepositorie : ITaskRepositorie
    {
        private readonly TaskSystemDbContext _dbContext;
        public TaskRepositorie(TaskSystemDbContext taskSystemDbContext)
        {
            _dbContext = taskSystemDbContext;
        }
        public async Task<TaskModel> AddTask(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<bool> DeleteTask(int id)
        {
            TaskModel taskForId = await SearchForId(id);

            if (taskForId == null)
            {
                throw new Exception($"A tarefa para o ID: {id} não foi encontrado.");
            }

            _dbContext.Tasks.Remove(taskForId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<TaskModel>> GetTasks()
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<TaskModel> SearchForId(int id)
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskModel> UpdateTask(TaskModel task, int id)
        {
            TaskModel taskForId = await SearchForId(id);

            if (taskForId == null)
            {
                throw new Exception($"A tarefa para o ID: {id} não foi encontrado.");
            }

            taskForId.Name = task.Name;
            taskForId.Status = task.Status;
            taskForId.UserId = task.UserId;
            taskForId.Description = task.Description;

            _dbContext.Tasks.Update(taskForId);
            await _dbContext.SaveChangesAsync();

            return taskForId;
        }
    }
}
