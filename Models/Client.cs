using Microsoft.AspNetCore.Mvc.ApplicationModels;
using PhotoGallery.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoGallery.Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        public DateTime BirthdayDate { get; set; }

        [ForeignKey("ExternalUserID")]
        public int ExternalUserID { get; set; }

        public User User { get; set; }

        public List<Collection> Collections { get; set; }
        public List<ClientFavorite> ClientFavorites { get; set; }
    }
}
