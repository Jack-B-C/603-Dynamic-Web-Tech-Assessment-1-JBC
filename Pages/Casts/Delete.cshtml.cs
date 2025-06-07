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
    public class DeleteModel : PageModel
    {
        private readonly _603_Dynamic_Web_Tech_Assessment_1___JBC.Data.ApplicationDbContext _context;

        public DeleteModel(_603_Dynamic_Web_Tech_Assessment_1___JBC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cast Cast { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cast = await _context.Casts.FirstOrDefaultAsync(m => m.Id == id);

            if (cast is not null)
            {
                Cast = cast;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cast = await _context.Casts.FindAsync(id);
            if (cast != null)
            {
                Cast = cast;
                _context.Casts.Remove(Cast);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
