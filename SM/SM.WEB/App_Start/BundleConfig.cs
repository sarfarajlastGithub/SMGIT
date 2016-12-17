using System.Web;
using System.Web.Optimization;

namespace SM.WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/skall").Include(
                     "~/Scripts/jquery-{version}.js",
                     "~/Scripts/jquery.unobtrusive*",
                     "~/Scripts/jquery.validate*"
                     ));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //This is For template purpose
            bundles.Add(new ScriptBundle("~/bundles/datatbl").Include(
                        "~/assets/lib/datatables/js/jquery.dataTables.min.js",
                        "~/assets/lib/datatables/js/dataTables.bootstrap.min.js"));

            //this is default set for template
            bundles.Add(new ScriptBundle("~/bundles/defaultjs").Include(
                        "~/assets/lib/jquery/jquery.min.js",
                        "~/assets/lib/perfect-scrollbar/js/perfect-scrollbar.jquery.min.js",
                        "~/assets/js/main.js",
                        "~/assets/lib/bootstrap/dist/js/bootstrap.min.js"));

            //this is default set for template
            bundles.Add(new ScriptBundle("~/bundles/formjs").Include(
                        "~/assets/lib/fuelux/js/wizard.js",
                        "~/assets/lib/select2/js/select2.min.js",
                        "~/assets/lib/bootstrap-slider/js/bootstrap-slider.js",
                        "~/assets/lib/jquery.nestable/jquery.nestable.js",
                        "~/assets/lib/moment.js/min/moment.min.js",
                        "~/assets/lib/datetimepicker/js/bootstrap-datetimepicker.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //this default css for template
            bundles.Add(new StyleBundle("~/Content/defaultcs").Include(
                      "~/assets/lib/perfect-scrollbar/css/perfect-scrollbar.min.css",
                      "~/assets/lib/material-design-icons/css/material-design-iconic-font.min.css"));

            //this if for Form
            bundles.Add(new StyleBundle("~/Content/formcs").Include(
                      "~/assets/lib/select2/css/select2.min.css",
                      "~/assets/lib/bootstrap-slider/css/bootstrap-slider.css",
                      "~/assets/lib/datetimepicker/css/bootstrap-datetimepicker.min.css"));

            //BundleTable.EnableOptimizations = true;

        }
    }
}
