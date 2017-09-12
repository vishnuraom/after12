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
using _12api.Models;

namespace _12api.Controllers
{
    public class placesController : ApiController
    {
        private after12Entities db = new after12Entities();
        // GET: api/places
        public IQueryable<places> Getplaces()
        {
            return db.places;
        }

        // GET: api/places/5
        [ResponseType(typeof(List<places>))]
        public List<places> Getplaces(int id)
        {
            List<places> list = (from n in db.places where n.cid == id select n).ToList();
            return list;
        }

        // PUT: api/places/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putplaces(int id, places places)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != places.pid)
            {
                return BadRequest();
            }

            db.Entry(places).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!placesExists(id))
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

        // POST: api/places
        [ResponseType(typeof(places))]
        public IHttpActionResult Postplaces(places places)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.places.Add(places);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (placesExists(places.pid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = places.pid }, places);
        }

        // DELETE: api/places/5
        [ResponseType(typeof(places))]
        public IHttpActionResult Deleteplaces(int id)
        {
            places places = db.places.Find(id);
            if (places == null)
            {
                return NotFound();
            }

            db.places.Remove(places);
            db.SaveChanges();

            return Ok(places);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool placesExists(int? id)
        {
            return db.places.Count(e => e.pid == id) > 0;
        }
    }
}