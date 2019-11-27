using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapProjectOne.Controllers
{
    public class AccController : Controller
    {
        // GET: Acc
        public ActionResult Index()
        {
            ViewBag.Student = "< div class='col-md-4 portfolio-item'> <a href = '@Url.Action('SingleItem','Portfolio')'> <img src = 'http://placehold.it/700x400' class='img-responsive'></a><h3> @Html.ActionLink('Project Name', 'SingleItem', 'Portfolio')</h3><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.Nam viverra euismod odio, gravida pellentesque urna varius vitae.</p> </div>";
            return View();
        }
    }
}