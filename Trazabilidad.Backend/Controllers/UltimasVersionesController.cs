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
    public class UltimasVersionesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: UltimasVersiones
        public async Task<ActionResult> Index()
        {
            return View(await db.UltimasVersiones.ToListAsync());
        }

        // GET: UltimasVersiones/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UltimasVersiones ultimasVersiones = await db.UltimasVersiones.FindAsync(id);
            if (ultimasVersiones == null)
            {
                return HttpNotFound();
            }
            return View(ultimasVersiones);
        }

        // GET: UltimasVersiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UltimasVersiones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdVersiones,VersionMacserver,FechaVersionMacserver,VersionMaccliente,FechaVersionMaccliente,VersionMpecliente,FechaVersionMpecliente,VersionXad,FechaVersionXad,VersionGarum,FechaVersionGarum")] UltimasVersiones ultimasVersiones)
        {
            if (ModelState.IsValid)
            {
                db.UltimasVersiones.Add(ultimasVersiones);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ultimasVersiones);
        }

        // GET: UltimasVersiones/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UltimasVersiones ultimasVersiones = await db.UltimasVersiones.FindAsync(id);
            if (ultimasVersiones == null)
            {
                return HttpNotFound();
            }
            return View(ultimasVersiones);
        }

        // POST: UltimasVersiones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdVersiones,VersionMacserver,FechaVersionMacserver,VersionMaccliente,FechaVersionMaccliente,VersionMpecliente,FechaVersionMpecliente,VersionXad,FechaVersionXad,VersionGarum,FechaVersionGarum")] UltimasVersiones ultimasVersiones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ultimasVersiones).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ultimasVersiones);
        }

        // GET: UltimasVersiones/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UltimasVersiones ultimasVersiones = await db.UltimasVersiones.FindAsync(id);
            if (ultimasVersiones == null)
            {
                return HttpNotFound();
            }
            return View(ultimasVersiones);
        }

        // POST: UltimasVersiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UltimasVersiones ultimasVersiones = await db.UltimasVersiones.FindAsync(id);
            db.UltimasVersiones.Remove(ultimasVersiones);
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
