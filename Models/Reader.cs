using System.ComponentModel.DataAnnotations;

public class Reader
{
    [Key]
    public int ReaderId { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string PhoneNumber { get; set; }

    public string Address { get; set; }
}
