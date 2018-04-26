using LineCharge1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LineCharge1.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<ChargeType> ChargeTypes { get; set; }

        [Required(ErrorMessage = "Please enter an amount.")]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "The value must be greater than 0.")]
        public double? Amount { get; set; }

        [DataType(DataType.Currency)]
        public double ChargeTotal { get; set; }

        [Required(ErrorMessage = "Please select a Charge Type.")]
        public int ChargeTypeID { get; set; }

        public IEnumerable<Charge> Charges { get; set; }
        public IEnumerable<ChargeTotal> Totals { get; set; }
        public Charge Charge { get; set; }
        public ChargeTotal ChargeTtl { get; set; }
    }
}