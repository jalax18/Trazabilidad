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
    public class FpardiasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Fpardias
        public IQueryable<Fpardia> GetFpardias()
        {
            return db.Fpardias;
        }

        // GET: api/Fpardias/5
        [ResponseType(typeof(Fpardia))]
        public async Task<IHttpActionResult> GetFpardia(int id)
        {
            Fpardia fpardia = await db.Fpardias.FindAsync(id);
            if (fpardia == null)
            {
                return NotFound();
            }

            return Ok(fpardia);
        }

        // PUT: api/Fpardias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFpardia(int id, Fpardia fpardia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fpardia.IdFpardia)
            {
                return BadRequest();
            }

            db.Entry(fpardia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FpardiaExists(id))
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

        // POST: api/Fpardias
        [ResponseType(typeof(Fpardia))]
        public async Task<IHttpActionResult> PostFpardia(Fpardia fpardia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fpardias.Add(fpardia);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = fpardia.IdFpardia }, fpardia);
        }

        // DELETE: api/Fpardias/5
        [ResponseType(typeof(Fpardia))]
        public async Task<IHttpActionResult> DeleteFpardia(int id)
        {
            Fpardia fpardia = await db.Fpardias.FindAsync(id);
            if (fpardia == null)
            {
                return NotFound();
            }

            db.Fpardias.Remove(fpardia);
            await db.SaveChangesAsync();

            return Ok(fpardia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FpardiaExists(int id)
        {
            return db.Fpardias.Count(e => e.IdFpardia == id) > 0;
        }
    }
}