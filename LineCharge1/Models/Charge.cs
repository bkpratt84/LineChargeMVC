using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LineCharge1.Models
{
    public class Charge
    {
        [Required]
        public int ChargeID { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [Required]
        [Display(Name = "Charge Type")]
        public int ChargeTypeID { get; set; }

        [Required]
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }

        [NotMapped]
        public string Class
        {
            get { return Amount >= 0 ? "text-success" : "text-danger"; }
        }

        public ChargeType ChargeType { get; set; }
    }
}