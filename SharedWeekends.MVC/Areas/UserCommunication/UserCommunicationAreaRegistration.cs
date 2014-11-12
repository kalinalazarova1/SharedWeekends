using System.Web.Mvc;

namespace SharedWeekends.MVC.Areas.UserCommunication
{
    public class UserCommunicationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "UserCommunication";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "UserCommunication_default",
                "UserCommunication/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}