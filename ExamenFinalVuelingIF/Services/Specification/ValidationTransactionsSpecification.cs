using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamenFinalVuelingIF.InfraestructuraTransversal.ServicesException;
using ExamenFinalVuelingIF.Models;

namespace ExamenFinalVuelingIF.Services.Specification
{
    public class ValidationTransactionsSpecification : IValidationTransactionsSpecification
    {
        
        public bool TransactionIsSatisfiedBy(Transaction registroTransaction)
        {
            try
            {
                return !registroTransaction.Sku.Equals("")
                   && registroTransaction.Sku != null

                   && !registroTransaction.Amount.Equals("")
                   && registroTransaction.Amount != null

                  && !registroTransaction.Currency.Equals("")
                  && registroTransaction.Currency != null;
            }
            catch (Exception ex)
            {
                throw new ValidationSpecificationException("No se han podido validar las transaction", ex);
            }

        }
    }
}