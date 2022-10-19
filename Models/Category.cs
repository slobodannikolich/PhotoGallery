using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoGallery.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CategoryID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;  

        [StringLength(200)]
        public string Description { get; set; } = string.Empty;

        public ICollection<PaintingCategory> PaintingCategories { get; set; } = new HashSet<PaintingCategory>();   
    }
}
