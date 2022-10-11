using PhotoGallery.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoGallery.Models
{
    public class Painting
    {
        [Key]
        public int PaintingID { get; set; }

        [Required]
        [Display(Name = "Painting name")]
        public string PaintingName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Creation year")]
        public int CreationYear { get; set; }

        [Required]
        [Display(Name = "Painting tehnique")]
        public PaintingTehnique PaintingTehnique { get; set; }

        [Required]
        public string Documentation { get; set; } = string.Empty;

        [Required]
        public string Desctiprion { get; set; } = string.Empty;

        public VisibleStatus VisibleStatus { get; set; }

        [ForeignKey("AuthorID")]
        public int AuthorID { get; set; }
        public Author Author { get; set; }

        [ForeignKey("CollectionID")]
        public int CollectionID { get; set; }
        public Collection Collection { get; set; }

        public List<PaintingCategory> PaintingCategories { get; set; }
        public List<ClientFavorite> ClientFavorites { get; set; }
    }
}
