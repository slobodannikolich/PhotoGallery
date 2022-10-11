using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoGallery.Models
{
    public class ClientFavorite
    {
        [Key]
        public int ClientFavoriteID { get; set; }

        public int CilentID { get; set; }
        public Client Client { get; set; }

        public int PaintingID { get; set; }
        public Painting Painting { get; set; }

        public DateTime Date { get; set; }
    }
}
