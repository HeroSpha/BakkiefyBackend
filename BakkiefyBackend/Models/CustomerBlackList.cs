namespace BakkiefyBackend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerBlackList")]
    public partial class CustomerBlackList
    {
        public int CustomerBlackListId { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerId { get; set; }

        [Required]
        public string Reason { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
