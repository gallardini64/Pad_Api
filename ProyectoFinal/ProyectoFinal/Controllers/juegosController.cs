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
  
    public class juegosController : ApiController
    {
        private videojuegosDBEntities db = new videojuegosDBEntities();

        [Route("api/juegos/BuscarPorGenero/{id:int}")]
        [HttpGet]
        public IQueryable<juegos> GetJuegosPorGenero(int id)
        {
            return db.juegos.Where(j => j.genero_id == id);
        }

        [Route("api/juegos/BuscarPorDistribuidor/{id:int}")]
        [HttpGet]
        public IQueryable<juegos> GetJuegosPorDistribuidor(int id)
        {
            return db.juegos.Where(j => j.distribuidor_id == id);
        }

        [Route("api/juegos/BuscarPorDesarrollador/{id:int}")]
        [HttpGet]
        public IQueryable<juegos> GetJuegosPorDesarrollador(int id)
        {
            return db.juegos.Where(j => j.desarrollador_id == id);
        }

        // GET: api/juegos
        public IQueryable<juegos> Getjuegos()
        {
            return db.juegos;
        }

        // GET: api/juegos/5
        [ResponseType(typeof(juegos))]
        public IHttpActionResult Getjuegos(int id)
        {
            juegos juegos = db.juegos.Find(id);
            if (juegos == null)
            {
                return NotFound();
            }

            return Ok(juegos);
        }

        // PUT: api/juegos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putjuegos(int id, juegos juegos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != juegos.juego_id)
            {
                return BadRequest();
            }

            db.Entry(juegos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!juegosExists(id))
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

        // POST: api/juegos
        [ResponseType(typeof(juegos))]
        public IHttpActionResult Postjuegos(juegos juegos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.juegos.Add(juegos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = juegos.juego_id }, juegos);
        }

        // DELETE: api/juegos/5
        [ResponseType(typeof(juegos))]
        public IHttpActionResult Deletejuegos(int id)
        {
            juegos juegos = db.juegos.Find(id);
            if (juegos == null)
            {
                return NotFound();
            }

            db.juegos.Remove(juegos);
            db.SaveChanges();

            return Ok(juegos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool juegosExists(int id)
        {
            return db.juegos.Count(e => e.juego_id == id) > 0;
        }
    }
}