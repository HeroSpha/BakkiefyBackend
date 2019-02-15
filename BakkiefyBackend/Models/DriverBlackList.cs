namespace BakkiefyBackend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DriverBlackList")]
    public partial class DriverBlackList
    {
        public int DriverBlacklistId { get; set; }

        [Required]
        [StringLength(50)]
        public string DriverId { get; set; }

        [Required]
        public string Reason { get; set; }

        public virtual Driver Driver { get; set; }
    }
}
