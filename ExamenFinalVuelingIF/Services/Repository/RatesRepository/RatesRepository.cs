
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using ExamenFinalVuelingIF.InfraestructuraTransversal.ServicesException;
using ExamenFinalVuelingIF.Models;
using ExamenFinalVuelingIF.Services.Factory;
using ExamenFinalVuelingIF.Services.Specification;
using ExamenFinalVuelingIF.Services.Log;

namespace ExamenFinalVuelingIF.Services.Repository.RatesRepository
{
    public class RatesRepository:GenericRepository<Rates>, IRatesRepository
    {
       

        public override async Task DatosApi()

        {
         IValidationRatesSpecification _validationRatesSpecification = new ValidationRatesSpecification();
         IRatesFactory RatesFactory = new RatesFactory();
       

            using (var client = new HttpClient())
            {

                try
                {
                    HttpResponseMessage response = client.GetAsync("http://quiet-stone-2094.herokuapp.com/rates.json").Result;
                    List<Rates> lista;
                    string contenido = response.Content.ReadAsStringAsync().Result;
                    {

                        lista = _convert.DeserializerJson(contenido);
                    }

                    table.RemoveRange(table);



                    var listaRates = RatesFactory.CreateRates(lista);

                    table.AddRange(listaRates);

                   await _context.SaveChangesAsync();



                }
                catch(HttpRequestException) {  }
                catch (Exception ex) { throw new RepositoryException("Fallo en el repositorio Rates", ex); }

                

            }
        }

      

      
    }
}