using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoGallery.Models
{
    public class ClientFavorite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClientFavoriteID { get; set; }

        [ForeignKey("Client")]
        public Guid ClientID { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Painting")]
        public Guid PaintingID { get; set; }
        public Painting Painting { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
