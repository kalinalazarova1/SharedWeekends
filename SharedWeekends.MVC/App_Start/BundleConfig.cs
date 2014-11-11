﻿using System.Web;
using System.Web.Optimization;

namespace SharedWeekends.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScriptBundles(bundles);
            RegisterStyleBundles(bundles);
            BundleTable.EnableOptimizations = true;
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.yeti.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
                      "~/Content/kendo/kendo.common.*",
                      "~/Content/kendo/kendo.bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/custom").Include(
                      "~/Content/site.css",
                      "~/Content/shop-item.css",
                      "~/Content/shop-homepage.css"
                ));
        }

        private static void RegisterScriptBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                //.Include("~/Scripts/jquery-{version}.js"));
                .Include("~/Scripts/kendo/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo")
                .Include("~/Scripts/kendo/kendo.all.min.js",
                        "~/Scripts/kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
        }
    }
}
