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
    public class MacserversController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Macservers
        public async Task<ActionResult> Index()
        {
            return View(await db.Macservers.ToListAsync());
        }

        // GET: Macservers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Macserver macserver = await db.Macservers.FindAsync(id);
            if (macserver == null)
            {
                return HttpNotFound();
            }
            return View(macserver);
        }

        // GET: Macservers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Macservers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MacserverId,VerMacserver,FechaMacserver")] Macserver macserver)
        {
            if (ModelState.IsValid)
            {
                db.Macservers.Add(macserver);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(macserver);
        }

        // GET: Macservers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Macserver macserver = await db.Macservers.FindAsync(id);
            if (macserver == null)
            {
                return HttpNotFound();
            }
            return View(macserver);
        }

        // POST: Macservers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MacserverId,VerMacserver,FechaMacserver")] Macserver macserver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(macserver).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(macserver);
        }

        // GET: Macservers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Macserver macserver = await db.Macservers.FindAsync(id);
            if (macserver == null)
            {
                return HttpNotFound();
            }
            return View(macserver);
        }

        // POST: Macservers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Macserver macserver = await db.Macservers.FindAsync(id);
            db.Macservers.Remove(macserver);
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
