using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GillyBeanCentral.Entities
{
    [Table("VenueActivityOption")]
    public class VenueActivityOption
    {

        [Required]
        [Key, Column(Order = 1)]
        public int VenueID { get; set; }

        [Required]
        [Key, Column(Order = 2)]
        public int ActivityOptionID { get; set; }
        

    }
}