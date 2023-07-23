using System.ComponentModel.DataAnnotations;

namespace SmallLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int Published_Year { get; set; }
    }
}
