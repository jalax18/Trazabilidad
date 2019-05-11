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
    public class ArtdefsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Artdefs
        public IQueryable<Artdef> GetArtdefs()
        {
            return db.Artdefs;
        }

        // GET: api/Artdefs/5
        [ResponseType(typeof(Artdef))]
        public async Task<IHttpActionResult> GetArtdef(int id)
        {
            Artdef artdef = await db.Artdefs.FindAsync(id);
            if (artdef == null)
            {
                return NotFound();
            }

            return Ok(artdef);
        }

        // PUT: api/Artdefs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArtdef(int id, Artdef artdef)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artdef.IdArtdef)
            {
                return BadRequest();
            }

            db.Entry(artdef).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtdefExists(id))
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

        // POST: api/Artdefs
        [ResponseType(typeof(Artdef))]
        public async Task<IHttpActionResult> PostArtdef(Artdef artdef)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Artdefs.Add(artdef);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = artdef.IdArtdef }, artdef);
        }

        // DELETE: api/Artdefs/5
        [ResponseType(typeof(Artdef))]
        public async Task<IHttpActionResult> DeleteArtdef(int id)
        {
            Artdef artdef = await db.Artdefs.FindAsync(id);
            if (artdef == null)
            {
                return NotFound();
            }

            db.Artdefs.Remove(artdef);
            await db.SaveChangesAsync();

            return Ok(artdef);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArtdefExists(int id)
        {
            return db.Artdefs.Count(e => e.IdArtdef == id) > 0;
        }
    }
}