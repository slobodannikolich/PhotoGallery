using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhotoGallery.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DisplayName("Confirm password")]
        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public Client Client { get; set; }
    }
}
