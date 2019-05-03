using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Trazabilidad.Common.Models;
using Trazabilidad.Domain.Models;

namespace Trazabilidad.API.Controllers
{
    public class StationServicesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/StationServices
        public IQueryable<StationService> GetStationServices()
        {
            return db.StationServices;
        }

        // GET: api/StationServices/5
        [ResponseType(typeof(StationService))]
        public async Task<IHttpActionResult> GetStationService(int id)
        {
            StationService stationService = await db.StationServices.FindAsync(id);
            if (stationService == null)
            {
                return NotFound();
            }

            return Ok(stationService);
        }

        // PUT: api/StationServices/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStationService(int id, StationService stationService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stationService.StationId)
            {
                return BadRequest();
            }

            db.Entry(stationService).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationServiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/StationServices
        [ResponseType(typeof(StationService))]
        public async Task<IHttpActionResult> PostStationService(StationService stationService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StationServices.Add(stationService);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = stationService.StationId }, stationService);
        }

        // DELETE: api/StationServices/5
        [ResponseType(typeof(StationService))]
        public async Task<IHttpActionResult> DeleteStationService(int id)
        {
            StationService stationService = await db.StationServices.FindAsync(id);
            if (stationService == null)
            {
                return NotFound();
            }

            db.StationServices.Remove(stationService);
            await db.SaveChangesAsync();

            return Ok(stationService);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StationServiceExists(int id)
        {
            return db.StationServices.Count(e => e.StationId == id) > 0;
        }
    }
}