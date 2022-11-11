using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorApp2Server.Controllers;

namespace BlazorApp2Server.Data
{
    public class BlazorApp2ServerContext : DbContext
    {
        public BlazorApp2ServerContext (DbContextOptions<BlazorApp2ServerContext> options)
            : base(options)
        {
        }

        public DbSet<BlazorApp2Server.Controllers.Feature> Feature { get; set; } = default!;
    }
}
