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
    public class categoriesController : ApiController
    {
        private after12Entities db = new after12Entities();

        // GET: api/categories
        // GET: api/categories
        public IQueryable<categories> Getcategories()
        {
            return db.categories;
        }

        // GET: api/categories/5
        [ResponseType(typeof(categories))]
        public IHttpActionResult Getcategories(int id)
        {
            categories categories = db.categories.Find(id);
            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        // PUT: api/categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcategories(int id, categories categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categories.cid)
            {
                return BadRequest();
            }

            db.Entry(categories).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categoriesExists(id))
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

        // POST: api/categories
        [ResponseType(typeof(categories))]
        public IHttpActionResult Postcategories(categories categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.categories.Add(categories);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (categoriesExists(categories.cid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = categories.cid }, categories);
        }

        // DELETE: api/categories/5
        [ResponseType(typeof(categories))]
        public IHttpActionResult Deletecategories(int id)
        {
            categories categories = db.categories.Find(id);
            if (categories == null)
            {
                return NotFound();
            }

            db.categories.Remove(categories);
            db.SaveChanges();

            return Ok(categories);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool categoriesExists(int id)
        {
            return db.categories.Count(e => e.cid == id) > 0;
        }
    }
}