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
    public class TandefsController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Tandefs
        public async Task<ActionResult> Index()
        {
            return View(await db.Tandefs.ToListAsync());
        }

        // GET: Tandefs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tandef tandef = await db.Tandefs.FindAsync(id);
            if (tandef == null)
            {
                return HttpNotFound();
            }
            return View(tandef);
        }

        // GET: Tandefs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tandefs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTandef,Codtan,Arttan,Desart,IdEstacion")] Tandef tandef)
        {
            if (ModelState.IsValid)
            {
                db.Tandefs.Add(tandef);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tandef);
        }

        // GET: Tandefs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tandef tandef = await db.Tandefs.FindAsync(id);
            if (tandef == null)
            {
                return HttpNotFound();
            }
            return View(tandef);
        }

        // POST: Tandefs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTandef,Codtan,Arttan,Desart,IdEstacion")] Tandef tandef)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tandef).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tandef);
        }

        // GET: Tandefs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tandef tandef = await db.Tandefs.FindAsync(id);
            if (tandef == null)
            {
                return HttpNotFound();
            }
            return View(tandef);
        }

        // POST: Tandefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tandef tandef = await db.Tandefs.FindAsync(id);
            db.Tandefs.Remove(tandef);
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
