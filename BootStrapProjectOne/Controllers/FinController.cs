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
        // GET: IS
        public static List<Student> lstFINStudents = new List<Student>();
        // GET: Fin
        public ActionResult Index()
        {
            return View(lstFINStudents);
        }


        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student myaStudent)
        {
            if (ModelState.IsValid)
            {
                myaStudent.StudID = lstFINStudents.Count() + 1;
                lstFINStudents.Add(myaStudent);
                ViewBag.Student = myaStudent.fName + myaStudent.lName;
                return RedirectToAction("Index", "Fin");
            }
            else
            {
                return View(myaStudent);
            }
        }


        [HttpGet]
        public ActionResult EditStudent(int sCode)
        {
            Student oStudent = lstFINStudents.Find(x => x.StudID == sCode);
            return View(oStudent);
        }

        [HttpPost]
        public ActionResult EditStudent(Student myModel)
        {
            var obj = lstFINStudents.FirstOrDefault(x =>
            x.StudID == myModel.StudID);
            if (obj != null)
            {
                obj.StudID = myModel.StudID;
                obj.fName = myModel.fName;
                obj.lName = myModel.lName;
                obj.Major_ID = myModel.Major_ID;
                obj.Company = myModel.Company;
                obj.Experience = myModel.Experience;
                obj.Internship_Year = myModel.Internship_Year;

            }

            return View("Index", lstFINStudents);
        }


        [HttpGet]
        public ActionResult DeleteStudent(int sCode)
        {
            Student oStudent = lstFINStudents.Find(x => x.StudID == sCode);
            return View(oStudent);
        }


        [HttpPost]
        public ActionResult DeleteStudent(Student myModel, int sCode)
        {
            var obj2 = lstFINStudents.FirstOrDefault(x =>
            x.StudID == sCode);
            if (obj2 != null)
            {
                lstFINStudents.Remove(obj2);
            }

            return View("Index", lstFINStudents);
        }

    }
}