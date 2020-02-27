using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamenFinalVuelingIF.InfraestructuraTransversal.ServicesException;
using ExamenFinalVuelingIF.Models;

namespace ExamenFinalVuelingIF.Services.Specification
{
    public class ValidationRatesSpecification : IValidationRatesSpecification
    {
        public bool RatesIsSatisfiedBy(Rates registroRates)
        {
            try
            {
                return !registroRates.From.Equals("")
                       && registroRates.Rate != null

                       && !registroRates.To.Equals("")
                       && registroRates.To != null

                       && !registroRates.Rate.Equals("")
                       && registroRates.Rate != null;
            }
            catch (Exception ex)
            {
                throw new ValidationSpecificationException("No se han podido validar los rates", ex);
            }
        }
    }
}