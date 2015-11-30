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
    public class StudentController : Controller
    {
        private String GetCourses()
        {
            try
            {
                var client = new HttpClient();
                var response = client.GetAsync("http://localhost:10072/api/courses").Result;
                var responseContent = response.Content;
                return responseContent.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                ViewBag.Students = e.Message;
                return null;
            }
        }

        private String GetStudents()
        {
            try
            {
                var client = new HttpClient();
                var user = User as ClaimsPrincipal;
                if (user.Identity.IsAuthenticated) //if not auth, just call without token for init module and receive an error
                {
                    var token = user.FindFirst("access_token").Value;
                    client.SetBearerToken(token);
                }              
                var response = client.GetAsync("http://localhost:10070/api/students").Result;
                var responseContent = response.Content;
                return responseContent.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                ViewBag.Students = e.Message;
                return null;
            }
        }

        private void PopulateCoursesDropDownList(object selectedDepartment = null)
        {
            try
            {
                var response = GetCourses();
                String JsonStr = response.ToString();

                List<Course> courses = JsonConvert.DeserializeObject<List<Course>>(JsonStr);

                HttpContext.Application["CourseList"] = courses;

                ViewBag.CourseId = new SelectList
                    (
                        courses,
                        "CourseId",
                        "Name"
                    );
            }
            catch (Exception e)
            {
                ViewBag.Students = e.Message;
            }
        }

        // GET: Student
        public ActionResult Index()
        {
            try
            {
                ViewBag.Students =  GetStudents();
                PopulateCoursesDropDownList();
            }
            catch (Exception e)
            {
                ViewBag.Students = e.Message;
            }
            return View();
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            PopulateCoursesDropDownList();
            return View();
        }

        private String CreateStudent(Student student)
        {
            try
            {
                var client = new HttpClient();
                string json = JsonConvert.SerializeObject(student);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync("http://localhost:10070/api/students/create", content).Result;

                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                ViewBag.Students = e.Message;
                return "Index";
            }
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Student std = new Student();
                std.ConfirmPassword = Convert.ToString(collection["ConfirmPassword"]);
                std.Email = Convert.ToString(collection["Email"]);
                std.FirstName = Convert.ToString(collection["FirstName"]);
                std.LastName = Convert.ToString(collection["LastName"]);
                std.Password = Convert.ToString(collection["Password"]);
                std.Username = Convert.ToString(collection["Username"]);
                String CourseId = collection["CourseId"];

                List<Course> courseList = HttpContext.Application["CourseList"] as List<Course>;
                std.Course = courseList[Convert.ToInt32(CourseId) - 1];

                var res = CreateStudent(std);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Students = e.Message;
                return RedirectToAction("Index");
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
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
