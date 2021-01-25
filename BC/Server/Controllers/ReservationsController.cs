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
    [Authorize]
    public class ReservationsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<ReservationsController> _logger;

        public ReservationsController(DataContext context, ILogger<ReservationsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public ReservationVM[] GetAllReservations()
        {
            var email = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var user = _context.UserProfiles.Include(o => o.Reservations).FirstOrDefault(o => o.EmailAddress == email);
            return user.Reservations.OrderByDescending(o => o.ReservationTime).Select(o => (ReservationVM)o).ToArray();
        }

        [HttpPost("new")]
        public async Task<ActionResult<ReservationVM[]>> PostNewReservation([FromBody]ReservationVM vm)
        {
            Reservation model = vm;
            var email = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var user = _context.UserProfiles.Include(o => o.Reservations).FirstOrDefault(o => o.EmailAddress == email);
            user.Reservations.Add(model);
            await _context.SaveChangesAsync();
            return GetAllReservations();
        }
    }
}
