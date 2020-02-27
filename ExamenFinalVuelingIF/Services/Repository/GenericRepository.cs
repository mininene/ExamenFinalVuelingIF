using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using ExamenFinalVuelingIF.Services.Repository;
using ExamenFinalVuelingIF.DAL;
using Newtonsoft.Json;
using ExamenFinalVuelingIF.Models;
using ExamenFinalVuelingIF.Services.JsonConvert;

namespace ExamenFinalVuelingIF.Services.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public MoneyContext _context = null;
        public DbSet<T> table = null;

        public IJsonConvert<T> _convert= null;

        public GenericRepository()
        {
            this._convert = new JsonConvert<T>();
           
            this._context = new MoneyContext();
            table = _context.Set<T>();
        }

        public GenericRepository(MoneyContext context)
        {
            this._convert = new JsonConvert<T>();
            this._context = context;
            table = _context.Set<T>();
        }

        public GenericRepository(MoneyContext context, IJsonConvert<T> converter)
        {
            this._convert = converter;
            this._context = context;
            table = _context.Set<T>();
        }




        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public virtual async Task<T> GetById(object id)
        {
            return await table.FindAsync(id);
        }

        public virtual void Insert(T obj)
        {
            table.Add(obj);
        }

        public virtual void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public virtual async Task Delete(object id)
        {
            T existing = await table.FindAsync(id);
            table.Remove(existing);
        }

        public virtual async Task Save()
        {
            await _context.SaveChangesAsync();
        }


        public virtual async Task<IEnumerable<Rates>> ListaRates()
        {
            return await _context.Rates.ToListAsync();
        }


        public virtual async Task<IEnumerable<Transaction>> ListaTransaction()
        {
            return await _context.Transaction.ToListAsync();
        }

        public abstract Task DatosApi();
        //public abstract Task DatosTransactionApi();

    }


}