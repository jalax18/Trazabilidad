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
    public class SurdefsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Surdefs
        public IQueryable<Surdef> GetSurdefs()
        {
            return db.Surdefs;
        }

        // GET: api/Surdefs/5
        [ResponseType(typeof(Surdef))]
        public async Task<IHttpActionResult> GetSurdef(int id)
        {
            Surdef surdef = await db.Surdefs.FindAsync(id);
            if (surdef == null)
            {
                return NotFound();
            }

            return Ok(surdef);
        }

        // PUT: api/Surdefs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSurdef(int id, Surdef surdef)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != surdef.IdSurdef)
            {
                return BadRequest();
            }

            db.Entry(surdef).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurdefExists(id))
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

        // POST: api/Surdefs
        [ResponseType(typeof(Surdef))]
        public async Task<IHttpActionResult> PostSurdef(Surdef surdef)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Surdefs.Add(surdef);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = surdef.IdSurdef }, surdef);
        }

        // DELETE: api/Surdefs/5
        [ResponseType(typeof(Surdef))]
        public async Task<IHttpActionResult> DeleteSurdef(int id)
        {
            Surdef surdef = await db.Surdefs.FindAsync(id);
            if (surdef == null)
            {
                return NotFound();
            }

            db.Surdefs.Remove(surdef);
            await db.SaveChangesAsync();

            return Ok(surdef);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SurdefExists(int id)
        {
            return db.Surdefs.Count(e => e.IdSurdef == id) > 0;
        }
    }
}