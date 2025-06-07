using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _603_Dynamic_Web_Tech_Assessment_1___JBC.Data;
using _603_Dynamic_Web_Tech_Assessment_1___JBC.Models;

namespace _603_Dynamic_Web_Tech_Assessment_1___JBC.Pages.Casts
{
    public class DetailsModel : PageModel
    {
        private readonly _603_Dynamic_Web_Tech_Assessment_1___JBC.Data.ApplicationDbContext _context;

        public DetailsModel(_603_Dynamic_Web_Tech_Assessment_1___JBC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Cast Cast { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cast = await _context.Casts
                .Include(c => c.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Cast == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
