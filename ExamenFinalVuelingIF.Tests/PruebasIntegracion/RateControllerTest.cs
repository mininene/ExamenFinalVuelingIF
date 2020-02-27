using ExamenFinalVuelingIF.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenFinalVuelingIF.Services.Repository.RatesRepository;
using ExamenFinalVuelingIF.Models;
using System.Web.Mvc;

namespace ExamenFinalVuelingIF.Tests.PruebasIntegracion
{
    [TestClass]
    public class RateControllerTest
    {
        RateController ratecontroller = new RateController();
        private IRatesRepository repositorio = new RatesRepository();
        private Rates rates = new Rates {From = "USD", To = "EUR", Rate = 0.65M};

    [TestMethod]
        public async Task Index()

        {
            var resultado = await ratecontroller.Index();
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado is ActionResult);

        }

        [TestMethod]
        public async Task create()

        {
            repositorio.Insert(rates);
            await repositorio.Save();
            var guardado = await repositorio.GetById(rates.Id);
            Assert.IsNotNull(guardado);

        }
    }
}
