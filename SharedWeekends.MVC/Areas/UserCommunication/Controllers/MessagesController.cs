namespace SharedWeekends.MVC.Areas.UserCommunication.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using SharedWeekends.Data;
    using SharedWeekends.Models;
    using SharedWeekends.MVC.Areas.UserCommunication.ViewModels;
    using SharedWeekends.MVC.Controllers;

    public class MessagesController : BaseController
    {
        public MessagesController(IWeekendsData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [ChildActionOnly]
        public ActionResult GetMessages()
        {
            var received = this.Data.Messages
                .All()
                .Where(m => m.Receiver.UserName == User.Identity.Name)
                .Project()
                .To<MessageViewModel>()
                .OrderByDescending(m => m.CreationDate)
                .ToList();

            return this.PartialView("_MessagesList", received);
        }

        [ChildActionOnly]
        public ActionResult GetSentMessages()
        {
            var sent = this.Data.Messages
                .All()
                .Where(m => m.Sender == User.Identity.Name)
                .Project()
                .To<MessageViewModel>()
                .OrderByDescending(m => m.CreationDate)
                .ToList();

            return this.PartialView("_SentMessagesList", sent);
        }

        public ActionResult MessageDetails(string id)
        {
            var msg = this.Data.Messages
                .All()
                .Project()
                .To<MessageViewModel>()
                .FirstOrDefault(m => m.Id == id);

            var dbMsg = this.Data.Messages.All().FirstOrDefault(m => m.Id.ToString() == id);
            dbMsg.IsRead = true;
            this.Data.SaveChanges();

            return this.PartialView("_MessageDetails", msg);
        }

        [ChildActionOnly]
        public ActionResult CreateMessageForm()
        {
            return this.PartialView("_CreateMessage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MessageViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var msg = new Message();
                msg.Content = model.Content;
                msg.Subject = model.Subject;
                msg.CreationDate = DateTime.Now;
                msg.IsRead = false;
                msg.Sender = User.Identity.Name;
                msg.ReceiverId = Data.Users.All().FirstOrDefault(u => u.UserName == model.Receiver).Id;
                this.Data.Messages.Add(msg);
                this.Data.SaveChanges();
            }

            return this.RedirectToAction("Index");
        }
    }
}