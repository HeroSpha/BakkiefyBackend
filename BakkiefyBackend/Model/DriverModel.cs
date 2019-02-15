using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BakkiefyBackend.Models;

namespace BakkiefyBackend.Model
{
    public class DriverModel
    {
        [StringLength(50)]
        public string DriverId { get; set; }

        [StringLength(50)]
        public string Firstname { get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public string Photo { get; set; }
        public virtual Bakkie Bakkie { get; set; }
        public virtual DriverBlackList DriverBlackList { get; set; }
    }
}