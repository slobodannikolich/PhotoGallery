using System.ComponentModel.DataAnnotations;

namespace PhotoGallery.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Birthday date")]
        public DateTime BirthdayDate { get; set; }

        public List<Painting> Paintings { get; set; }
    }
}
