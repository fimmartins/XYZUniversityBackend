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
using MecWebApi.Models;
using MecWebApi.Context;

namespace MECWebApi.Controller
{
    public class MECCoursesController : ApiController
    {
        private CoursesDbContext db = new CoursesDbContext();

        // GET: api/MECCourses
        public IQueryable<MECCourses> GetMECCourses()
        {
            return db.MECCourses;
        }

        // GET: api/MECCourses/5
        [ResponseType(typeof(MECCourses))]
        public IHttpActionResult GetMECCourses(int id)
        {
            MECCourses mECCourses = db.MECCourses.Find(id);
            if (mECCourses == null)
            {
                return NotFound();
            }

            return Ok(mECCourses);
        }

        // POST: api/MECCourses
        [Route("api/MECCourses/create")]
        [ResponseType(typeof(MECCourses))]
        public IHttpActionResult PostMECCourses(MECCourses mECCourses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MECCourses.Add(mECCourses);
            db.SaveChanges();

            return Ok(mECCourses);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MECCoursesExists(int id)
        {
            return db.MECCourses.Count(e => e.CourseId == id) > 0;
        }
    }
}