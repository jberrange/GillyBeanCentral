using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GillyBeanCentral.Entities

{
    [Table("Venue")]
    public class Venue
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id  { get; set; }

        [MaxLength(255)]
        [Required]
        [DisplayName("Venue Name")]
        public string VenueName { get; set; }

        [MaxLength(255)]
        [Required]
        public string Byline { get; set; }

        [DisplayName("Accommodation")]
        public bool HasAccommodation { get; set; }

        [DisplayName("Event Facilities")]
        public bool HasEventFacilities { get; set; }


        [MaxLength(1024)]
        public string Url { get; set; }

        [MaxLength(1024)]
        public string ThumbnailUrl { get; set; }
        
       
        //[DisplayName("Event Facilities")]
        //public ICollection<VenueEventFacility> EventFacilities { get; set; }

        [DisplayName("Venue Types")]
        public int VenueTypeID { get; set; }
        public ICollection<VenueType> VenueTypes { get; set; }

        
    }
}