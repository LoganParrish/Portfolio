﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace Portfolio.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Conact/

        [HttpGet]
        public ActionResult Index()
        {
            return View(new Models.Contact());
        }

        //[HttpPost]
        //public ActionResult Index(Models.Contact contact)
        //{
        //    Models.ContactReportEntities db = new Models.ContactReportEntities();

        //    db.Contacts.Add(contact);

        //    db.SaveChanges();

        //    return RedirectToAction("ThankYou", "Contact");
        //}

        //new contact form post toi send me an email with the juice
        [HttpPost]
        public ActionResult Index(Models.Contact contact)
        {
            //sending an email 
            //step 1. using system.net.mail;
            //step 2 create a new message
            MailMessage message = new MailMessage("selfAwareWebsite@seedpaths.com", "logandanparrish@gmail.com");
            //step 3. Set the subject
            message.Subject = contact.firstName + " " + contact.lastName + " has sent you a message.";
            //step 4. construct the body with a stringbuilder
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("You have a new contact request.");
            sb.AppendLine("Name: " + contact.firstName + " " + contact.lastName);
            sb.AppendLine("Email: " + contact.email);
            sb.AppendLine("Message: " + contact.comment);
            sb.AppendLine("You're cute as ever,");
            sb.AppendLine("The Self Aware Website");
            //step 5. add the body to the message
            message.Body = sb.ToString();

            //step 6. Declare the SMTP client   ....   aka the mail server
            SmtpClient client = new SmtpClient("mail.dustinkraft.com", 587);
            client.Credentials = new System.Net.NetworkCredential("postmaster@dustinkraft.com", "techIsFun1");
            //step 7 send the message
            client.Send(message);
            //dun
            //KICK THEM SO HARD TO THE THANK YOU PAGE
            return RedirectToAction("ThankYou", "Contact");

        }

        public ActionResult ThankYou()
        {
            return View();
        }

    }
}
