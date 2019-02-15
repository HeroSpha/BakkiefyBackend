using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BakkiefyBackend.Models;

namespace BakkiefyBackend.Model
{
    public class RatingModel
    {
        [Key]
        [StringLength(50)]
        public string RatingsId { get; set; }

        [Required]
        [StringLength(50)]
        public string BakkieRequestId { get; set; }

        public int Rate { get; set; }

        public string Notes { get; set; }

        public virtual BakkieRequest BakkieRequest { get; set; }
    }
}