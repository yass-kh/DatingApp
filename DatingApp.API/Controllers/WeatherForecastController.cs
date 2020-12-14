using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DataContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var list = await _context.WeatherForecasts.ToListAsync();
            return Ok(list);
        }


        [HttpGet("{id}")]
        public IActionResult GetBy(int id)
        {
            var item = _context.WeatherForecasts.FirstOrDefaultAsync(w=>w.id == id);
            return Ok(item);
        }
    }
}
