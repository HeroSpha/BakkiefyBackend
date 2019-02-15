using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BakkiefyBackend.Models;

namespace BakkiefyBackend.Model
{
    public class BakkieModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BakkieModel()
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