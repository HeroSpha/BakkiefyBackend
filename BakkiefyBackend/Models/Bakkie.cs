namespace BakkiefyBackend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bakkie")]
    public partial class Bakkie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bakkie()
        {
            BakkieRequests = new HashSet<BakkieRequest>();
        }

        [StringLength(50)]
        public string BakkieId { get; set; }

        [Required]
        [StringLength(10)]
        public string RegNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Make { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [StringLength(50)]
        public string Color { get; set; }

        public int BakkieSizeId { get; set; }

        [Required]
        [StringLength(50)]
        public string DriverId { get; set; }

        public virtual BakkieSize BakkieSize { get; set; }

        public virtual Driver Driver { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BakkieRequest> BakkieRequests { get; set; }

       
        public virtual Online Online { get; set; }
    }
}
