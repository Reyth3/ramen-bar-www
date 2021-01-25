using BC.Server.Models.DB;
using BC.Shared;
using BC.Shared.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        private async Task AuthenticateUser(UserProfile match)
        {
            if (match != null)
            {
                var claim = new Claim(ClaimTypes.Name, match.EmailAddress);

                var identity = new ClaimsIdentity(new Claim[] { claim }, "ServerAuth");
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserProfileVM>> LogInUser([FromBody]LogInVM logIn)
        {
            // TODO: Make this actually secure
            var match = _context.UserProfiles.FirstOrDefault(o => o.EmailAddress == logIn.Email && o.Password == logIn.Password);
            await AuthenticateUser(match);
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
                user = _context.UserProfiles.Include(o => o.PostedAnnouncements).Include(o => o.Reservations).FirstOrDefault(o => o.EmailAddress == User.FindFirstValue(ClaimTypes.Name));
            }
            return user == null ? new UserProfileVM() : user;
        }

        [HttpGet("logout")]
        public async Task<ActionResult> LogOutUser()
        {
            await HttpContext.SignOutAsync();
            return new OkResult();
        }

        [HttpPost("register")]
        public async Task<ActionResult> PostRegisterNewUser([FromBody]RegisterVM vm)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return new ForbidResult();
            UserProfile user = vm;
            var match = _context.UserProfiles.Where(o => o.EmailAddress == user.EmailAddress).FirstOrDefault();
            if (match != null)
                return new ForbidResult();
            _context.UserProfiles.Add(user);
            await _context.SaveChangesAsync();
            await AuthenticateUser(user);
            return new OkResult();
        }
    }
}
