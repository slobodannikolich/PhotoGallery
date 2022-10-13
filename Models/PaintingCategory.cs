namespace PhotoGallery.Models
{
    public class PaintingCategory
    {
        public Guid PaintingCategoryID { get; set; }

        public Guid PaintingID { get; set; }
        public Painting Painting { get; set; }

        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
