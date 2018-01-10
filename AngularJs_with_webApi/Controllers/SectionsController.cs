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
using AngularJs_with_webApi.Models;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AngularJs_with_webApi.Controllers
{
    public class SectionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [ResponseType(typeof(List<Section>))]
        // GET: api/Sections
        public HttpResponseMessage GetSection()
        {
            var obj = db.Sections.Include(mbox=>mbox.Department).ToList();
            //foreach (var item in obj)
            //{
            //    item.Department = db.Department.Find(item.Department_id);
            //}
            return Request.CreateResponse(HttpStatusCode.OK, obj);
        }      

     

        // GET: api/Sections/5
        [ResponseType(typeof(Section))]
        public IHttpActionResult GetSection(int id)
        {
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return NotFound();
            }

            return Ok(section);
        }

        // PUT: api/Sections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSection(int id, Section section)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != section.Section_id)
            {
                return BadRequest();
            }

            db.Entry(section).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionExists(id))
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

        // POST: api/Sections
        [ResponseType(typeof(Section))]
        public IHttpActionResult PostSection(Section section)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sections.Add(section);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = section.Section_id }, section);
        }

        // DELETE: api/Sections/5
        [ResponseType(typeof(Section))]
        public IHttpActionResult DeleteSection(int id)
        {
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return NotFound();
            }

            db.Sections.Remove(section);
            db.SaveChanges();

            return Ok(section);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SectionExists(int id)
        {
            return db.Sections.Count(e => e.Section_id == id) > 0;
        }
    }
}