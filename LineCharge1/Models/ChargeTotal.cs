using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LineCharge1.Models
{
    public class ChargeTotal
    {
        public string Type { get; set; }

        [DataType(DataType.Currency)]
        public double Amount { get; set; }
    }
}