using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenFinalVuelingIF.InfraestructuraTransversal.ServicesException
{
    public class ValidationSpecificationException:Exception
    {
    public ValidationSpecificationException(string message, Exception innerException) : base(message, innerException)
    {
    }

    }
    
    
}