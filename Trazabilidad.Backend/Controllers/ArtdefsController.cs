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
    public class ArtdefsController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Artdefs
        public async Task<ActionResult> Index()
        {
            return View(await db.Artdefs.ToListAsync());
        }

        // GET: Artdefs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artdef artdef = await db.Artdefs.FindAsync(id);
            if (artdef == null)
            {
                return HttpNotFound();
            }
            return View(artdef);
        }

        // GET: Artdefs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artdefs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdArtdef,Codart,Desart,IdArticu,Idgrupo,Idsubfam,Idfam,IdEstacion")] Artdef artdef)
        {
            if (ModelState.IsValid)
            {
                db.Artdefs.Add(artdef);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(artdef);
        }

        // GET: Artdefs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artdef artdef = await db.Artdefs.FindAsync(id);
            if (artdef == null)
            {
                return HttpNotFound();
            }
            return View(artdef);
        }

        // POST: Artdefs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdArtdef,Codart,Desart,IdArticu,Idgrupo,Idsubfam,Idfam,IdEstacion")] Artdef artdef)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artdef).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(artdef);
        }

        // GET: Artdefs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artdef artdef = await db.Artdefs.FindAsync(id);
            if (artdef == null)
            {
                return HttpNotFound();
            }
            return View(artdef);
        }

        // POST: Artdefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Artdef artdef = await db.Artdefs.FindAsync(id);
            db.Artdefs.Remove(artdef);
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
