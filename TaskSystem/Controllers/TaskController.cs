using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepositorie _taskRepositorie;
         public TaskController(ITaskRepositorie taskRepositorie) 
        { 
            _taskRepositorie = taskRepositorie;
        }
        [HttpGet]
        public async Task<ActionResult <List<TaskModel>>> SearchAllTask()
        {
            List<TaskModel> tasks = await _taskRepositorie.GetTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TaskModel>>> SearchForId(int id)
        {
            TaskModel task = await _taskRepositorie.SearchForId(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> RegisterTask([FromBody] TaskModel taskModel)
        {
            TaskModel task = await _taskRepositorie.AddTask(taskModel);
            return Ok(task);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> UpdateTask([FromBody] TaskModel taskModel, int id)
        {
            taskModel.Id = id;
            TaskModel task = await _taskRepositorie.UpdateTask(taskModel, id);
            return Ok(task);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> DeleteTask(int id)
        {
            bool isDeleted = await _taskRepositorie.DeleteTask(id);
            return Ok(isDeleted);
        }
    }
}
