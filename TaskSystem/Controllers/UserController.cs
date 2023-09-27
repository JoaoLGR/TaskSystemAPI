using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositorie _userRepositorie;
         public UserController(IUserRepositorie userRepositorie) 
        { 
            _userRepositorie = userRepositorie;
        }
        [HttpGet]
        public async Task<ActionResult <List<UserModel>>> SearchAllUsers()
        {
            List<UserModel> users = await _userRepositorie.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> SearchForId(int id)
        {
            UserModel user = await _userRepositorie.SearchForId(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> RegisterUser([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepositorie.AddUser(userModel);
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRepositorie.UpdateUser(userModel, id);
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int id)
        {
            bool isDeleted = await _userRepositorie.DeleteUser(id);
            return Ok(isDeleted);
        }
    }
}
