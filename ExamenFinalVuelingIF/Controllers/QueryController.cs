using ExamenFinalVuelingIF.Models;
using ExamenFinalVuelingIF.Services.Repository.RatesRepository;
using ExamenFinalVuelingIF.Services.Repository.TransactionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ExamenFinalVuelingIF.Controllers
{
    public class QueryController : BaseController
    {
        ITransactionRepository repositoriotrans = new TransactionRepository();
        IRatesRepository repositoriorates = new RatesRepository();

        // GET: Query
        public async Task<ActionResult> ListadoSku(string sku)
        {
            var lista = repositoriotrans.ListadoTransactionBySku(sku);
            return View(lista.ToList());
         }

        public async Task<ActionResult> Sum()
        {
            
            await repositoriotrans.DatosApi();
            await repositoriorates.DatosApi();
            var Segundalista = repositoriotrans.ListaSku();
            return View(Segundalista);
        }
    }
}