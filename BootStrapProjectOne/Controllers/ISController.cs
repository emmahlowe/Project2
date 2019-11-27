using BootStrapProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapProjectOne.Controllers
{
    public class ISController : Controller
    {
        // GET: IS
        public static List<Student> lstISStudent = new List<Student>();
        // GET: Fin
        public ActionResult Index()
        {
            return View(lstISStudent);
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
                myaStudent.StudID = lstISStudent.Count() + 1;
                lstISStudent.Add(myaStudent);
                ViewBag.Student = myaStudent.fName + myaStudent.lName;
                return RedirectToAction("Index", "IS");
            }
            else
            {
                return View(myaStudent);
            }
        }


        [HttpGet]
        public ActionResult EditStudent(int sCode)
        {
            Student oStudent = lstISStudent.Find(x => x.StudID == sCode);
            return View(oStudent);
        }

        [HttpPost]
        public ActionResult EditStudent(Student myModel)
        {
            var obj = lstISStudent.FirstOrDefault(x =>
            x.StudID == myModel.StudID);
            if (obj != null)
            {
                obj.StudID = myModel.StudID;
                obj.fName = myModel.fName;
                obj.lName = myModel.lName;
                obj.MAJOR_ID = myModel.MAJOR_ID;
                obj.Company = myModel.Company;
                obj.Experience = myModel.Experience;
                obj.Internship_Year = myModel.Internship_Year;

            }

            return View("Index", lstISStudent);
        }


        [HttpGet]
        public ActionResult DeleteStudent(int sCode)
        {
            Student oStudent = lstISStudent.Find(x => x.StudID == sCode);
            return View(oStudent);
        }


        [HttpPost]
        public ActionResult DeleteStudent(Student myModel, int sCode)
        {
            var obj2 = lstISStudent.FirstOrDefault(x =>
            x.StudID == sCode);
            if (obj2 != null)
            {
                lstISStudent.Remove(obj2);
            }

            return View("Index", lstISStudent);
        }
    }
}