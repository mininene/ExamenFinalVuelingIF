using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamenFinalVuelingIF.InfraestructuraTransversal.ServicesException;
using ExamenFinalVuelingIF.Models;
using ExamenFinalVuelingIF.Services.Specification;

namespace ExamenFinalVuelingIF.Services.Factory
{
    public class RatesFactory : IRatesFactory
    {

        private Rates _rates;
       

        private IValidationRatesSpecification _validationRatesSpecification = new ValidationRatesSpecification();
        private List<Rates> ListaRates = new List<Rates>();
       public List<Rates> CreateRates(List<Rates> rates)
        {
            try
            {

                foreach (var item in rates)
                {
                    if (_validationRatesSpecification.RatesIsSatisfiedBy(item) == true)
                    {
                        ListaRates.Add(item);
                    }
                    else { throw new FactoryException("No se ha podido crear el objeto rates "); }

                }

            }
            catch (Exception ex)
            {
                throw new FactoryException("No se ha podido crear el objeto rates", ex);

            }
            return ListaRates;
        }
    }
}