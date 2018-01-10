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

namespace AngularJs_with_webApi.Controllers
{
    public class ExperiencesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Experiences
        public IQueryable<Experience> GetExperience()
        {
            return db.Experience;
        }

        // GET: api/Experiences/5
        [ResponseType(typeof(Experience))]
        public IHttpActionResult GetExperience(int id)
        {
            Experience experience = db.Experience.Find(id);
            if (experience == null)
            {
                return NotFound();
            }

            return Ok(experience);
        }

        // PUT: api/Experiences/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExperience(int id, Experience experience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != experience.Experience_id)
            {
                return BadRequest();
            }
            var obj = db.Experience.Find(id);
            obj.Experience_Companyname = experience.Experience_Companyname;
            obj.Experience_End_Year = experience.Experience_End_Year;
            obj.Experience_Start_Year = experience.Experience_Start_Year;
            db.Entry(obj).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienceExists(id))
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

        // POST: api/Experiences
        [ResponseType(typeof(Experience))]
        public IHttpActionResult PostExperience(Experience experience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            experience.Employee_id = db.Employee.Max(m => m.Employee_id);
            db.Experience.Add(experience);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = experience.Experience_id }, experience);
        }

        // DELETE: api/Experiences/5
        [ResponseType(typeof(Experience))]
        public IHttpActionResult DeleteExperience(int id)
        {
            Experience experience = db.Experience.Find(id);
            if (experience == null)
            {
                return NotFound();
            }

            db.Experience.Remove(experience);
            db.SaveChanges();

            return Ok(experience);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExperienceExists(int id)
        {
            return db.Experience.Count(e => e.Experience_id == id) > 0;
        }
    }
}