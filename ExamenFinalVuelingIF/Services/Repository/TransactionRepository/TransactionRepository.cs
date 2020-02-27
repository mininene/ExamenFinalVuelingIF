using ExamenFinalVuelingIF.InfraestructuraTransversal.ServicesException;
using ExamenFinalVuelingIF.Models;
using ExamenFinalVuelingIF.Services.Factory;
using ExamenFinalVuelingIF.Services.Specification;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ExamenFinalVuelingIF.Services.Repository.TransactionRepository
{
    public class TransactionRepository: GenericRepository<Transaction>, ITransactionRepository
    {


        public override async Task DatosApi()

        {
            IValidationTransactionsSpecification _validationTransactionsSpecification = new ValidationTransactionsSpecification();
            ITransactionFactory TransactionFactory = new TransactionFactory();


            using (var client = new HttpClient())
            {

                try
                {
                    HttpResponseMessage response = client.GetAsync("http://quiet-stone-2094.herokuapp.com/transactions.json").Result;
                    List<Transaction> lista;
                    string contenido = response.Content.ReadAsStringAsync().Result;
                    {

                        lista = _convert.DeserializerJson(contenido);
                    }

                    table.RemoveRange(table);
                  
                    var listaTransaction = TransactionFactory.CreateTransaction(lista);

                    table.AddRange(listaTransaction);

                  
                    await _context.SaveChangesAsync();


                 
                }
                catch (HttpRequestException) { }
                catch (Exception ex) { throw new RepositoryException("Fallo en el repositorio Transaction", ex); }
            }
        }

        public IQueryable<Transaction> ListadoTransactionBySku(string numeroTransaction)
        {
            var query = from Transaction in _context.Transaction
                where Transaction.Sku == numeroTransaction
            select Transaction;
            return query;
        }

        public List<VMtransactionBySku> ListaSku()
        {
            {
                var nuevaLista = new List<VMtransactionBySku>();
                var SegundoQuery = (from j in _context.Transaction
                                    group j by j.Sku
                    into transaction
                                    select new
                                    {
                                        Nombre = transaction.Key,
                                        Suma = transaction.Sum(m => m.Amount),
                                       
                                    });


                foreach (var item in SegundoQuery)
                {
                    var nuevoTx = new VMtransactionBySku();
                    nuevoTx.Sku = item.Nombre;
                    nuevoTx.Suma = item.Suma;
                    nuevoTx.Currency = "EUR";
                    nuevaLista.Add(nuevoTx);
                }

                return nuevaLista;
            }
        }



      

    }

}
    
