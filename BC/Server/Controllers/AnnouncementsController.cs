using BC.Server.Models.DB;
using BC.Shared;
using BC.Shared.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<AnnouncementsController> _logger;

        public AnnouncementsController(DataContext context, ILogger<AnnouncementsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("recent/{count}")]
        public AnnouncementVM[] GetRecentAnnouncements(int count)
        {
            return _context.Announcements
                .Include(o => o.Author)
                .OrderByDescending(o => o.PostingDate)
                .Take(count)
                .Select(o => (AnnouncementVM)o)
                .ToArray();
        }

        [HttpGet("{id}")]
        public async Task<AnnouncementVM> GetArticleById(int id)
        {
            var item = await _context.Announcements.Include(o => o.Author).Where(o => o.AnnouncementId == id).FirstOrDefaultAsync();
            return item;
        }

        [HttpPost("new"), Authorize]
        public async Task<ActionResult> PostNewAnnouncement([FromBody]AnnouncementVM vm)
        {
            Announcement model = vm;
            var email = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var user = await _context.UserProfiles.FirstOrDefaultAsync(o => o.EmailAddress == email);
            if (user == null || !user.IsEditor)
                return new ForbidResult();
            model.PostingDate = DateTimeOffset.UtcNow;
            model.Preview = model.Text.Substring(0, 95);
            user.PostedAnnouncements.Add(model);
            await _context.SaveChangesAsync();
            return new OkResult();
        }
    }
}
