using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using netchill.Model;
using Microsoft.AspNetCore.Authorization;

namespace netchill.Controllers
{
    [Authorize]

    [ApiController]

    public class WeatherForecastController : ControllerBase
    {

        private readonly DonationDBContext _db;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DonationDBContext db)
        {
            _logger = logger;
            _db = db;

        }

        [HttpGet]
        [Route("[controller]")]

        public IEnumerable<SuperuserEvent> Get()
        {

            IEnumerable<SuperuserEvent> objList = _db.SuperuserEvents;

            var rng = new Random();
            return objList.ToArray();
        }



        [HttpGet]
        [Route("api/[controller]")]

        public String Get_Username()
        {

            String username = User.Identity.Name;

            return username;



        }
    }
}
