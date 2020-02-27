using ExamenFinalVuelingIF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinalVuelingIF.Tests.PruebasUnitarias.Model
{
    [TestClass]
    public class TransactionModelTest
    {

        [TestMethod]
        public void TransactionCorrecto()
        {

            Transaction transaction = new Transaction {Sku = "C6618", Amount = 33.9M, Currency = "USD"};
            Assert.IsNotNull(transaction);


        }


        [TestMethod]
        public void TransactionPrimerVacio()
        {

            Transaction transaction = new Transaction { Sku = "", Amount = 33.9M, Currency = "USD" };
            Assert.IsTrue(string.IsNullOrEmpty(transaction.Sku));


        }


        [TestMethod]
        public void TransactionTercerVacio()
        {

            Transaction transaction = new Transaction { Sku = "C6618", Amount = 33.9M, Currency = "" };
            Assert.IsTrue(string.IsNullOrEmpty(transaction.Currency));



        }


    }
}
