using System;
using System.ComponentModel.DataAnnotations;

public class Borrowing
{
    [Key]
    public int BorrowingId { get; set; }

    [Required]
    public int BookId { get; set; }

    [Required]
    public int ReaderId { get; set; }

    [Required]
    public DateTime BorrowDate { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    public DateTime? ReturnDate { get; set; }
}
