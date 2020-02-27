using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamenFinalVuelingIF.InfraestructuraTransversal.ServicesException;
using ExamenFinalVuelingIF.Models;
using ExamenFinalVuelingIF.Services.Specification;

namespace ExamenFinalVuelingIF.Services.Factory
{
    public class TransactionFactory : ITransactionFactory
    {

      private Transaction _transaction;


        private IValidationTransactionsSpecification _validationTransactionsSpecification = new ValidationTransactionsSpecification();
       private List<Transaction> ListaTransaction = new List<Transaction>();
        public List<Transaction> CreateTransaction(List<Transaction> transaction)
        {
            try
            {

                foreach (var item in transaction)
                {
                    if (_validationTransactionsSpecification.TransactionIsSatisfiedBy(item) == true)
                    {
                        ListaTransaction.Add(item);
                    }
                    else { throw new FactoryException("No se ha podido crear el objeto transaction "); }

                }

            }
            catch (Exception ex)
            {
                throw new FactoryException("No se ha podido crear el objeto de transaction", ex)
                    ;
            }
            return ListaTransaction;
            ;
        }
    }
    
}