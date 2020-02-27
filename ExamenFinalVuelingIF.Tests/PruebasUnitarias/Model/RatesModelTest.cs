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
    public class RatesModelTest
    {

        [TestMethod]
        public void RatesCorrecto()
        {

            Rates rates = new Rates {From = "USD", To = "EUR", Rate = 0.65M};
            Assert.IsNotNull(rates);
         
        }

        [TestMethod]
        public void RatesPrimeroVacio()
        {

            Rates rates = new Rates { From = "", To = "EUR", Rate = 0.65M };
            Assert.IsTrue(string.IsNullOrEmpty(rates.From));


        }

        [TestMethod]
        public void RatesSegundoVacio()
        {

            Rates rates = new Rates { From = "USD", To = "", Rate = 0.65M };
            Assert.IsTrue(string.IsNullOrEmpty(rates.To));


        }

        [TestMethod]
        public void RatesTercerNumerico()
        {

            Rates rates = new Rates { From = "USD", To = "", Rate = 0.65M };
            Assert.IsNotNull(rates.Rate);


        }


    }
}
