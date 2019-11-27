using BootStrapProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapProjectOne.Controllers
{
    public class FinController : Controller
    {
        public static List<Student> lstaStudent = new List<Student>();
        // GET: Fin
        public ActionResult Index()
        {
            return View(lstaStudent);
        }

        [HttpGet]
        public ActionResult EditStudent(int sCode)
        {
            Student oStudent = lstaStudent.Find(x => x.StudID == sCode);
            return View(oStudent);
        }

        [HttpPost]
        public ActionResult EditStudent(Student myModel)
        {
            var obj = lstaStudent.FirstOrDefault(x =>
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

            return View("Index", lstaStudent);
        }

        [HttpGet]
        public ActionResult addStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addStudent(Student myaStudent)
        {
            if (ModelState.IsValid)
            {
                lstaStudent.Add(myaStudent);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(myaStudent);
            }
        }

        [HttpGet]
        public ActionResult DeleteStudent(int sCode)
        {
            Student oStudent = lstaStudent.Find(x => x.StudID == sCode);
            return View(oStudent);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student myModel)
        {
            var obj = lstaStudent.FirstOrDefault(x =>
            x.StudID == myModel.StudID);
            if (obj != null)
            {
                obj.StudID = myModel.StudID;
            }

            return View("Index", lstaStudent);
        }

    }
}