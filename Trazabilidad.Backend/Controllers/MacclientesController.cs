using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trazabilidad.Backend.Models;
using Trazabilidad.Common.Models;

namespace Trazabilidad.Backend.Controllers
{
    public class MacclientesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Macclientes
        public async Task<ActionResult> Index()
        {
            return View(await db.Macclientes.ToListAsync());
        }

        // GET: Macclientes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maccliente maccliente = await db.Macclientes.FindAsync(id);
            if (maccliente == null)
            {
                return HttpNotFound();
            }
            return View(maccliente);
        }

        // GET: Macclientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Macclientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MacclienteId,VerMaccliente,FechaMaccliente")] Maccliente maccliente)
        {
            if (ModelState.IsValid)
            {
                db.Macclientes.Add(maccliente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(maccliente);
        }

        // GET: Macclientes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maccliente maccliente = await db.Macclientes.FindAsync(id);
            if (maccliente == null)
            {
                return HttpNotFound();
            }
            return View(maccliente);
        }

        // POST: Macclientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MacclienteId,VerMaccliente,FechaMaccliente")] Maccliente maccliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maccliente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(maccliente);
        }

        // GET: Macclientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maccliente maccliente = await db.Macclientes.FindAsync(id);
            if (maccliente == null)
            {
                return HttpNotFound();
            }
            return View(maccliente);
        }

        // POST: Macclientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Maccliente maccliente = await db.Macclientes.FindAsync(id);
            db.Macclientes.Remove(maccliente);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
