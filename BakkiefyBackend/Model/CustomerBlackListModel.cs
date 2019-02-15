using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BakkiefyBackend.Models;

namespace BakkiefyBackend.Model
{
    public class CustomerBlackListModel
    {
        public int CustomerBlackListId { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerId { get; set; }

        [Required]
        public string Reason { get; set; }

        public virtual Customer Customer { get; set; }
    }
}