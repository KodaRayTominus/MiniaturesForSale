﻿using System;
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

            if(User.Identity.GetUserId() != null)
            {
                myModel.User = ApplicationUserDB.GetApplicationUserById(User.Identity.GetUserId());
                myModel.NewMessage.SenderID = myModel.User.Id;
                myModel.NewMessage.Sender = myModel.User;
                messageToSend.SenderID = myModel.User.Id;

            }

            if(myModel.RecipientName != null)
            {

                ApplicationUser Recipient = ApplicationUserDB.GetApplicationUserByUserName(myModel.RecipientName);
                myModel.NewMessage.RecipientID = Recipient.Id;
                myModel.NewMessage.Recipient = Recipient;
                messageToSend.RecipientID = Recipient.Id;

            }
            ModelState.Clear();
            TryValidateModel(myModel);
            if (ModelState.IsValid)
            {
                messageToSend.Message = myModel.NewMessage.Message;
                messageToSend.Title = myModel.NewMessage.Title;
                messageToSend.Read = false;
                db.PersonalMessages.Add(messageToSend);
                db.SaveChanges();
                myModel.Messages = MessageDB.GetAllMessageForUserById(myModel.User.Id);
                return RedirectToAction("Messages", "Person", new { id = myModel.User.Id });
            }

            if (myModel.User == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(myModel.User.Id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(myModel);
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
