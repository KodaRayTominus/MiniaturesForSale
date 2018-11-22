using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.IO;
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

        //this code is used to set up a controller for access to the blob storage
        BlobUtility utility;
        string AccountName = "theminimanministorage";
        string AccountKey = "g+8G7x8TSsURgscb8NLPmRPEr5/668fkH8l+MHFfjIzwJpCgAeL9B9+zIRAN2KsdM35Bg0jtrNv6wj0NDUiR+A==";

        public PersonController()
        {
            utility = new BlobUtility(AccountName, AccountKey);
        }

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

        public ActionResult UserImages()
        {
            string loggedInUserId = User.Identity.GetUserId();
            List<UserImage> userImages = (from r in db.UserImages where r.UserId == loggedInUserId select r).ToList();
            ViewBag.PhotoCount = userImages.Count;
            return View(userImages);
        }

        public ActionResult DeleteImage(string id)
        {
            UserImage userImage = db.UserImages.Find(id);
            db.UserImages.Remove(userImage);
            db.SaveChanges();
            string BlobNameToDelete = userImage.ImageUrl.Split('/').Last();
            utility.DeleteBlob(BlobNameToDelete, "jsr");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string ContainerName = "jsr"; //hardcoded container name. 
                file = file ?? Request.Files["file"];
                string fileName = Path.GetFileName(file.FileName);
                Stream imageStream = file.InputStream;
                var result = utility.UploadBlob(fileName, ContainerName, imageStream);
                if (result != null)
                {
                    string loggedInUserId = User.Identity.GetUserId();
                    UserImage userimage = new UserImage();
                    userimage.Id = new Random().Next().ToString();
                    userimage.UserId = loggedInUserId;
                    userimage.ImageUrl = result.Uri.ToString();
                    db.UserImages.Add(userimage);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }


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
