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
    public class PosdefsController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Posdefs
        public async Task<ActionResult> Index()
        {
            return View(await db.Posdefs.ToListAsync());
        }

        // GET: Posdefs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posdef posdef = await db.Posdefs.FindAsync(id);
            if (posdef == null)
            {
                return HttpNotFound();
            }
            return View(posdef);
        }

        // GET: Posdefs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posdefs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdPosdef,Posicion,Numman,IdEstacion")] Posdef posdef)
        {
            if (ModelState.IsValid)
            {
                db.Posdefs.Add(posdef);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(posdef);
        }

        // GET: Posdefs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posdef posdef = await db.Posdefs.FindAsync(id);
            if (posdef == null)
            {
                return HttpNotFound();
            }
            return View(posdef);
        }

        // POST: Posdefs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdPosdef,Posicion,Numman,IdEstacion")] Posdef posdef)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posdef).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(posdef);
        }

        // GET: Posdefs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posdef posdef = await db.Posdefs.FindAsync(id);
            if (posdef == null)
            {
                return HttpNotFound();
            }
            return View(posdef);
        }

        // POST: Posdefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Posdef posdef = await db.Posdefs.FindAsync(id);
            db.Posdefs.Remove(posdef);
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
