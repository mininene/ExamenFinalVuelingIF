using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenFinalVuelingIF.Models
{
    public class RatesMetadata
    {

        public int Id { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public string Rate { get; set; }
    }

    [MetadataType(typeof(RatesMetadata))]
    public partial class Rates
    { }
}