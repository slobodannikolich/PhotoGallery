using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoGallery.Models
{
    public class PaintingCategory
    {
        public int PaintingCategoryID { get; set; }

        public int PaintingID { get; set; }
        public Painting Painting { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
