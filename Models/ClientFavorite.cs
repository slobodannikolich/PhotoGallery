using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoGallery.Models
{
    public class ClientFavorite
    {
        [Key]
        public Guid ClientFavoriteID { get; set; }

        [ForeignKey("Client")]
        public Guid CilentID { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Painting")]
        public Guid PaintingID { get; set; }
        public Painting Painting { get; set; }

        public DateTime Date { get; set; }
    }
}
