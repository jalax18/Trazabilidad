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
    public class SurdefsController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Surdefs
        public async Task<ActionResult> Index()
        {
            return View(await db.Surdefs.ToListAsync());
        }

        // GET: Surdefs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Surdef surdef = await db.Surdefs.FindAsync(id);
            if (surdef == null)
            {
                return HttpNotFound();
            }
            return View(surdef);
        }

        // GET: Surdefs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Surdefs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdSurdef,Possur,Manguera,Desart,Codsur,IdEstacion")] Surdef surdef)
        {
            if (ModelState.IsValid)
            {
                db.Surdefs.Add(surdef);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(surdef);
        }

        // GET: Surdefs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Surdef surdef = await db.Surdefs.FindAsync(id);
            if (surdef == null)
            {
                return HttpNotFound();
            }
            return View(surdef);
        }

        // POST: Surdefs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdSurdef,Possur,Manguera,Desart,Codsur,IdEstacion")] Surdef surdef)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surdef).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(surdef);
        }

        // GET: Surdefs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Surdef surdef = await db.Surdefs.FindAsync(id);
            if (surdef == null)
            {
                return HttpNotFound();
            }
            return View(surdef);
        }

        // POST: Surdefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Surdef surdef = await db.Surdefs.FindAsync(id);
            db.Surdefs.Remove(surdef);
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
