namespace BakkiefyBackend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Online")]
    public partial class Online
    {
        [StringLength(50)]
        public string OnlineId { get; set; }

        [Required]
        [StringLength(50)]
        public string BakkieId { get; set; }

        public bool Status { get; set; }

        public int Radius { get; set; }

        [Required]
        [StringLength(50)]
        public string DriverStatus { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public virtual Bakkie Bakkie { get; set; }
    }
}
