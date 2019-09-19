using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using Microsoft.AspNetCore.Cors;

namespace WebApi.Controllers
{
  [Authorize]
    [ApiController]
    [Route("api")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
       // [EnableCors("_MedicosoftOrigins")]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet]
       // [EnableCors("_MedicosoftOrigins")]
        public IActionResult GetAll()
        {   
            
            var users =  _userService.GetAll();
            return Ok(users);
        }
    }
}