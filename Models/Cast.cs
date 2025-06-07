using System.ComponentModel.DataAnnotations;

namespace _603_Dynamic_Web_Tech_Assessment_1___JBC.Models
{
    public class Cast
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ScreenName { get; set; }
        [Display(Name = "Movie")]
        public Guid? MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}