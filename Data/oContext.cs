using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using o.Models;

namespace o.Data
{
    public class oContext : IdentityDbContext
    {
        public oContext (DbContextOptions<oContext> options)
            : base(options)
        {
        }

        public DbSet<o.Models.tarla> tarla { get; set; } = default!;

        public DbSet<o.Models.ilac> ilac { get; set; } = default!;

        public DbSet<o.Models.ekin> ekin { get; set; } = default!;
    }
}
