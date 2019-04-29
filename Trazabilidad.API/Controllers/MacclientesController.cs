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
    public class MacclientesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Macclientes
        public IQueryable<Maccliente> GetMacclientes()
        {
            return db.Macclientes;
        }

        // GET: api/Macclientes/5
        [ResponseType(typeof(Maccliente))]
        public async Task<IHttpActionResult> GetMaccliente(int id)
        {
            Maccliente maccliente = await db.Macclientes.FindAsync(id);
            if (maccliente == null)
            {
                return NotFound();
            }

            return Ok(maccliente);
        }

        // PUT: api/Macclientes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMaccliente(int id, Maccliente maccliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maccliente.MacclienteId)
            {
                return BadRequest();
            }

            db.Entry(maccliente).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MacclienteExists(id))
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

        // POST: api/Macclientes
        [ResponseType(typeof(Maccliente))]
        public async Task<IHttpActionResult> PostMaccliente(Maccliente maccliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Macclientes.Add(maccliente);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = maccliente.MacclienteId }, maccliente);
        }

        // DELETE: api/Macclientes/5
        [ResponseType(typeof(Maccliente))]
        public async Task<IHttpActionResult> DeleteMaccliente(int id)
        {
            Maccliente maccliente = await db.Macclientes.FindAsync(id);
            if (maccliente == null)
            {
                return NotFound();
            }

            db.Macclientes.Remove(maccliente);
            await db.SaveChangesAsync();

            return Ok(maccliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MacclienteExists(int id)
        {
            return db.Macclientes.Count(e => e.MacclienteId == id) > 0;
        }
    }
}