using BigBrain.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BigBrain.Api.Controllers
{
    [Route("api/usuarios")]
    public class UsersController : ControllerBase
    {
        private UserService service;

        public UsersController()
        {
            service = new UserService();
        }

        [HttpGet("")]
        public async Task<IActionResult> List(string searchName = "")
        {
            var users = await service.GetUsersAsync(searchName);

            return Ok(users);
        }
    }
}