using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoGallery.Models
{
    public class ClientFavorite
    {
        [Key]
        public int ClientFavoriteID { get; set; }

        [ForeignKey("Client")]
        public int CilentID { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Painting")]
        public int PaintingID { get; set; }
        public Painting Painting { get; set; }

        public DateTime Date { get; set; }
    }
}
