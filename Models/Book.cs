using System.ComponentModel.DataAnnotations;


namespace Assignment2.Models
{

    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 10)]
        public required string ISBN { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Author { get; set; }

        public required string Category { get; set; }

        public required string Edition { get; set; }

        [Range(0, 1000)]
        public decimal Price { get; set; }

        public int PublicationYear { get; set; }

        public bool IsAvailable { get; set; } = true;
        public int Id { get; internal set; }
        public object? Genre { get; internal set; }
        public object? PublishedYear { get; internal set; }
    }
}