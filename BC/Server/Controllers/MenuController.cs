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
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly ILogger<MenuController> _logger;
        private readonly DataContext _context;

        public MenuController(ILogger<MenuController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<MenuItemVM> Get()
        {
            var mi = _context.MenuItems.OrderBy(o => o.MenuItemId).ToList().Select(o => (MenuItemVM)o);
            return mi.ToList();
        }
    }
}
