using MiniaturesRUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniaturesRUs.Controllers
{
    public class HomeController : Controller
    {

        //this code is used to set up a controller for access to the blob storage
        //BlobUtility utility;
        //ApplicationDbContext db;
        //string AccountName = "theminimanministorage";
        //string AccountKey = "g+8G7x8TSsURgscb8NLPmRPEr5/668fkH8l+MHFfjIzwJpCgAeL9B9+zIRAN2KsdM35Bg0jtrNv6wj0NDUiR+A==";
        //public HomeController()
        //{
        //    utility = new BlobUtility(AccountName, AccountKey);
        //    db = new ApplicationDbContext();
        //}

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