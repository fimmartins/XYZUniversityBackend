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
using CourseWebApi.Context;
using CourseWebApi.Models;
using System.Web.Http.Cors;
using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace CourseWebApi.Controllers
{
    public class CoursesController : ApiController
    {
        private CoursesDbContext db = new CoursesDbContext();

        // GET: api/Courses
        public IQueryable<Courses> GetCourses()
        {
            return db.Courses;
        }

        // GET: api/Courses/5
        [Authorize]
        [ResponseType(typeof(Courses))]
        public IHttpActionResult GetCourses(int id)
        {
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return NotFound();
            }

            return Ok(courses);
        }

        // PUT: api/Courses/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCourses(int id, Courses courses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courses.CourseId)
            {
                return BadRequest();
            }

            db.Entry(courses).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursesExists(id))
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

        private async Task<String> CallMEC(Courses course)
        {
            var client = new HttpClient();
            var mecC = new MECCourse();
            mecC.CourseId = course.CourseId;
            mecC.Name = course.Name;
            mecC.Institute = "XYZUniversity";
            string json = JsonConvert.SerializeObject(course);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync("http://localhost:10073/api/meccourses/create", content).Result;

            return await response.Content.ReadAsStringAsync();
        }

        // POST: api/Courses
        [Route("api/courses/create")]
        [Authorize(Roles = "Admin,RoleA")]
        [ResponseType(typeof(Courses))]
        public async Task<IHttpActionResult> PostCourses(Courses courses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Courses.Add(courses);
            db.SaveChanges();
            //check result later
            var result = await CallMEC(courses);
            return Ok(courses);
        }

        // DELETE: api/Courses/5
        [Authorize]
        [ResponseType(typeof(Courses))]
        public IHttpActionResult DeleteCourses(int id)
        {
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return NotFound();
            }

            db.Courses.Remove(courses);
            db.SaveChanges();

            return Ok(courses);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoursesExists(int id)
        {
            return db.Courses.Count(e => e.CourseId == id) > 0;
        }
    }
}