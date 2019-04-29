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
    public class GarumsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Garums
        public IQueryable<Garum> GetGarums()
        {
            return db.Garums;
        }

        // GET: api/Garums/5
        [ResponseType(typeof(Garum))]
        public async Task<IHttpActionResult> GetGarum(int id)
        {
            Garum garum = await db.Garums.FindAsync(id);
            if (garum == null)
            {
                return NotFound();
            }

            return Ok(garum);
        }

        // PUT: api/Garums/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGarum(int id, Garum garum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != garum.GarumId)
            {
                return BadRequest();
            }

            db.Entry(garum).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GarumExists(id))
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

        // POST: api/Garums
        [ResponseType(typeof(Garum))]
        public async Task<IHttpActionResult> PostGarum(Garum garum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Garums.Add(garum);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = garum.GarumId }, garum);
        }

        // DELETE: api/Garums/5
        [ResponseType(typeof(Garum))]
        public async Task<IHttpActionResult> DeleteGarum(int id)
        {
            Garum garum = await db.Garums.FindAsync(id);
            if (garum == null)
            {
                return NotFound();
            }

            db.Garums.Remove(garum);
            await db.SaveChangesAsync();

            return Ok(garum);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GarumExists(int id)
        {
            return db.Garums.Count(e => e.GarumId == id) > 0;
        }
    }
}