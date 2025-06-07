using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _603_Dynamic_Web_Tech_Assessment_1___JBC.Data;
using _603_Dynamic_Web_Tech_Assessment_1___JBC.Models;

namespace _603_Dynamic_Web_Tech_Assessment_1___JBC.Pages.Casts
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cast Cast { get; set; } = default!;

        public SelectList Movies { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            // Populate the dropdown with movie titles and IDs
            Movies = new SelectList(await _context.Movies.ToListAsync(), "Id", "Title");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Repopulate dropdown if validation fails
                Movies = new SelectList(await _context.Movies.ToListAsync(), "Id", "Title");
                return Page();
            }

            _context.Casts.Add(Cast);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
