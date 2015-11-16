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
using StudentWebApi.Models;
using StudentWebApi.Context;
using BrockAllen.MembershipReboot;
using System.ComponentModel.DataAnnotations;
using StudentWebApi.Entities;
using System.Web.Http.Cors;

namespace StudentWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudentsController : ApiController
    {
        private CustomDb db;
        private UserAccountService<CustomUserAccount> userAccountService;

        public StudentsController()
        {
            db = new CustomDb();
        }

        public StudentsController(UserAccountService<CustomUserAccount> userAccountService)
        {
            db = new CustomDb();
            this.userAccountService = userAccountService;
        }

        // GET: api/Students
        [Authorize]
        [Route("api/students")]
        public List<Student> GetStudents()
        {
            return db.Students.ToList();
        }

        // GET: api/Students/5
        [Authorize]
        [Route("api/students/get/{id}")]
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            Student Student = db.Students.Find(id);
            if (Student == null)
            {
                return NotFound();
            }

            return Ok(Student);
        }

        // PUT: api/Students/5
        [Authorize]
        [Route("api/students/update/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Student Student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Student.StudentId)
            {
                return BadRequest();
            }

            db.Entry(Student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Students
        [Route("api/students/create")]
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(RegisterInputModel model)
        {
            Student student = new Student();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var account = this.userAccountService.CreateAccount(model.Username, model.Password, model.Email);
                var findacc = db.Users.Find(account.Key);
                student.FirstName = model.FirstName;
                student.LastName = model.LastName;
                student.UserAccount = findacc;
                db.Students.Add(student);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(student.StudentId);
        }

        // DELETE: api/Students/5
        [Authorize]
        [Route("api/students/delete/{id}")]
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student Student = db.Students.Find(id);
            if (Student == null)
            {
                return NotFound();
            }

            db.Students.Remove(Student);
            db.SaveChanges();

            return Ok(Student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.StudentId == id) > 0;
        }
    }
}