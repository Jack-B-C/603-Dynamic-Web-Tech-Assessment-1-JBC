using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _603_Dynamic_Web_Tech_Assessment_1___JBC.Data;
using _603_Dynamic_Web_Tech_Assessment_1___JBC.Models;

namespace _603_Dynamic_Web_Tech_Assessment_1___JBC.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly _603_Dynamic_Web_Tech_Assessment_1___JBC.Data.ApplicationDbContext _context;

        public DetailsModel(_603_Dynamic_Web_Tech_Assessment_1___JBC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; } = default!;

        public List<Cast> CastMembers { get; set; } = new();
        public string? PosterUrl {get; set;}

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();

            }

            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (movie is not null)
            {
                Movie = movie;

                // Load cast members for this movie
                CastMembers = await _context.Casts
                    .Where(c => c.MovieId == id)
                    .ToListAsync();


                // Fetch poster from OMDb
                var apiKey = "5262be1"; // Or get from configuration
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(
                    $"https://www.omdbapi.com/?t={Uri.EscapeDataString(Movie.Title ?? "")}&apikey={apiKey}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(json);
                    if (doc.RootElement.TryGetProperty("Poster", out var posterProp))
                    {
                        PosterUrl = posterProp.GetString();
                    }
                }

                return Page();
            }

            return NotFound();
        }
    }
}
