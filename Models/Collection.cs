﻿using PhotoGallery.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoGallery.Models
{
    public class Collection
    {
        [Key]
        public Guid CollectionID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        public string Description { get; set; } = string.Empty;

        public VisibleStatus VisibleStatus { get; set; }

        [ForeignKey("Client")]
        public Guid ClientID { get; set; }
        public Client Client { get; set; }
        public List<Painting> Paintings { get; set; }
    }
}
