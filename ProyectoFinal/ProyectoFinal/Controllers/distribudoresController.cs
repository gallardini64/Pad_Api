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
    public class distribudoresController : ApiController
    {
        private videojuegosDBEntities db = new videojuegosDBEntities();

        // GET: api/distribudores
        public IQueryable<distribudores> Getdistribudores()
        {
            return db.distribudores;
        }

        // GET: api/distribudores/5
        [ResponseType(typeof(distribudores))]
        public IHttpActionResult Getdistribudores(int id)
        {
            distribudores distribudores = db.distribudores.Find(id);
            if (distribudores == null)
            {
                return NotFound();
            }

            return Ok(distribudores);
        }

        // PUT: api/distribudores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdistribudores(int id, distribudores distribudores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != distribudores.distribuidor_id)
            {
                return BadRequest();
            }

            db.Entry(distribudores).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!distribudoresExists(id))
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

        // POST: api/distribudores
        [ResponseType(typeof(distribudores))]
        public IHttpActionResult Postdistribudores(distribudores distribudores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.distribudores.Add(distribudores);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = distribudores.distribuidor_id }, distribudores);
        }

        // DELETE: api/distribudores/5
        [ResponseType(typeof(distribudores))]
        public IHttpActionResult Deletedistribudores(int id)
        {
            distribudores distribudores = db.distribudores.Find(id);
            if (distribudores == null)
            {
                return NotFound();
            }

            db.distribudores.Remove(distribudores);
            db.SaveChanges();

            return Ok(distribudores);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool distribudoresExists(int id)
        {
            return db.distribudores.Count(e => e.distribuidor_id == id) > 0;
        }
    }
}