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
    public class reviewsController : ApiController
    {
        private after12Entities db = new after12Entities();

        // GET: api/reviews
        public IQueryable<reviews> Getreviews()
        {
            return db.reviews;
        }

        // GET: api/reviews/5
        [ResponseType(typeof(List<reviews>))]
        public List<reviews> Getreviews(int id)
        {
            List<reviews> list = (from n in db.reviews where n.pid == id select n).ToList();
            return list;
        }

        // PUT: api/reviews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putreviews(int id, reviews reviews)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reviews.rid)
            {
                return BadRequest();
            }

            db.Entry(reviews).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reviewsExists(id))
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

        // POST: api/reviews
        [ResponseType(typeof(reviews))]
        public IHttpActionResult Postreviews(reviews reviews)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.reviews.Add(reviews);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (reviewsExists(reviews.rid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = reviews.rid }, reviews);
        }

        // DELETE: api/reviews/5
        [ResponseType(typeof(reviews))]
        public IHttpActionResult Deletereviews(int id)
        {
            reviews reviews = db.reviews.Find(id);
            if (reviews == null)
            {
                return NotFound();
            }

            db.reviews.Remove(reviews);
            db.SaveChanges();

            return Ok(reviews);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool reviewsExists(int id)
        {
            return db.reviews.Count(e => e.rid == id) > 0;
        }
    }
}