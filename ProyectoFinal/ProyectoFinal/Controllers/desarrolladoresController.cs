using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProyectoFinal;

namespace ProyectoFinal.Controllers
{
    public class desarrolladoresController : ApiController
    {
        private videojuegosDBEntities db = new videojuegosDBEntities();

        // GET: api/desarrolladores
        public IQueryable<desarrolladores> Getdesarrolladores()
        {
            return db.desarrolladores;
        }

        // GET: api/desarrolladores/5
        [ResponseType(typeof(desarrolladores))]
        public IHttpActionResult Getdesarrolladores(int id)
        {
            desarrolladores desarrolladores = db.desarrolladores.Find(id);
            if (desarrolladores == null)
            {
                return NotFound();
            }

            return Ok(desarrolladores);
        }

        // PUT: api/desarrolladores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdesarrolladores(int id, desarrolladores desarrolladores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != desarrolladores.desarrollador_id)
            {
                return BadRequest();
            }

            db.Entry(desarrolladores).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!desarrolladoresExists(id))
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

        // POST: api/desarrolladores
        [ResponseType(typeof(desarrolladores))]
        public IHttpActionResult Postdesarrolladores(desarrolladores desarrolladores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.desarrolladores.Add(desarrolladores);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = desarrolladores.desarrollador_id }, desarrolladores);
        }

        // DELETE: api/desarrolladores/5
        [ResponseType(typeof(desarrolladores))]
        public IHttpActionResult Deletedesarrolladores(int id)
        {
            desarrolladores desarrolladores = db.desarrolladores.Find(id);
            if (desarrolladores == null)
            {
                return NotFound();
            }

            db.desarrolladores.Remove(desarrolladores);
            db.SaveChanges();

            return Ok(desarrolladores);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool desarrolladoresExists(int id)
        {
            return db.desarrolladores.Count(e => e.desarrollador_id == id) > 0;
        }
    }
}