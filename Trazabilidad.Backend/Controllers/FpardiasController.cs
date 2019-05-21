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
    public class FpardiasController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Fpardias
        public async Task<ActionResult> Index()
        {
            return View(await db.Fpardias.ToListAsync());
        }

        // GET: Fpardias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fpardia fpardia = await db.Fpardias.FindAsync(id);
            if (fpardia == null)
            {
                return HttpNotFound();
            }
            return View(fpardia);
        }

        // GET: Fpardias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fpardias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdFpardia,IdEstacion,Fptipest,Fpemp,Fpdir,Fptel,Fpcab1,Fpcab2,Fpcab3,Fpcab4,Fpcab5,Fppie1,Fppie2,Fppie3,Fpcabfac1,Fpcabfac2,Fpcabfac3,Fpcabfac4,Fpcabfac5,Fpcabfac6,Fpcabfac7,Fppiefac1,Fppiefac2,Fppiefac3")] Fpardia fpardia)
        {
            if (ModelState.IsValid)
            {
                db.Fpardias.Add(fpardia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fpardia);
        }

        // GET: Fpardias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fpardia fpardia = await db.Fpardias.FindAsync(id);
            if (fpardia == null)
            {
                return HttpNotFound();
            }
            return View(fpardia);
        }

        // POST: Fpardias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdFpardia,IdEstacion,Fptipest,Fpemp,Fpdir,Fptel,Fpcab1,Fpcab2,Fpcab3,Fpcab4,Fpcab5,Fppie1,Fppie2,Fppie3,Fpcabfac1,Fpcabfac2,Fpcabfac3,Fpcabfac4,Fpcabfac5,Fpcabfac6,Fpcabfac7,Fppiefac1,Fppiefac2,Fppiefac3")] Fpardia fpardia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fpardia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fpardia);
        }

        // GET: Fpardias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fpardia fpardia = await db.Fpardias.FindAsync(id);
            if (fpardia == null)
            {
                return HttpNotFound();
            }
            return View(fpardia);
        }

        // POST: Fpardias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Fpardia fpardia = await db.Fpardias.FindAsync(id);
            db.Fpardias.Remove(fpardia);
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
