using PhotoGallery.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoGallery.Models
{
    public class Collection
    {
        [Key]
        public int CollectionID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public VisibleStatus VisibleStatus { get; set; }

        [ForeignKey("ClientID")]
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public List<Painting> Paintings { get; set; }
    }
}
