using BC.Server.Models.DB;
using BC.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BC.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<UserController> _logger;

        public UserController(DataContext context, ILogger<UserController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserProfileVM>> LogInUser([FromBody]LogInVM logIn)
        {
            // TODO: Make this actually secure
            var match = _context.UserProfiles.FirstOrDefault(o => o.EmailAddress == logIn.Email && o.Password == logIn.Password);
            if(match != null)
            {
                var claim = new Claim(ClaimTypes.Name, match.EmailAddress);
                var identity = new ClaimsIdentity(new Claim[] { claim }, "ServerAuth");
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);
            }
            if (match == null)
                return new UnauthorizedResult();
            else return (UserProfileVM)match;
        }

        [HttpGet("current")]
        public async Task<ActionResult<UserProfileVM>> GetCurrentUser()
        {
            UserProfileVM user = null;
            if(User.Identity.IsAuthenticated)
            {
                user = _context.UserProfiles.FirstOrDefault(o => o.EmailAddress == User.FindFirstValue(ClaimTypes.Name));
            }
            return user == null ? new UserProfileVM() : user;
        }
    }
}
