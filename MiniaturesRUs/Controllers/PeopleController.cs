using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MiniaturesRUs.Models;

namespace MiniaturesRUs.Controllers
{
    public class PersonController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Person
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Person/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Person/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        //GET: Get inbox
        public ActionResult Messages(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            InboxViewModel myModel = new InboxViewModel();
            myModel.User = applicationUser;
            myModel.Messages = MessageDB.GetAllMessageForUserById(id);
            return View(myModel);
        }

        //POST:
        [HttpPost]
        public ActionResult Messages(InboxViewModel myModel)
        {
            PersonalMessage messageToSend = new PersonalMessage();

            //checks sender info and adds it too the message
            if(User.Identity.GetUserId() != null)
            {
                PersonalMessageHelper.ProcessSender(myModel, messageToSend, User.Identity.GetUserId());
            }

            //checks recipient info and adds it too the message
            if (myModel.RecipientName != null)
            {
                PersonalMessageHelper.ProcessRecipient(myModel, messageToSend);
            }
            ModelState.Clear();
            TryValidateModel(myModel);

            //checks if the model is valid, and finishes building the message
            //stores it in the DB to be grabbed
            //reloads the inbox
            if (ModelState.IsValid)
            {
                PersonalMessageHelper.ProcessBody(myModel, messageToSend);
                MessageDB.AddMessage(messageToSend);
                myModel.Messages = MessageDB.GetAllMessageForUserById(myModel.User.Id);
                return RedirectToAction("Messages", "Person", new { id = myModel.User.Id });
            }

            //checks if user is null and displays a error page
            if (myModel.User == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //reloads the page
            return View(myModel);
        }

        public ActionResult Message(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalMessage messageToView = MessageDB.GetMessageById(id);
            if(messageToView == null)
            {
                return HttpNotFound();
            }
            return View(messageToView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
