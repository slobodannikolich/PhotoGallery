using System.ComponentModel.DataAnnotations;

namespace PhotoGallery.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;  

        [StringLength(200)]
        public string Description { get; set; } = string.Empty;

        public List<PaintingCategory> PaintingCategories { get; set; }
    }
}
