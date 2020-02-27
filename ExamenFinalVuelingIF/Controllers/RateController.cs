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
using ExamenFinalVuelingIF.Services.Repository.RatesRepository;
using ExamenFinalVuelingIF.InfraestructuraTransversal.ControllerException;

namespace ExamenFinalVuelingIF.Controllers
{
    public class RateController : BaseController
    {
        private IRatesRepository repositorio = null;

        public RateController()
        {
            this.repositorio = new RatesRepository();
        }

        public RateController(IRatesRepository repositorio)
        {
            this.repositorio = repositorio;
        }


        // GET: Rates
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

        // GET: Rates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rates rates = await repositorio.GetById(id);
            if (rates == null)
            {
                return HttpNotFound();
            }
            return View(rates);
        }

        // GET: Rates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,From,To,Rate")] Rates rates)
        {
            if (ModelState.IsValid)
            {
                repositorio.Insert(rates);
                await repositorio.Save();
                return RedirectToAction("Index");
            }

            return View(rates);
        }

        // GET: Rates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Rates rates = await repositorio.GetById(id);
            if (rates == null)
            {
                return HttpNotFound();
            }
            return View(rates);
        }

        // POST: Rates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,from,to,rate")] Rates rates)
        {
            if (ModelState.IsValid)
            {
                repositorio.Update(rates);
                await repositorio.Save();
                return RedirectToAction("Index");
            }
            return View(rates);
        }

        // GET: Rates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Rates rates = await repositorio.GetById(id);
            if (rates == null)
            {
                return HttpNotFound();
            }
            return View(rates);
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Rates rates = await repositorio.GetById(id);
            await repositorio.Delete(id);
            await repositorio.Save();
            return RedirectToAction("Index");
        }

    }
}


