using System.ComponentModel.DataAnnotations;

namespace PhotoGallery.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public List<PaintingCategory> PaintingCategories { get; set; }
    }
}
