using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LineCharge1.Models
{
    public class ChargeType
    {
        [Required]
        public int ChargeTypeID { get; set; }

        [Required]
        public string Type { get; set; }
    }
}