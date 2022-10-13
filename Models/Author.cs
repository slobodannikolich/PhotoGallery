using System.ComponentModel.DataAnnotations;

namespace PhotoGallery.Models
{
    public class Author
    {
        [Key]
        public Guid AuthorID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        [Display(Name = "First name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        [Display(Name = "Last name")]
        public string LastName { get; set; } = string.Empty;

        
        [Display(Name = "Birthday date")]
        public DateTime BirthdayDate { get; set; }

        public List<Painting> Paintings { get; set; }
    }
}
