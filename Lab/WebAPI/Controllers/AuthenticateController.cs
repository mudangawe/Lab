using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI.Common.Interface.Authentication;
using WebAPI.Common.Model;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthenticateController(IUserService userService)
        {
            this._userService = userService;
        }
        // GET: api/<AuthenticateController>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate(UserLogin userLogin)
        {
            var authenticate = await _userService.Authenticate(userLogin);
            if (authenticate == null)
            {
                return Unauthorized();
            }
            return Ok(authenticate);
        }
    }
}
