using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspHosted.Shared;

namespace AspHosted.Server.Data
{
    public class AspHostedServerContext : DbContext
    {
        public AspHostedServerContext (DbContextOptions<AspHostedServerContext> options)
            : base(options)
        {
        }

        public DbSet<AspHosted.Shared.Student> Student { get; set; } = default!;
    }
}
