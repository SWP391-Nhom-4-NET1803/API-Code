using DentalClinic.Interfaces;
using DentalClinic.Models;
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

        [HttpPost("login")]
        public IActionResult Login(String email, string password)
        {
            var user = _userRepository.GetUserByEmailAndPassword(email, password);
            if (user == null) { return NotFound(); }
            else { return Ok(user); }
        }

        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if (_userRepository.GetUsers().Any(u => u.Email == newUser.Email))
            {
                return BadRequest("Email already in use.");
            }

            var registeredUser = _userRepository.RegisterUser(newUser);

            if (registeredUser == null)
            {
                return BadRequest("Registration failed.");
            }

            return Ok(registeredUser);
        }
    }
}
