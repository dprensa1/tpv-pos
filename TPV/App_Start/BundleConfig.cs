using System.Web;
using System.Web.Optimization;

namespace TPV
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.*",
                        "~/Scripts/my.validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryMask").Include(
                        "~/Scripts/jquery.mask.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
        }
    }
}