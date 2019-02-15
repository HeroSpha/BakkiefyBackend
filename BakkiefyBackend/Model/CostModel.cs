using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BakkiefyBackend.Models;

namespace BakkiefyBackend.Model
{
    public class CostModel
    {

        [StringLength(50)]
        public string CostId { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public bool IsCurrent { get; set; }
    }
}