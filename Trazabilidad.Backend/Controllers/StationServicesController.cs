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
    using Helpers;
    public class StationServicesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: StationServices
        public async Task<ActionResult> Index()
        {
            return View(await db.StationServices.ToListAsync());
        }

        // GET: StationServices/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationService stationService = await db.StationServices.FindAsync(id);
            if (stationService == null)
            {
                return HttpNotFound();
            }
            return View(stationService);
        }

        // GET: StationServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StationServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StationServiceView view)
        {
            if (ModelState.IsValid)
            {
                var pic = string.Empty;
                var folder = "~/Content/StationPhotos";

                if (view.ImageFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImageFile, folder);
                    pic = $"{folder}/{pic}";
                 //   pic = string.Format("{0}/{1}", folder, pic);
                }
                var stationService = this.ToStationService(view,pic);

                db.StationServices.Add(stationService);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(view);
        }

        private StationService ToStationService(StationServiceView view,string pic)
        {
            return new StationService {
                StationId=view.StationId,
                NameStation=view.NameStation,
                VersionMacserver=view.VersionMacserver,
                VersionMaccliente=view.VersionMaccliente,
                VersionMpecliente=view.VersionMpecliente,
                VersionXad=view.VersionXad,
                VersionGarum=view.VersionGarum,
                TipoEstacion=view.TipoEstacion,
                FechaEstacion=view.FechaEstacion,
                Server=view.Server,
                NumeroTpvs=view.NumeroTpvs,
                ImagePath=pic,
            };
        }

        // GET: StationServices/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationService stationService = await db.StationServices.FindAsync(id);
            if (stationService == null)
            {
                return HttpNotFound();
            }

            var view = this.ToView(stationService);
            return View(view);
        }

        private StationServiceView ToView(StationService stationService)
        {
            return new StationServiceView
            {
                StationId = stationService.StationId,
                NameStation = stationService.NameStation,
                VersionMacserver = stationService.VersionMacserver,
                VersionMaccliente = stationService.VersionMaccliente,
                VersionMpecliente = stationService.VersionMpecliente,
                VersionXad = stationService.VersionXad,
                VersionGarum = stationService.VersionGarum,
                TipoEstacion = stationService.TipoEstacion,
                FechaEstacion = stationService.FechaEstacion,
                Server = stationService.Server,
                NumeroTpvs = stationService.NumeroTpvs,
                ImagePath = stationService.ImagePath,
            };
        }

        // POST: StationServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( StationServiceView view)
        {
            if (ModelState.IsValid)
            {
                var pic = view.ImagePath;
                var folder = "~/Content/StationPhotos";

                if (view.ImageFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImageFile, folder);
                    pic = $"{folder}/{pic}";
                    //   pic = string.Format("{0}/{1}", folder, pic);
                }
                var stationService = this.ToStationService(view, pic);
                db.Entry(stationService).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(view);
        }

        // GET: StationServices/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationService stationService = await db.StationServices.FindAsync(id);
            if (stationService == null)
            {
                return HttpNotFound();
            }
            return View(stationService);
        }

        // POST: StationServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StationService stationService = await db.StationServices.FindAsync(id);
            db.StationServices.Remove(stationService);
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
