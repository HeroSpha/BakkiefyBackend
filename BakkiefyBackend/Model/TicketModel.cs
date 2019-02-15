using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BakkiefyBackend.Model
{
    public class TicketModel
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