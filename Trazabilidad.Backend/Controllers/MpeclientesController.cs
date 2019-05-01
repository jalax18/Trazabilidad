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
    public class MpeclientesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Mpeclientes
        public async Task<ActionResult> Index()
        {
            return View(await db.Mpeclientes.ToListAsync());
        }

        // GET: Mpeclientes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mpecliente mpecliente = await db.Mpeclientes.FindAsync(id);
            if (mpecliente == null)
            {
                return HttpNotFound();
            }
            return View(mpecliente);
        }

        // GET: Mpeclientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mpeclientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MpeclienteId,VerMpecliente,FechaMpecliente")] Mpecliente mpecliente)
        {
            if (ModelState.IsValid)
            {
                db.Mpeclientes.Add(mpecliente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mpecliente);
        }

        // GET: Mpeclientes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mpecliente mpecliente = await db.Mpeclientes.FindAsync(id);
            if (mpecliente == null)
            {
                return HttpNotFound();
            }
            return View(mpecliente);
        }

        // POST: Mpeclientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MpeclienteId,VerMpecliente,FechaMpecliente")] Mpecliente mpecliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mpecliente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mpecliente);
        }

        // GET: Mpeclientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mpecliente mpecliente = await db.Mpeclientes.FindAsync(id);
            if (mpecliente == null)
            {
                return HttpNotFound();
            }
            return View(mpecliente);
        }

        // POST: Mpeclientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Mpecliente mpecliente = await db.Mpeclientes.FindAsync(id);
            db.Mpeclientes.Remove(mpecliente);
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
