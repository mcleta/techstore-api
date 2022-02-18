using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechStore.Models;
using TechStore.Services;

namespace TechStore.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly TSServices _tsServices;

        public UserController(TSServices tsServices) =>
            _tsServices = tsServices;

        [HttpGet]
        public async Task<List<User>> GetUsers() =>
            await _tsServices.GetAllUsersAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _tsServices.GetOneUserAsync(id);

            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> PostUser(User newUser)
        {
            await _tsServices.AddUser(newUser);

            return Ok(newUser);
        }
    }
}
