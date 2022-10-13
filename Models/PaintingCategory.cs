using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoGallery.Models
{
    public class PaintingCategory
    {
        public Guid PaintingCategoryID { get; set; }

        [ForeignKey("Painting")]
        public Guid PaintingID { get; set; }
        public Painting Painting { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
