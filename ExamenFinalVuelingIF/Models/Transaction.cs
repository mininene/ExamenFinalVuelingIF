using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenFinalVuelingIF.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set;}
    }


    
}