using System.Web;
using System.Web.Optimization;

namespace TPV
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            //JS
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/sweetalert").Include(
                        "~/Scripts/sweetalert.min.js"));

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


            //CSS
            bundles.Add(new StyleBundle("~/Content/site").Include(
                        "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                        "~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                        "~/Content/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/PagedList").Include(
                        "~/Content/PagedList.css"));

            bundles.Add(new StyleBundle("~/Content/sweetalert").Include(
                        "~/Content/sweetalert.css"/*,
                        "~/Content/theme-swal.css"*/));

        }
    }
}