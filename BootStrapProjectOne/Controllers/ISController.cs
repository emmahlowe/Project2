using BootStrapProjectOne.DAL;
using BootStrapProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapProjectOne.Controllers
{
    public class ISController : Controller
    {
        private Project2Context db = new Project2Context();
        // GET: IS
        public static List<Student> lstISStudent = new List<Student>();
        // GET: Fin
        public ActionResult Index()
        {
            IEnumerable<Student> Students =
                db.Database.SqlQuery<Student>("SELECT StudID, fName, lName, Company, Student.Major_ID, Experience, Internship_Year " +
                    "FROM Student INNER JOIN Major on Student.Major_ID = Major.Major_ID " +
                     "WHERE Major_Desc = 'Information Systems' " +
                     "ORDER BY Student.lName, Student.fName ");

            return View(Students);
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent([Bind(Include = "StudID, fName, lName, Major_ID, Company, Experience, Internship_Year")] Student students)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(students).State = EntityState.Added;
                db.Students.Add(students);
                db.SaveChanges();
                return RedirectToAction("Index", "IS");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditStudent(int? sCode)
        {
            if (sCode != null)
            {
                IEnumerable<Student> students = //we are creating a collection of student_major model objects or a collection of data 
                                db.Database.SqlQuery<Student>("SELECT Student.StudID, Student.fName, " +
                "Student.lName, Student.Major_ID, Student.Company, Student.Experience, Student.Internship_Year " +
                "FROM Student " +
                "WHERE Student.StudID = " + sCode);
                return View(students.FirstOrDefault());
            }
            else
            {
                return RedirectToAction("Index", "Student");
            }
        }
       
        [HttpPost]
        public ActionResult EditStudent([Bind(Include = "StudID, fName, lName, Major_ID, Company, Experience, Internship_Year")] Student students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        
        [HttpGet]
        public ActionResult DeleteStudent(int sCode)
        {
            IEnumerable<Student> students = //we are creating a collection of student_major model objects or a collection of data 
                                db.Database.SqlQuery<Student>("SELECT Student.StudID, Student.fName, " +
                "Student.lName, Student.Major_ID, Student.Company, Student.Experience, Student.Internship_Year " +
                "FROM Student " +
                "WHERE Student.StudID = " + sCode);
            Student oStudent = students.FirstOrDefault();
            return View(oStudent);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student myModel, int? sCode)
        {
            if (sCode != null)
            {
                db.Database.ExecuteSqlCommand("DELETE FROM Student WHERE Student.StudID = " + sCode);
            }
            return RedirectToAction("Index");
        }
    }
}