using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakkiefyBackend.Model
{
    public class VerifyModel
    {
        public string PhoneNumber { get; set; }
        public string Verification { get; set; }
        public string Code { get; set; }
    }
}