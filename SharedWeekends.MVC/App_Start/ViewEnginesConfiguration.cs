namespace SharedWeekends.MVC
{
    using System.Web.Mvc;

    public static class ViewEnginesConfiguration
    {
        public static void RegisterViewEngine(ViewEngineCollection engines)
        {
            engines.Clear();
            engines.Add(new RazorViewEngine());
        }
    }
}
