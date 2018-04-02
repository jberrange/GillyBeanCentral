using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GillyBeanCentral.Entities
{
    [Table("VenueEventFacility")]
    public class VenueEventFacility
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Key, Column(Order = 1)]
        public int VenueID { get; set; }

        [MaxLength(255)]
        [Required]
        public string FacilityName { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        public int CapacityMax { get; set; }


    }
}