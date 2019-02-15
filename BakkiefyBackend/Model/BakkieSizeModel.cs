using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BakkiefyBackend.Models;

namespace BakkiefyBackend.Model
{
    public class BakkieSizeModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BakkieSizeModel()
        {
            Bakkies = new HashSet<Bakkie>();
        }

        public int BakkieSizeId { get; set; }

        [Required]
        [StringLength(50)]
        public string ClassName { get; set; }

        [Required]
        [StringLength(4)]
        public string TonsRange { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bakkie> Bakkies { get; set; }
    }
}