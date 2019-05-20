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
    public class MacserverdefsController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Macserverdefs
        public async Task<ActionResult> Index()
        {
            return View(await db.Macserverdefs.ToListAsync());
        }

        // GET: Macserverdefs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Macserverdef macserverdef = await db.Macserverdefs.FindAsync(id);
            if (macserverdef == null)
            {
                return HttpNotFound();
            }
            return View(macserverdef);
        }

        // GET: Macserverdefs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Macserverdefs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Idmacserve,linea,IdEstacion")] Macserverdef macserverdef)
        {
            if (ModelState.IsValid)
            {
                db.Macserverdefs.Add(macserverdef);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(macserverdef);
        }

        // GET: Macserverdefs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Macserverdef macserverdef = await db.Macserverdefs.FindAsync(id);
            if (macserverdef == null)
            {
                return HttpNotFound();
            }
            return View(macserverdef);
        }

        // POST: Macserverdefs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Idmacserve,linea,IdEstacion")] Macserverdef macserverdef)
        {
            if (ModelState.IsValid)
            {
                db.Entry(macserverdef).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(macserverdef);
        }

        // GET: Macserverdefs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Macserverdef macserverdef = await db.Macserverdefs.FindAsync(id);
            if (macserverdef == null)
            {
                return HttpNotFound();
            }
            return View(macserverdef);
        }

        // POST: Macserverdefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Macserverdef macserverdef = await db.Macserverdefs.FindAsync(id);
            db.Macserverdefs.Remove(macserverdef);
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
