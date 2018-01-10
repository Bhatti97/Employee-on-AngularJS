using AngularJs_with_webApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJs_with_webApi.Controllers
{
    public class Mvc_CompanyController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Mvc_Company
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetSection()
        {
            var sec = db.Sections.ToList();
            return Json(sec, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetEmployee()
        {
            var sec = db.Employee.ToList();
            return Json(sec, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetMaxEmployee()
        {
            var sec = db.Employee.Max(m=>m.Employee_id);
            return Json(sec, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetEmployee_Education(int? id)
        {
            var sec = db.Employee_Education.Where(m=>m.Employee_id==id).ToList();
            return Json(sec, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetEmployee_Experience(int id)
        {
            var sec = db.Experience.Where(m => m.Employee_id == id).ToList();
            return Json(sec, JsonRequestBehavior.AllowGet);
        }
    }
}