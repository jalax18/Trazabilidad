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
    public class MpeclientesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Mpeclientes
        public IQueryable<Mpecliente> GetMpeclientes()
        {
            return db.Mpeclientes;
        }

        // GET: api/Mpeclientes/5
        [ResponseType(typeof(Mpecliente))]
        public async Task<IHttpActionResult> GetMpecliente(int id)
        {
            Mpecliente mpecliente = await db.Mpeclientes.FindAsync(id);
            if (mpecliente == null)
            {
                return NotFound();
            }

            return Ok(mpecliente);
        }

        // PUT: api/Mpeclientes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMpecliente(int id, Mpecliente mpecliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mpecliente.MpeclienteId)
            {
                return BadRequest();
            }

            db.Entry(mpecliente).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MpeclienteExists(id))
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

        // POST: api/Mpeclientes
        [ResponseType(typeof(Mpecliente))]
        public async Task<IHttpActionResult> PostMpecliente(Mpecliente mpecliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mpeclientes.Add(mpecliente);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mpecliente.MpeclienteId }, mpecliente);
        }

        // DELETE: api/Mpeclientes/5
        [ResponseType(typeof(Mpecliente))]
        public async Task<IHttpActionResult> DeleteMpecliente(int id)
        {
            Mpecliente mpecliente = await db.Mpeclientes.FindAsync(id);
            if (mpecliente == null)
            {
                return NotFound();
            }

            db.Mpeclientes.Remove(mpecliente);
            await db.SaveChangesAsync();

            return Ok(mpecliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MpeclienteExists(int id)
        {
            return db.Mpeclientes.Count(e => e.MpeclienteId == id) > 0;
        }
    }
}