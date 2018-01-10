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
using AutoMapper;

namespace AngularJs_with_webApi.Controllers
{
    public class Employee_EducationController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Employee_Education
        public IQueryable<Employee_Education> GetEmployee_Education()
        {
            return db.Employee_Education;
        }

        // GET: api/Employee_Education/5
        [ResponseType(typeof(Employee_Education))]
        public IHttpActionResult GetEmployee_Education(int id)
        {
            Employee_Education employee_Education = db.Employee_Education.Find(id);
            if (employee_Education == null)
            {
                return NotFound();
            }

            return Ok(employee_Education);
        }

        // PUT: api/Employee_Education/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee_Education(int id, Employee_Education employee_Education)
        {
            var obj = db.Employee_Education.Find(id);
            obj.Employee_Education_DegreeName = employee_Education.Employee_Education_DegreeName;
            obj.Employee_Education_DegreeYear = employee_Education.Employee_Education_DegreeYear;
            obj.Employee_Education_ObtainedMarks = employee_Education.Employee_Education_ObtainedMarks;
            obj.Employee_Education_Percentage = employee_Education.Employee_Education_Percentage;
            obj.Employee_Education_TotalMarks = employee_Education.Employee_Education_TotalMarks;
            obj.Employee_Education_University = employee_Education.Employee_Education_University;
            db.Entry(obj).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Employee_EducationExists(id))
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

        // POST: api/Employee_Education
        [ResponseType(typeof(Employee_Education))]
        public IHttpActionResult PostEmployee_Education(Employee_Education employee_Education)
        {
            
            employee_Education.Employee_id = db.Employee.Max(m => m.Employee_id);
            db.Employee_Education.Add(employee_Education);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee_Education.Employee_Education_id }, employee_Education);
        }

        // DELETE: api/Employee_Education/5
        [ResponseType(typeof(Employee_Education))]
        public IHttpActionResult DeleteEmployee_Education(int id)
        {
            Employee_Education employee_Education = db.Employee_Education.Find(id);
            if (employee_Education == null)
            {
                return NotFound();
            }

            db.Employee_Education.Remove(employee_Education);
            db.SaveChanges();

            return Ok(employee_Education);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Employee_EducationExists(int id)
        {
            return db.Employee_Education.Count(e => e.Employee_Education_id == id) > 0;
        }
    }
}