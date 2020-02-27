using ExamenFinalVuelingIF.Models;
using ExamenFinalVuelingIF.Services.Repository.RatesRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinalVuelingIF.Tests.PruebasUnitarias.Services
{
    [TestClass]
    public class RatesRepositoryTest
    {
        private IRatesRepository repositorio = new RatesRepository();
        private Rates rates = new Rates { From = "USD", To = "EUR", Rate = 0.65M };


        [TestMethod]
        public async Task RepositorioCreate()
        {

            repositorio.Insert(rates);
            await repositorio.Save();
            var guardado = await repositorio.GetById(rates.Id);
            Assert.IsNotNull(guardado);
            Assert.AreEqual(rates.Id, guardado.Id);
        }

    }
}
