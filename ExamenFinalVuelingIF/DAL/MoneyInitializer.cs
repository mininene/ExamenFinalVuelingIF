using ExamenFinalVuelingIF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenFinalVuelingIF.DAL
{
    public class MoneyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MoneyContext>
    {
        protected override void Seed(MoneyContext context)
        {
            //    var listaRates = new List<Rates>
            //    {
            //        new Rates { From = "USD", To = "EUR", Rate = 0.65M},
            //        new Rates {From = "EUR", To = "USD", Rate = 0.97M},
            //        new Rates { From = "USD", To = "CAD", Rate = 1.1M},
            //    };

            //    listaRates.ForEach(s => context.Rates.Add(s));
            //    context.SaveChanges();


            //    var listaTransaction = new List<Transaction>
            //    {
            //        new Transaction {Sku = "C6618", Amount = 33.9M, Currency = "USD"},
            //        new Transaction {Sku = "P6218", Amount = 25.7M, Currency = "CAD"},
            //        new Transaction {Sku = "Y6418", Amount = 54.2M, Currency = "EUR"},

            //    };
            //    listaTransaction.ForEach(s => context.Transaction.Add(s));
            //    context.SaveChanges();
        }
    }
}