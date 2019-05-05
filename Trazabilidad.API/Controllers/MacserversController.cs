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
    public class MacserversController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Macservers
        public IQueryable<Macserver> GetMacservers()
        {
            return db.Macservers;
        }

        // GET: api/Macservers/5
        [ResponseType(typeof(Macserver))]
        public async Task<IHttpActionResult> GetMacserver(int id)
        {
            Macserver macserver = await db.Macservers.FindAsync(id);
            if (macserver == null)
            {
                return NotFound();
            }

            return Ok(macserver);
        }

        

        // PUT: api/Macservers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMacserver(int id, Macserver macserver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != macserver.MacserverId)
            {
                return BadRequest();
            }

            db.Entry(macserver).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MacserverExists(id))
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

        // POST: api/Macservers
        [ResponseType(typeof(Macserver))]
        public async Task<IHttpActionResult> PostMacserver(Macserver macserver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Macservers.Add(macserver);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = macserver.MacserverId }, macserver);
        }

        // DELETE: api/Macservers/5
        [ResponseType(typeof(Macserver))]
        public async Task<IHttpActionResult> DeleteMacserver(int id)
        {
            Macserver macserver = await db.Macservers.FindAsync(id);
            if (macserver == null)
            {
                return NotFound();
            }

            db.Macservers.Remove(macserver);
            await db.SaveChangesAsync();

            return Ok(macserver);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MacserverExists(int id)
        {
            return db.Macservers.Count(e => e.MacserverId == id) > 0;
        }
    }
}