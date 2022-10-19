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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public string ExternalUserID { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public ICollection<ClientCollection> Collections { get; set; } = new HashSet<ClientCollection>();
        public ICollection<ClientFavorite> ClientFavorites { get; set; } = new HashSet<ClientFavorite>();
    }
}
