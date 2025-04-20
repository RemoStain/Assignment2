using System.ComponentModel.DataAnnotations;

public class Book
{
    [Key]
    public int BookId { get; set; }

    [Required]
    [StringLength(13, MinimumLength = 10)]
    public string ISBN { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Author { get; set; }

    public string Category { get; set; }

    public string Edition { get; set; }

    [Range(0, 1000)]
    public decimal Price { get; set; }

    public int PublicationYear { get; set; }

    public bool IsAvailable { get; set; } = true;
}
