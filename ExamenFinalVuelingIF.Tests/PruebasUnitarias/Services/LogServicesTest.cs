using ExamenFinalVuelingIF.Services.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinalVuelingIF.Tests.PruebasUnitarias.Services
{
    [TestClass]
    public class LogServicesTest
    {
        public string Contain = "";
        private readonly ILog _log = new ProductionLog();

        [TestInitialize]
        public void LogServiceInit()
        {
            Contain = "Esto es una prueba de funcionamiento!";
            _log.WriteLog(Contain);
        }

        [TestMethod]
        public void LogWrite()
        {
            _log.WriteLog(Contain);
        }
    }
}
