using ExamenFinalVuelingIF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExamenFinalVuelingIF.Services.Repository.TransactionRepository
{
    public interface ITransactionRepository: IGenericRepository<Transaction>
    {
        IQueryable<Transaction> ListadoTransactionBySku(string numeroTransaction);
        List<VMtransactionBySku> ListaSku();
    }
}
