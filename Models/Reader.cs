using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Reader
    {
        [Key]
        public int ReaderId { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; } = null!;

        [Required, StringLength(50)]
        public string LastName { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required, Phone]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;
    }
}
