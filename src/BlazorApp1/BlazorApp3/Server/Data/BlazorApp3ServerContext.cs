using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorApp3.Shared;

namespace BlazorApp3.Server.Data
{
    public class BlazorApp3ServerContext : DbContext
    {
        public BlazorApp3ServerContext (DbContextOptions<BlazorApp3ServerContext> options)
            : base(options)
        {
        }

        public DbSet<BlazorApp3.Shared.Student> Student { get; set; } = default!;
    }
}
