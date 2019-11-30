using BootStrapProjectOne.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace BootStrapProjectOne.Controllers
{
    
    
    public class FAQController : Controller
    {
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
            ViewData["Answers"] = lstAnswers;
            return View(lstQuestions);
        }

        [HttpGet]
        public ActionResult CreateFaq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFaq(Question oQuestion)
        {
            oQuestion.Question_ID = lstQuestions.Count + 1;
            ViewData["Answers"] = lstAnswers;

            if (ModelState.IsValid)
            {
                lstQuestions.Add(oQuestion);
                return View("Faq", lstQuestions);
            }
            else //If validation fails, we will essentially reload the AddQuestion page, with the errors thrown and displayed
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View(oQuestion);
            }
        }

        //Edit
        [HttpGet] //Display Edit form
        public ActionResult EditQuestion(int? iCode)
        {
            Question oQuestion = lstQuestions.Find(x => x.Question_ID == iCode);

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
        public ActionResult AddAnswer(int id)//returns question id
        {
            QuestionID = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddAnswer(Answer myAnswer, int id) //returns answer model and question id
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

            //int iQuestions = lstQuestions.Count();
            //var dictAnswers = new Dictionary<int, dynamic>();

            //for (int iCount = 0; iCount < iQuestions; iCount++ )
            //{
            //    dictAnswers.Add(iCount, public static List<Answer> dictListAnswers = new List<Answer>() );
                
            //}

            //array of lists. Each list is a list of the answers that belong to a given question.
        }
    }
}
