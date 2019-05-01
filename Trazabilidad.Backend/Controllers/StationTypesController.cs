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
    public class StationTypesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: StationTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.StationTypes.ToListAsync());
        }

        // GET: StationTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationType stationType = await db.StationTypes.FindAsync(id);
            if (stationType == null)
            {
                return HttpNotFound();
            }
            return View(stationType);
        }

        // GET: StationTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StationTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StationTypeId,StationTypeName")] StationType stationType)
        {
            if (ModelState.IsValid)
            {
                db.StationTypes.Add(stationType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(stationType);
        }

        // GET: StationTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationType stationType = await db.StationTypes.FindAsync(id);
            if (stationType == null)
            {
                return HttpNotFound();
            }
            return View(stationType);
        }

        // POST: StationTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StationTypeId,StationTypeName")] StationType stationType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stationType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(stationType);
        }

        // GET: StationTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationType stationType = await db.StationTypes.FindAsync(id);
            if (stationType == null)
            {
                return HttpNotFound();
            }
            return View(stationType);
        }

        // POST: StationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StationType stationType = await db.StationTypes.FindAsync(id);
            db.StationTypes.Remove(stationType);
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
