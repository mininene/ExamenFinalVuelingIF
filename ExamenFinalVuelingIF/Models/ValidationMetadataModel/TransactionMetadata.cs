using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenFinalVuelingIF.Models
{
    public class TransactionMetadata
    {
        public int Id { get; set; }
        [Required]
        public string Sku { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        public string Currency { get; set; }
    }

    [MetadataType(typeof(TransactionMetadata))]
    public partial class Transaction
    { }
}