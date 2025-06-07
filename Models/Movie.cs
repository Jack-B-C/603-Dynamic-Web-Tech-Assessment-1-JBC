using System.ComponentModel.DataAnnotations;

namespace _603_Dynamic_Web_Tech_Assessment_1___JBC.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string? Title { get; set; } 
        public DateTime? ReleaseDate { get; set; }
        public string? Overview { get; set; }
        public string? Genre { get; set; }
        [Display(Name = "Budget")]
        public decimal? Price { get; set; }

    }
}
