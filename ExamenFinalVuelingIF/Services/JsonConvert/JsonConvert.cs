using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ExamenFinalVuelingIF.Services.JsonConvert
{
    public class JsonConvert<T> : IJsonConvert<T> where T : class
    {
        public List<T> DeserializerJson(string contenido)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(contenido);
          
        }
    }
}