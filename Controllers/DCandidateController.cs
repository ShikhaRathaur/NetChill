using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netchill.Model;
using netchill.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Cors;

namespace netchill.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class DCandidateController : Controller
    {

        private readonly DonationDBContext _context;
        private readonly UserManager<IdentityUser> _userInManager;

        public DCandidateController(DonationDBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userInManager = userManager;

        }



        // GET: api/DCandidate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DCandidate>>> GetDCandidates()
        {
            return await _context.DCandidates.ToListAsync();
        }

        // GET: api/DCandidate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DCandidate>> GetDCandidate(int id)
        {
            var dCandidate = await _context.DCandidates.FindAsync(id);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/DCandidate/5

        [HttpPut("{id}")]
        public bool PutDCandidate(int id, DCandidate dCandidate)
        {
            dCandidate.movieid = id;

            if (_context.DCandidates.Any(o => o.movieid == dCandidate.movieid && o.username == dCandidate.username))
            {
             return true;
            

            }
            else
            {
             return false;

            }

    
        }

        // POST: api/DCandidate

        [HttpPost]
        [AllowAnonymous]

        public async Task<ActionResult<DCandidate>> PostDCandidate(DCandidate dCandidate)
        {
            String username = User.Identity.Name;

            dCandidate.username = username;

            _context.DCandidates.Add(dCandidate);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = dCandidate.id }, dCandidate);
        }

        // DELETE: api/DCandidate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DCandidate>> DeleteDCandidate(int id)
        {
            var dCandidate = await _context.DCandidates.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.DCandidates.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return dCandidate;
        }

        private bool DCandidateExists(int id)
        {
            return _context.DCandidates.Any(e => e.id == id);
        }

    }
}
