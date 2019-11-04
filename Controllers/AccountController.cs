using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _as;
        public AccountController(AccountService accService)
        {
            _as = accService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register([FromBody] UserRegistration creds)
        {
            try
            {
                User user = _as.Register(creds);
                if (user == null) { Unauthorized("Invalid Credentials"); }
                user.SetClaims();
                await HttpContext.SignInAsync(user._principal);
                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login([FromBody] UserSignIn creds)
        {
            try
            {
                User user = _as.SignIn(creds);
                user.SetClaims();
                await HttpContext.SignInAsync(user._principal);
                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }

        [Authorize]
        [HttpDelete("Logout")]
        public async Task<ActionResult<bool>> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync();
                return Ok(true);
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }

        [Authorize] // Only Authenticated users will be allowed into this method
        [HttpGet("Authenticate")]
        public async Task<ActionResult<User>> Authenticate()
        {
            try
            {
                //NOTE THIS IS HOW YOU GET THE ID of the currently logged in user
                var id = HttpContext.User.FindFirstValue("Id");
                var user = _as.GetUserById(id);
                return Ok(user);
            }
            catch (Exception e)
            {
                await HttpContext.SignOutAsync();
                return Unauthorized(e.Message);
            }
        }
    }
}