using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ExamenFinalVuelingIF.Models;

namespace ExamenFinalVuelingIF.DAL
{
    public class MoneyContext: DbContext
    {
        public MoneyContext() : base("MoneyContext")
        { }

        public DbSet<Rates> Rates { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        public System.Data.Entity.DbSet<ExamenFinalVuelingIF.Models.VMtransactionBySku> VMtransactionBySkus { get; set; }
    }
}