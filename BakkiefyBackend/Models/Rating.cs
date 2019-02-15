namespace BakkiefyBackend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rating
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
