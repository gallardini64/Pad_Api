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
    public class generosController : ApiController
    {
        private videojuegosDBEntities db = new videojuegosDBEntities();

        

        // GET: api/generos
        public IQueryable<generos> Getgeneros()
        {
            return db.generos;
        }

        // GET: api/generos/5
        [ResponseType(typeof(generos))]
        public IHttpActionResult Getgeneros(int id)
        {
            generos generos = db.generos.Find(id);
            if (generos == null)
            {
                return NotFound();
            }

            return Ok(generos);
        }

        // PUT: api/generos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putgeneros(int id, generos generos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != generos.genero_id)
            {
                return BadRequest();
            }

            db.Entry(generos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!generosExists(id))
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

        // POST: api/generos
        [ResponseType(typeof(generos))]
        public IHttpActionResult Postgeneros(generos generos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.generos.Add(generos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = generos.genero_id }, generos);
        }

        // DELETE: api/generos/5
        [ResponseType(typeof(generos))]
        public IHttpActionResult Deletegeneros(int id)
        {
            generos generos = db.generos.Find(id);
            if (generos == null)
            {
                return NotFound();
            }

            db.generos.Remove(generos);
            db.SaveChanges();

            return Ok(generos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool generosExists(int id)
        {
            return db.generos.Count(e => e.genero_id == id) > 0;
        }
    }
}