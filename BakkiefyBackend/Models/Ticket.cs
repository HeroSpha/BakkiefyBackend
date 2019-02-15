namespace BakkiefyBackend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        public int TicketId { get; set; }

        public int TecketNumber { get; set; }

        public bool IsPayed { get; set; }

        [StringLength(100)]
        public string Notes { get; set; }

        [Required]
        [StringLength(50)]
        public string CostId { get; set; }

        [Required]
        [StringLength(50)]
        public string BakkieRequestId { get; set; }
    }
}
