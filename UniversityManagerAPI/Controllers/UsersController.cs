using Microsoft.AspNetCore.Mvc;
using UniversityManagerAPI.Auth;
using UniversityManagerAPI.Data.Repository.Interfaces;
using UniversityManagerAPI.DTO;
using UniversityManagerAPI.Entities;

namespace UniversityManagerAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IJwtUtils jwtUtils;

        public UsersController(IUnitOfWork unitOfWork, IJwtUtils jwtUtils)
        {
            this.unitOfWork = unitOfWork;
            this.jwtUtils = jwtUtils;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] AutheticateRequest userDTO)
        {
            var user = unitOfWork.Users.GetByUsername(userDTO.Username);
            if(user == null || !BCrypt.Net.BCrypt.Verify(userDTO.Password, user.Password))
            {
                return BadRequest("Invalid Credentials");
            }
            var jwtToken = jwtUtils.GenerateJwtToken(user);
            return Ok(jwtToken);
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult Post([FromBody] UserCreateRequest user)
        {
            var newUser = new User()
            {
                Username = user.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
            };
            unitOfWork.Users.Add(newUser);
            unitOfWork.SaveChanges();
            return Ok(newUser);
        }

        [HttpPut("changepassword")]
        public ActionResult Put([FromBody] UserUpdateRequest user)
        {
            var contextUser = (int?)HttpContext.Items["User"];
            if (contextUser != null)
            {
                var updateUser = unitOfWork.Users.GetById(contextUser.Value);
                if (updateUser != null)
                {
                    updateUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    unitOfWork.Users.Update(updateUser);
                    unitOfWork.SaveChanges();
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
