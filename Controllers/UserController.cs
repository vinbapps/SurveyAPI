using SurveyAPI.Models;
using SurveyAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>>PostUser([FromBody] User user)
        {
            var newUser = await _userRepository.Create(user);
            return CreatedAtAction(nameof(GetUsers), new { id = newUser.Id }, newUser);
        }

        [HttpPut]
        public async Task<ActionResult> PutUser(int id, [FromBody] User user)
        {
            if(id != user.Id)
            {
                return BadRequest();
            }

            await _userRepository.UpdateUser(user);

            return NoContent();


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser (int id)
        {   
            var userToDelete = await _userRepository.GetUser(id);
            if (userToDelete == null)
                return NotFound();

            await _userRepository.DeleteUser(userToDelete.Id);
            return NoContent();
        }
    }
}
