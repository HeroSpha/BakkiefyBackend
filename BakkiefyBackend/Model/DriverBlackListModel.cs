using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BakkiefyBackend.Models;

namespace BakkiefyBackend.Model
{
    public class DriverBlackListModel
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