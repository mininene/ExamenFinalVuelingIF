using ExamenFinalVuelingIF.Controllers;
using ExamenFinalVuelingIF.Models;
using ExamenFinalVuelingIF.Services.Repository.TransactionRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExamenFinalVuelingIF.Tests.PruebasIntegracion
{
    [TestClass]
    public class TransactionControllerTest
    {
        TransactionController transactioncontroller = new TransactionController();
        private ITransactionRepository repositorio = new TransactionRepository();
        private Transaction transaction = new Transaction { Sku = "C6618", Amount = 33.9M, Currency = "USD" };

        [TestMethod]
        public async Task Index()

        {
            var resultado = await transactioncontroller.Index();
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado is ActionResult);

        }

        [TestMethod]
        public async Task create()

        {
            repositorio.Insert(transaction);
            await repositorio.Save();
            var guardado = await repositorio.GetById(transaction.Id);
            Assert.IsNotNull(guardado);

        }
    }
}
