using BC.Server.Models.DB;
using BC.Shared;
using BC.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BC.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoalsController : ControllerBase
    {
        private readonly ILogger<GoalsController> _logger;
        private readonly DataContext _context;

        public GoalsController(ILogger<GoalsController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<GoalInfo> Get()
        {
            var gi = _context.Goals.OrderBy(o => o.GoalId).ToList().Select(o => (GoalInfo)o);
            return gi.ToList();
        }

        [HttpPut("{gId}")]
        public async Task<string> UpdateGoal(int gId, [FromBody]Goal g)
        {
            return await Task.Run(() => g.ToString()); 
        }
    }
}
