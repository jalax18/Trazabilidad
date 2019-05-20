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
    public class MacserverdefsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Macserverdefs
        public IQueryable<Macserverdef> GetMacserverdefs()
        {
            return db.Macserverdefs;
        }

        // GET: api/Macserverdefs/5
        [ResponseType(typeof(Macserverdef))]
        public async Task<IHttpActionResult> GetMacserverdef(int id)
        {
            Macserverdef macserverdef = await db.Macserverdefs.FindAsync(id);
            if (macserverdef == null)
            {
                return NotFound();
            }

            return Ok(macserverdef);
        }

        // PUT: api/Macserverdefs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMacserverdef(int id, Macserverdef macserverdef)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != macserverdef.Idmacserve)
            {
                return BadRequest();
            }

            db.Entry(macserverdef).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MacserverdefExists(id))
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

        // POST: api/Macserverdefs
        [ResponseType(typeof(Macserverdef))]
        public async Task<IHttpActionResult> PostMacserverdef(Macserverdef macserverdef)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Macserverdefs.Add(macserverdef);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = macserverdef.Idmacserve }, macserverdef);
        }

        // DELETE: api/Macserverdefs/5
        [ResponseType(typeof(Macserverdef))]
        public async Task<IHttpActionResult> DeleteMacserverdef(int id)
        {
            Macserverdef macserverdef = await db.Macserverdefs.FindAsync(id);
            if (macserverdef == null)
            {
                return NotFound();
            }

            db.Macserverdefs.Remove(macserverdef);
            await db.SaveChangesAsync();

            return Ok(macserverdef);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MacserverdefExists(int id)
        {
            return db.Macserverdefs.Count(e => e.Idmacserve == id) > 0;
        }
    }
}