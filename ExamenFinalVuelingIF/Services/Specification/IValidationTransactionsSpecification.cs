using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenFinalVuelingIF.Models;

namespace ExamenFinalVuelingIF.Services.Specification
{
    public interface IValidationTransactionsSpecification
    {
      
        bool TransactionIsSatisfiedBy(Transaction registroTransaction);
    }
}
