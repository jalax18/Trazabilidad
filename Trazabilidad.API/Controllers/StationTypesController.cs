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
    public class StationTypesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/StationTypes
        public IQueryable<StationType> GetStationTypes()
        {
            return db.StationTypes;
        }

        // GET: api/StationTypes/5
        [ResponseType(typeof(StationType))]
        public async Task<IHttpActionResult> GetStationType(int id)
        {
            StationType stationType = await db.StationTypes.FindAsync(id);
            if (stationType == null)
            {
                return NotFound();
            }

            return Ok(stationType);
        }

        // PUT: api/StationTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStationType(int id, StationType stationType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stationType.StationTypeId)
            {
                return BadRequest();
            }

            db.Entry(stationType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationTypeExists(id))
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

        // POST: api/StationTypes
        [ResponseType(typeof(StationType))]
        public async Task<IHttpActionResult> PostStationType(StationType stationType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StationTypes.Add(stationType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = stationType.StationTypeId }, stationType);
        }

        // DELETE: api/StationTypes/5
        [ResponseType(typeof(StationType))]
        public async Task<IHttpActionResult> DeleteStationType(int id)
        {
            StationType stationType = await db.StationTypes.FindAsync(id);
            if (stationType == null)
            {
                return NotFound();
            }

            db.StationTypes.Remove(stationType);
            await db.SaveChangesAsync();

            return Ok(stationType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StationTypeExists(int id)
        {
            return db.StationTypes.Count(e => e.StationTypeId == id) > 0;
        }
    }
}