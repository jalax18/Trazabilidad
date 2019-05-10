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
    public class UltimasVersionesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/UltimasVersiones
        public IQueryable<UltimasVersiones> GetUltimasVersiones()
        {
            return db.UltimasVersiones;
        }

        // GET: api/UltimasVersiones/5
        [ResponseType(typeof(UltimasVersiones))]
        public async Task<IHttpActionResult> GetUltimasVersiones(int id)
        {
            UltimasVersiones ultimasVersiones = await db.UltimasVersiones.FindAsync(id);
            if (ultimasVersiones == null)
            {
                return NotFound();
            }

            return Ok(ultimasVersiones);
        }

        // PUT: api/UltimasVersiones/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUltimasVersiones(int id, UltimasVersiones ultimasVersiones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ultimasVersiones.IdVersiones)
            {
                return BadRequest();
            }

            db.Entry(ultimasVersiones).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UltimasVersionesExists(id))
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

        // POST: api/UltimasVersiones
        [ResponseType(typeof(UltimasVersiones))]
        public async Task<IHttpActionResult> PostUltimasVersiones(UltimasVersiones ultimasVersiones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UltimasVersiones.Add(ultimasVersiones);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ultimasVersiones.IdVersiones }, ultimasVersiones);
        }

        // DELETE: api/UltimasVersiones/5
        [ResponseType(typeof(UltimasVersiones))]
        public async Task<IHttpActionResult> DeleteUltimasVersiones(int id)
        {
            UltimasVersiones ultimasVersiones = await db.UltimasVersiones.FindAsync(id);
            if (ultimasVersiones == null)
            {
                return NotFound();
            }

            db.UltimasVersiones.Remove(ultimasVersiones);
            await db.SaveChangesAsync();

            return Ok(ultimasVersiones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UltimasVersionesExists(int id)
        {
            return db.UltimasVersiones.Count(e => e.IdVersiones == id) > 0;
        }
    }
}