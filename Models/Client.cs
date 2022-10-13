using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using PhotoGallery.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoGallery.Models
{
    public class Client
    {
        [Key]
        public Guid ClientID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(35)]
        [Display(Name = "First name")]
        public string FirstName { get; set; } = string.Empty;

        
        [Required(AllowEmptyStrings = false)]
        [StringLength(35)]
        [Display(Name = "Last name")]
        public string LastName { get; set; } = string.Empty;

        public Gender Gender { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        public DateTime BirthdayDate { get; set; }

        [ForeignKey("IdentityUser")]
        public Guid ExternalUserID { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public List<Collection> Collections { get; set; }
        public List<ClientFavorite> ClientFavorites { get; set; }
    }
}
