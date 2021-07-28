using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestLoadBalancer.Data;

namespace TestLoadBalancer.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public TestController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet("test")]
        public Task<List<Entity>> Get()
        {
            return _context.Entities.Select(x => x).ToListAsync();
        }
    }
}