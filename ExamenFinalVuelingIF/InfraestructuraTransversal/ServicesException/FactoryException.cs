using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenFinalVuelingIF.InfraestructuraTransversal.ServicesException
{
    public class FactoryException:Exception
    {
        public FactoryException(string message) : base(message)
        {
        }

        public FactoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    
    
}