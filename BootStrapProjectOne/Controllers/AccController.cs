using BootStrapProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapProjectOne.Controllers
{
    public class AccController : Controller
    {
       public static List<Student> lstStudents = new List<Student>();

        // GET: Acc
        public ActionResult Index()
        {
            return View(lstStudents);
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            Student oStudent = lstStudents.Find(x => x.StudID == id);
            return View(oStudent);
        }

        [HttpPost]
        public ActionResult EditStudent(Student myModel)
        {
            var obj = lstStudents.FirstOrDefault(x =>
            x.StudID == myModel.StudID);
            if (obj != null)
            {
                obj.StudID = myModel.StudID;
                obj.fName = myModel.fName;
                obj.lName = myModel.lName;
                obj.Internship_Year = myModel.Internship_Year;
                obj.Company = myModel.Company;
                obj.MAJOR_ID = myModel.MAJOR_ID;
                obj.Experience = myModel.Experience;
                //obj.Picture = myModel.Picture; test
            }

            return View("Index", lstStudents);
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student myStudent)
        {
            if (ModelState.IsValid)
            {
                myStudent.StudID = lstStudents.Count() + 1;
                lstStudents.Add(myStudent);
                ViewBag.Student = myStudent.fName + myStudent.lName;
                return RedirectToAction("Index", "Acc");
            }
            else
            {
                return View(myStudent);
            }
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            Student oStudent = lstStudents.Find(x => x.StudID == id);
            return View(oStudent);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student myModel)
        {
            var obj = lstStudents.FirstOrDefault(x =>
            x.StudID == myModel.StudID);
            if (obj != null)
            {
                lstStudents.Remove(obj);
            }

            return View("Index", lstStudents);
        }
    }
}