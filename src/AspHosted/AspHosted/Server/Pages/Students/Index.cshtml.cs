using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspHosted.Server.Data;
using AspHosted.Shared;

namespace AspHosted.Server.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly AspHosted.Server.Data.AspHostedServerContext _context;

        public IndexModel(AspHosted.Server.Data.AspHostedServerContext context)
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
