using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenFinalVuelingIF.Models
{
    public class VMtransactionBySku
    {
        [Key]
        public string Sku { get; set; }
        public string Currency { get; set; }
        public decimal Suma { get; set; }
    }
}