using BootStrapProjectOne.DAL;
using BootStrapProjectOne.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace BootStrapProjectOne.Controllers
{
    
    
    public class FAQController : Controller
    {
        private Project2Context db = new Project2Context();

        public static List<Answer> lstAnswers = new List<Answer>();
        public static int QuestionID;

        public static List<Question> lstQuestions = new List<Question>()
        {
            new Question{ Question_ID = 1, sQuestion = "What interested you in the first place about the company you interned for?" },
            new Question{ Question_ID = 2, sQuestion = "What was the hardest part about trying to decide which company to intern at?" },
            new Question{ Question_ID = 3, sQuestion = "What if I get an internship with a company and then decide that I don't like it?" }
        };



        public ActionResult Faq()
        {
            IEnumerable<Question> Questions =
               db.Database.SqlQuery<Question>("SELECT Question_ID, sQuestion " +
                   "FROM Question ");

            IEnumerable<Answer> Answers =
               db.Database.SqlQuery<Answer>("SELECT Answer_ID, sAnswer, Question_ID " +
                   "FROM Answer ");
            //var FAQs = db.MissionQuestions.Where(x => x.MissionID == mission.MissionID);
            lstAnswers.Clear();

            foreach(Answer element in Answers)
            {
                lstAnswers.Add(element);
            }
            
            ViewData["Answers"] = lstAnswers;
            return View(Questions);
        }

        [HttpGet]
        public ActionResult CreateFaq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFaq([Bind(Include = "Question_ID, sQuestion")] Question questions)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(questions);
                db.SaveChanges();
                return RedirectToAction("Faq");
            }
            else
            {
                return View();
            }
        }

        //Edit
        [HttpGet] //Display Edit form
        public ActionResult EditQuestion(int? sCode)
        {
            if (sCode != null)
            {
                IEnumerable<Question> questions = //we are creating a collection of student_major model objects or a collection of data 
                                db.Database.SqlQuery<Question>("SELECT Question_ID, sQuestion " +
                "FROM Question " +
                "WHERE Question_ID = " + sCode);
                return View(questions.FirstOrDefault());
            }
            else
            {
                return RedirectToAction("Faq");
            }
            //Question oQuestion = lstQuestions.Find(x => x.Question_ID == sCode);

            //return View(oQuestion);
        }
        [HttpPost]
        public ActionResult EditQuestion([Bind(Include = "Question_ID, sQuestion")] Question questions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Faq");
            }
            else
            {
                return View();
            }
        }

        public ActionResult FullWidth()
        {
            return View();
        }
        
        public ActionResult SideBar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddAnswer(int sCode)//returns question id
        {
            QuestionID = sCode;
            return View();
        }

        [HttpPost]
        public ActionResult AddAnswer(Answer answer)
        {
            var oAnswer = new Answer();
            oAnswer.Question_ID = QuestionID;
            oAnswer.sAnswer = answer.sAnswer;

             db.Answers.Add(oAnswer);
                db.SaveChanges();
                return RedirectToAction("Faq");
        }
    }
}
