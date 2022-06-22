using netchill.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netchill.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace netchill.Controllers
{
    [Authorize]
  //  [ApiController]
//[Route("Ui/[controller]")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DonationDBContext _db;

        public HomeController(ILogger<HomeController> logger, DonationDBContext db)
        {
            _logger = logger;
            _db = db;

        }



        public IActionResult Index()
        {


            //IEnumerable<DCandidate> objList = _db.DCandidates;
            // return View(objList);
              return LocalRedirect("~/Login");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
