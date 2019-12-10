using BootStrapProjectOne.DAL;
using BootStrapProjectOne.Models;
using System.Collections.Generic;
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
        
        
        //public ActionResult Faq()
        //{
        //    ViewData["Answers"] = lstAnswers;
        //    return View(lstQuestions);
        //}

        public ActionResult Faq()
        {
            IEnumerable<Question> Questions =
               db.Database.SqlQuery<Question>("SELECT Question_ID, sQuestion " +
                   "FROM Question ");

            IEnumerable<Answer> Answers =
               db.Database.SqlQuery<Answer>("SELECT Answer_ID, sAnswer, Question_ID " +
                   "FROM Answer ");
            //what is IEnumerable vs a list of answer objects?
            //How can I convert to a list of answer objects or how can I pass two IEnumerable back to the view and work with it in razor?
            ViewData["Answers"] = Answers;
            ViewData["Answers"] = lstAnswers;
            return View(Questions);
        }

        [HttpGet]
        public ActionResult CreateFaq()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult CreateFaq(Question oQuestion)
        //{
        //    oQuestion.Question_ID = lstQuestions.Count + 1;
        //    ViewData["Answers"] = lstAnswers;

        //    if (ModelState.IsValid)
        //    {
        //        lstQuestions.Add(oQuestion);
        //        return View("Faq", lstQuestions);
        //    }
        //    else //If validation fails, we will essentially reload the AddQuestion page, with the errors thrown and displayed
        //    {
        //        var errors = ModelState.Values.SelectMany(v => v.Errors);
        //        return View(oQuestion);
        //    }
        //}

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
            Question oQuestion = lstQuestions.Find(x => x.Question_ID == sCode);

            return View(oQuestion);
        }

        [HttpPost]
        public ActionResult EditQuestion(Question thisModel)
        {
            var obj = lstQuestions.FirstOrDefault(x => x.Question_ID == thisModel.Question_ID); //We set this object obj equal to the Question_ID it finds in the list

            if (obj != null)
            {
                if (ModelState.IsValid)
                {
                    obj.Question_ID = thisModel.Question_ID;
                    obj.sQuestion = thisModel.sQuestion;
                }
                else
                {
                    return RedirectToAction("Faq", "FAQ");
                }
            }
            ViewData["Answers"] = lstAnswers;
            return RedirectToAction("Faq", "FAQ");
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
        public ActionResult AddAnswer(Answer myAnswer, int sCode) //returns answer model and question id
        {
            if (myAnswer.sAnswer != null)
            {
                Answer oAnswer = myAnswer;
                oAnswer.Question_ID = QuestionID;
                oAnswer.Answer_ID = lstAnswers.Count() + 1;
                lstAnswers.Add(oAnswer); //add answer to list 
                ViewData["Answers"] = lstAnswers; //passing data to the view
                return View("Faq", lstQuestions);
            }
            else
            {
                return View();
            }
            
        }
    }
}
