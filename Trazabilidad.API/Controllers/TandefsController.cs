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
    public class TandefsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Tandefs
        public IQueryable<Tandef> GetTandefs()
        {
            return db.Tandefs;
        }

        // GET: api/Tandefs/5
        [ResponseType(typeof(Tandef))]
        public async Task<IHttpActionResult> GetTandef(int id)
        {
            Tandef tandef = await db.Tandefs.FindAsync(id);
            if (tandef == null)
            {
                return NotFound();
            }

            return Ok(tandef);
        }

        // PUT: api/Tandefs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTandef(int id, Tandef tandef)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tandef.IdTandef)
            {
                return BadRequest();
            }

            db.Entry(tandef).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TandefExists(id))
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

        // POST: api/Tandefs
        [ResponseType(typeof(Tandef))]
        public async Task<IHttpActionResult> PostTandef(Tandef tandef)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tandefs.Add(tandef);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tandef.IdTandef }, tandef);
        }

        // DELETE: api/Tandefs/5
        [ResponseType(typeof(Tandef))]
        public async Task<IHttpActionResult> DeleteTandef(int id)
        {
            Tandef tandef = await db.Tandefs.FindAsync(id);
            if (tandef == null)
            {
                return NotFound();
            }

            db.Tandefs.Remove(tandef);
            await db.SaveChangesAsync();

            return Ok(tandef);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TandefExists(int id)
        {
            return db.Tandefs.Count(e => e.IdTandef == id) > 0;
        }
    }
}