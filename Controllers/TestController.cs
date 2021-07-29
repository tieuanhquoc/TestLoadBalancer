using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestLoadBalancer.Data;

namespace TestLoadBalancer.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly DataBaseContext _context;
        private readonly ILogger _logger;


        public TestController(DataBaseContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<TestController>();
        }

        [HttpGet("test")]
        public Task<List<Entity>> Get()
        {
            var routeName = Url.RouteUrl(RouteData.Values);
            var ip = HttpContext.Connection.RemoteIpAddress;
            _logger.LogInformation($"TIME: {DateTime.Now.ConvertToUnixTime()} - ROUTE {routeName} - IP: {ip}");
            return _context.Entities.Select(x => x).ToListAsync();
        }
    }
}