using SharedWeekends.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using SharedWeekends.MVC.ViewModels;
using SharedWeekends.Models;

namespace SharedWeekends.MVC.Controllers
{
    public class MessagesController : BaseController
    {
        public MessagesController(IWeekendsData data)
            : base(data)
        {
        }

        // GET: Messages
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult GetMessages()
        {
            var received = Data.Messages
                .All()
                .Where(m => m.Receiver.UserName == User.Identity.Name)
                .Project()
                .To<MessageViewModel>()
                .OrderByDescending(m => m.CreationDate)
                .ToList();

            return PartialView("_MessagesList", received);
        }

        [ChildActionOnly]
        public ActionResult GetSentMessages()
        {
            var sent = Data.Messages
                .All()
                .Where(m => m.Sender == User.Identity.Name)
                .Project()
                .To<MessageViewModel>()
                .OrderByDescending(m => m.CreationDate)
                .ToList();

            return PartialView("_SentMessagesList", sent);
        }

        public ActionResult MessageDetails(string id)
        {
            var msg = Data.Messages
                .All()
                .Project()
                .To<MessageViewModel>()
                .FirstOrDefault(m => m.Id == id);

            var dbMsg = Data.Messages.All().FirstOrDefault(m => m.Id.ToString() == id);
            dbMsg.IsRead = true;
            Data.SaveChanges();
            
            return PartialView("_MessageDetails", msg);
        }

        public ActionResult CreateMessageForm()
        {
            return PartialView("_CreateMessage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MessageViewModel model)
        {
            if(ModelState.IsValid)
            {
                var msg = new Message();
                msg.Content = model.Content;
                msg.Subject = model.Subject;
                msg.CreationDate = DateTime.Now;
                msg.IsRead = false;
                msg.Sender = User.Identity.Name;
                msg.ReceiverId = Data.Users.All().FirstOrDefault(u => u.UserName == model.Receiver).Id;
                Data.Messages.Add(msg);
                Data.SaveChanges();
            }

            return View();
        }
    }
}