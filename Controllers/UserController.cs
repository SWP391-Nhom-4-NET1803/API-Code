using DentalClinic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            else { return Ok(users);}
        }
    }
}
