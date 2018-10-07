using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniaturesRUs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "The Goal of this Website is to create an intuitive marketplace for people with the passion for Miniatures to come together and share and trade ideas while also selling their own master pieces.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "We would love to hear from you!";

            return View();
        }
    }
}