using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BakkiefyBackend.Models;

namespace BakkiefyBackend.Model
{
    public class OnlineModel
    {
        [StringLength(50)]
        public string OnlineId { get; set; }

        public bool Status { get; set; }

        public int Radius { get; set; }

        [StringLength(50)]
        public string BakkieId { get; set; }

        [Required]
        [StringLength(50)]
        public string DriverStatus { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public virtual Bakkie Bakkie { get; set; }
    }
}