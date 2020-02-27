using ExamenFinalVuelingIF.Models;
using ExamenFinalVuelingIF.Services.Repository.TransactionRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinalVuelingIF.Tests.PruebasUnitarias.Services
{
    [TestClass]
   public class TransactionRepositoryTest
    {
        private ITransactionRepository repositorio = new TransactionRepository();
        private Transaction transaction = new Transaction { Sku = "C6618", Amount = 33.9M, Currency = "USD" };


        [TestMethod]
        public async Task Repositorio()
        {

            repositorio.Insert(transaction);
            await repositorio.Save();
            var guardado = await repositorio.GetById(transaction.Id);
            Assert.IsNotNull(guardado);
            Assert.AreEqual(transaction.Id, guardado.Id);
        }
    }
}
