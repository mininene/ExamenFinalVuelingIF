using ExamenFinalVuelingIF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinalVuelingIF.Services.Specification
{
    public interface IValidationRatesSpecification
    {
        bool RatesIsSatisfiedBy(Rates registroRates);
    }
}
