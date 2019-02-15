namespace BakkiefyBackend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BakkieRequest")]
    public partial class BakkieRequest
    {

        [StringLength(50)]
        public string BakkieRequestId { get; set; }

        [Required]
        [StringLength(50)]
        public string BakkieId { get; set; }

        public DateTime RequestDate { get; set; }

        [Required]
        [StringLength(50)]
        public string RequestStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerId { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public double Latitute { get; set; }

        public double Longitude { get; set; }

        public virtual Bakkie Bakkie { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Ticket Ticket { get; set; }

        
        public virtual Rating Rating { get; set; }
    }
}
