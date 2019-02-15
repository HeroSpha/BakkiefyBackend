using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BakkiefyBackend.Models;

namespace BakkiefyBackend.Model
{
    public class CustomerModel
    {
        public CustomerModel()
        {
            BakkieRequests = new HashSet<BakkieRequest>();
        }
        [StringLength(50)]
        public string CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Address { get; set; }
        public virtual CustomerBlackList CustomerBlackList { get; set; }

        public virtual ICollection<BakkieRequest> BakkieRequests { get; set; }

    }
}