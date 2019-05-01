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
    public class GarumsController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Garums
        public async Task<ActionResult> Index()
        {
            return View(await db.Garums.ToListAsync());
        }

        // GET: Garums/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garum garum = await db.Garums.FindAsync(id);
            if (garum == null)
            {
                return HttpNotFound();
            }
            return View(garum);
        }

        // GET: Garums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Garums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GarumId,VerGarum,FechaGarum")] Garum garum)
        {
            if (ModelState.IsValid)
            {
                db.Garums.Add(garum);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(garum);
        }

        // GET: Garums/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garum garum = await db.Garums.FindAsync(id);
            if (garum == null)
            {
                return HttpNotFound();
            }
            return View(garum);
        }

        // POST: Garums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GarumId,VerGarum,FechaGarum")] Garum garum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garum).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(garum);
        }

        // GET: Garums/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garum garum = await db.Garums.FindAsync(id);
            if (garum == null)
            {
                return HttpNotFound();
            }
            return View(garum);
        }

        // POST: Garums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Garum garum = await db.Garums.FindAsync(id);
            db.Garums.Remove(garum);
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
