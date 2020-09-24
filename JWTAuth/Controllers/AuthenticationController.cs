using JWTAuth.Dtos;
using JWTAuth.models;
using JWTAuth.services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuth.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthenticationController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        public ActionResult<UserReadDto> Login([FromBody]UserCore model)
        {
            var user = _auth.VerifyUser(model.Email, model.Password);
            if (user == null)
            {
                return BadRequest("Email or PassWord Incorrect");
            }
            return Ok(user);
        }

        [HttpPost("signup")]
        public ActionResult<UserReadDto> Signup([FromBody]UserCore model)
        {
            var user = _auth.SignUpUser(model);
            if (user == null)
            {
                return BadRequest("Email Already Exist");
            }
            return Ok(user);
        }
    }
}