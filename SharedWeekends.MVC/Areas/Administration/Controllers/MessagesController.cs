namespace SharedWeekends.MVC.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    
    using SharedWeekends.Data;
    using SharedWeekends.Models;
    using SharedWeekends.MVC.Areas.Administration.ViewModels;

    public class MessagesController : AdminController
    {
        public MessagesController(IWeekendsData data)
            : base(data)
        {
        }

        // GET: Administration/Messages
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public JsonResult CreateMessage([DataSourceRequest] DataSourceRequest request, MessageViewModel message)
        {
            if (message != null && ModelState.IsValid)
            {
                var newMessage = new Message
                {
                    Content = message.Content,
                    Receiver = this.Data.Users.All().FirstOrDefault(u => u.UserName == message.Receiver),
                    Sender = message.Sender,
                    CreationDate = message.CreationDate,
                    IsRead = message.IsRead,
                    Subject = message.Subject,
                    CreatedOn = DateTime.Now
                };

                this.Data.Messages.Add(newMessage);
                this.Data.SaveChanges();

                message.Id = newMessage.Id;
            }

            return this.Json(new[] { message }.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ReadMessages([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.Data
                .Messages
                .All()
                .Project()
                .To<MessageViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [HttpPost]
        public JsonResult UpdateMessage([DataSourceRequest] DataSourceRequest request, MessageViewModel message)
        {
            var existingMessage = this.Data.Messages.All().FirstOrDefault(x => x.Id == message.Id);

            if (message != null && ModelState.IsValid)
            {
                existingMessage.Content = message.Content;
                existingMessage.Receiver = this.Data.Users.All().FirstOrDefault(u => u.UserName == message.Receiver);
                existingMessage.Sender = message.Sender;
                existingMessage.CreationDate = message.CreationDate;
                existingMessage.IsRead = message.IsRead;
                existingMessage.Subject = message.Subject;
                existingMessage.ModifiedOn = DateTime.Now;

                this.Data.SaveChanges();
            }

            return this.Json(new[] { message }.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteMessage([DataSourceRequest] DataSourceRequest request, MessageViewModel message)
        {
            var existingMessage = this.Data.Messages.All().FirstOrDefault(x => x.Id == message.Id);

            this.Data.Messages.Delete(existingMessage);
            this.Data.SaveChanges();

            return this.Json(new[] { message }, JsonRequestBehavior.AllowGet);
        }
    }
}