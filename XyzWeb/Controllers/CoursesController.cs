using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using XyzWeb.Models;

namespace XyzWeb.Controllers
{
    public class CoursesController : Controller
    {

        private async Task<String> GetCourses()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:10072/api/courses");
            return await response.Content.ReadAsStringAsync();
        }

        private async Task<String> CreateCourse(Course course)
        {
            var user = User as ClaimsPrincipal;
            var token = user.FindFirst("access_token").Value;
            var claims = user.Claims.ToString();

            var client = new HttpClient();
            client.SetBearerToken(token);
            string json = JsonConvert.SerializeObject(course);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync("http://localhost:10072/api/courses/create", content).Result;

            return await response.Content.ReadAsStringAsync();
        }

        [HttpPost]
        [Authorize]
        //[Authorize(Roles = "Admin, Standart")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CourseId,Name")]Course course)
        {
            try
            {
                ViewBag.Courses = await CreateCourse(course);
            }
            catch (Exception e)
            {
                ViewBag.Courses = e.Message;
            }
            return View("Index");
        }

        // GET: Courses
        public async Task<ActionResult> Index()
        {
            ViewBag.Courses = await GetCourses();
            return View();
        }

        // GET: Courses/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Courses/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        /*// POST: Courses/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                ViewBag.Courses = "post create";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/

        // GET: Courses/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Courses/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Courses/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Courses/Delete/5
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
