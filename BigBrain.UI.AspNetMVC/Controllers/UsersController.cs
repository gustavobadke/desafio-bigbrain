using BigBrain.ViewModels;
using BigBrain.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BigBrain.Controllers
{
    [Route("")]
    public class UsersController : Controller
    {
        private UserService service;

        public UsersController()
        {
            service = new UserService();
        }

        [HttpGet("")]
        public async Task<IActionResult> List([FromQuery] string searchName = "")
        {
            var users = await service.GetUsersAsync(searchName);

            return View(new UsersListViewModel
            {
                SearchName = searchName,
                Users = users
            });
        }
    }
}