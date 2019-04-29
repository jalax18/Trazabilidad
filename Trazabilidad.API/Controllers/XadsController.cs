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
    public class XadsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Xads
        public IQueryable<Xad> GetXads()
        {
            return db.Xads;
        }

        // GET: api/Xads/5
        [ResponseType(typeof(Xad))]
        public async Task<IHttpActionResult> GetXad(int id)
        {
            Xad xad = await db.Xads.FindAsync(id);
            if (xad == null)
            {
                return NotFound();
            }

            return Ok(xad);
        }

        // PUT: api/Xads/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutXad(int id, Xad xad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != xad.XadId)
            {
                return BadRequest();
            }

            db.Entry(xad).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XadExists(id))
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

        // POST: api/Xads
        [ResponseType(typeof(Xad))]
        public async Task<IHttpActionResult> PostXad(Xad xad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Xads.Add(xad);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = xad.XadId }, xad);
        }

        // DELETE: api/Xads/5
        [ResponseType(typeof(Xad))]
        public async Task<IHttpActionResult> DeleteXad(int id)
        {
            Xad xad = await db.Xads.FindAsync(id);
            if (xad == null)
            {
                return NotFound();
            }

            db.Xads.Remove(xad);
            await db.SaveChangesAsync();

            return Ok(xad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool XadExists(int id)
        {
            return db.Xads.Count(e => e.XadId == id) > 0;
        }
    }
}