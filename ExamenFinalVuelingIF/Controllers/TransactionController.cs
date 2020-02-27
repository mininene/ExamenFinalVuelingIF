using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamenFinalVuelingIF.DAL;
using ExamenFinalVuelingIF.Models;
using ExamenFinalVuelingIF.Services.Repository.TransactionRepository;
using ExamenFinalVuelingIF.InfraestructuraTransversal.ControllerException;

namespace ExamenFinalVuelingIF.Controllers
{
    public class TransactionController : BaseController
    {
        private ITransactionRepository repositorio = null;

        public TransactionController()
        {
            this.repositorio = new TransactionRepository();
        }

        public TransactionController(ITransactionRepository repositorio)
        {
            this.repositorio = repositorio;
        }


        // GET: Transactions
        public async Task<ActionResult> Index()
        {
            try
            {
                await repositorio.DatosApi();
                return View(await repositorio.GetAll());
            }
            catch (Exception ex)
            {
                throw new ControllerException("Error en task ActionResult Get", ex);
            }
        }

        // GET: Transactions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = await repositorio.GetById(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Sku,Amount,Currency")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                repositorio.Insert(transaction);
                await repositorio.Save();
                return RedirectToAction("Index");
            }

            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Transaction transaction = await repositorio.GetById(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Sku,Amount,Currency")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                repositorio.Update(transaction);
                await repositorio.Save();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Transaction transaction = await repositorio.GetById(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Transaction transaction = await repositorio.GetById(id);
            await repositorio.Delete(id);
            await repositorio.Save();
            return RedirectToAction("Index");
        }


    }
}
