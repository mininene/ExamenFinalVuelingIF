using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinalVuelingIF.Services.JsonConvert
{
    public interface IJsonConvert<T> where T : class
    {
        List<T> DeserializerJson(string contenido);
    }
}
