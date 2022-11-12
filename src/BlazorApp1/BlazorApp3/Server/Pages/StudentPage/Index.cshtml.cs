using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlazorApp3.Server.Data;
using BlazorApp3.Shared;

namespace BlazorApp3.Server.Pages.StudentPage
{
    public class IndexModel : PageModel
    {
        private readonly BlazorApp3.Server.Data.BlazorApp3ServerContext _context;

        public IndexModel(BlazorApp3.Server.Data.BlazorApp3ServerContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Student != null)
            {
                Student = await _context.Student.ToListAsync();
            }
        }
    }
}
