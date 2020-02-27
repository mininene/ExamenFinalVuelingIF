using ExamenFinalVuelingIF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinalVuelingIF.Services.Factory
{
    public interface IRatesFactory
    {
        List<Rates> CreateRates(List<Rates> rates);
    }
}
