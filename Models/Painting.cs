using PhotoGallery.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoGallery.Models
{
    public class Painting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PaintingID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        [Display(Name = "Painting name")]
        public string PaintingName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Creation year")]
        public int CreationYear { get; set; }

        [Required]
        [Display(Name = "Painting tehnique")]
        public PaintingTehnique PaintingTehnique { get; set; }

        [StringLength(200)]
        public string Documentation { get; set; } = string.Empty;

        [StringLength(200)]
        public string Desctiprion { get; set; } = string.Empty;

        public VisibleStatus VisibleStatus { get; set; }

        [ForeignKey("Author")]
        public Guid AuthorID { get; set; }
        public Author Author { get; set; }


        [ForeignKey("Collection")]
        public Guid ClientCollectionID { get; set; }
        public ClientCollection ClientCollection { get; set; }


        public ICollection<PaintingCategory> PaintingCategories { get; set; } = new HashSet<PaintingCategory>();
        public ICollection<ClientFavorite> ClientFavorites { get; set; } = new HashSet<ClientFavorite>();
    }
}
