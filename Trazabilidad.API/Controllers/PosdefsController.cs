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
    public class PosdefsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Posdefs
        public IQueryable<Posdef> GetPosdefs()
        {
            return db.Posdefs;
        }

        // GET: api/Posdefs/5
        [ResponseType(typeof(Posdef))]
        public async Task<IHttpActionResult> GetPosdef(int id)
        {
            Posdef posdef = await db.Posdefs.FindAsync(id);
            if (posdef == null)
            {
                return NotFound();
            }

            return Ok(posdef);
        }

        // PUT: api/Posdefs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPosdef(int id, Posdef posdef)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != posdef.IdPosdef)
            {
                return BadRequest();
            }

            db.Entry(posdef).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosdefExists(id))
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

        // POST: api/Posdefs
        [ResponseType(typeof(Posdef))]
        public async Task<IHttpActionResult> PostPosdef(Posdef posdef)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Posdefs.Add(posdef);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = posdef.IdPosdef }, posdef);
        }

        // DELETE: api/Posdefs/5
        [ResponseType(typeof(Posdef))]
        public async Task<IHttpActionResult> DeletePosdef(int id)
        {
            Posdef posdef = await db.Posdefs.FindAsync(id);
            if (posdef == null)
            {
                return NotFound();
            }

            db.Posdefs.Remove(posdef);
            await db.SaveChangesAsync();

            return Ok(posdef);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PosdefExists(int id)
        {
            return db.Posdefs.Count(e => e.IdPosdef == id) > 0;
        }
    }
}