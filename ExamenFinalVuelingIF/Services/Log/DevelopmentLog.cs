using ExamenFinalVuelingIF.InfraestructuraTransversal.ServicesException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenFinalVuelingIF.Services.Log
{
    public class DevelopmentLog:ILog
    {
        public void WriteLog(string mensaje)
        {

            var date = DateTime.Now;

            try
            {
                Console.WriteLine($"[{date}] {mensaje}");
            }
            catch (Exception ex)
            {
                throw new LogException("No se ha podido escribir en la consola", ex);
            }
        }
    }
}