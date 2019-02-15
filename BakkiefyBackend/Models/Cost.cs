namespace BakkiefyBackend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cost")]
    public partial class Cost
    {
        [StringLength(50)]
        public string CostId { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public bool IsCurrent { get; set; }
    }
}
