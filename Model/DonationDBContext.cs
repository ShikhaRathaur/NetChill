using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace netchill.Model
{
    public class DonationDBContext : IdentityDbContext
    {
        public DonationDBContext(DbContextOptions<DonationDBContext> options) : base(options)
        {

        }
        public DbSet<SuperuserEvent> SuperuserEvents { get; set; }

        public DbSet<DCandidate> DCandidates { get; set; }
    }
}
