using System.Web;
using System.Web.Optimization;

namespace StatisticsWeb.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //             "~/Scripts/jquery-1.11.1.js"));

            // bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            // bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //             "~/Scripts/modernizr-*"));

            // bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //             "~/Scripts/bootstrap.js",
            //             "~/Scripts/respond.js",
            //             "~/Scripts/bootstrap-slider.js"));

            // bundles.Add(new StyleBundle("~/Content/css").Include(
            //             "~/Content/bootstrap.css",
            //             "~/Content/site.css",
            //             "~/Content/bootstrap-slider.css"));


            Bundle jqueryBundle = new ScriptBundle("~/bundles/jquery")
               .Include("~/Scripts/jquery-{version}.js")
               .Include("~/Scripts/respond.js")
               .Include("~/Scripts/jquery.unobtrusive-ajax.min.js")
            .Include("~/AdminLTE/plugins/jQueryUI/jquery-ui.js");
            bundles.Add(jqueryBundle);

            Bundle jqueryValidateUnobtrusiveBundle = new ScriptBundle(
              "~/bundles/jqueryvalunobtrusive")
              .Include("~/Scripts/jquery.validate*");
            bundles.Add(jqueryValidateUnobtrusiveBundle);


            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //"~/Scripts/jquery-2.1.4.js",
            //"~/Scripts/jquery.unobtrusive-ajax.js",
            //"~/Scripts/jquery.validate*"));


            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //"~/Scripts/jquery-ui-1.11.4.js",
            //"~/Scripts/jquery-ui-1.10.4.custom.js"));



            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //    //"~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"
            //    //"~/Scripts/bootstrap-datepicker.js"
            //          ));

            //bundles.Add(new ScriptBundle("~/bundles/jsOthers")
            //    .Include("~/Scripts/gridmvc.min.js")
            //    .Include("~/AdminLTE/bootstrap/js/bootstrap.min.js")
            //    .Include("~/Scripts/lobibox.js")
            //    .Include("~/AdminLTE/dist/js/app.min.js")
            //    //.Include("~/Scripts/Gestion.js")
            //    );



            //bundles.Add(new ScriptBundle("~/bundles/jsAdminLTE")
            //   .Include("~/AdminLTE/plugins/morris/morris.min.js")
            //    .Include("~/AdminLTE/plugins/sparkline/jquery.sparkline.min.js")
            //    .Include("~/AdminLTE/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js")
            //    .Include("~/AdminLTE/plugins/jvectormap/jquery-jvectormap-world-mill-en.js")
            //    .Include("~/AdminLTE/plugins/knob/jquery.knob.js")
            //    //.Include("~/AdminLTE/plugins/iCheck/icheck.min.js")
            //    // .Include("~/AdminLTE/plugins/daterangepicker/daterangepicker.js")
            //    .Include("~/AdminLTE/plugins/datepicker/bootstrap-datepicker.js")
            //   //.Include("~/AdminLTE/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js")
            //   //.Include("~/AdminLTE/plugins/slimScroll/jquery.slimscroll.min.js")

            //   );

            //bundles.Add(new ScriptBundle("~/bundles/jsDataTable")
            //   .Include("~/AdminLTE/plugins/datatables/jquery.dataTables.min.js")
            //    .Include("~/AdminLTE/plugins/datatables/dataTables.bootstrap.min.js")
            //   );

            // Script bundle for the site. The fall-back scripts are for when a CDN fails, in this case we load a local
            // copy of the script instead.

            Bundle failoverCoreBundle = new ScriptBundle("~/bundles/site")
                //.Include("~/Scripts/Fallback/styles.js")
                //.Include("~/Scripts/Fallback/scripts.js")
                .Include("~/Scripts/site.js");
            bundles.Add(failoverCoreBundle);

            //,"~/Scripts/gridmvc.js", "~/Scripts/gridmvc.lang.es.js"

            // bundles.Add(new StyleBundle(
            //    "~/Content/css")
            //    .Include("~/AdminLTE/bootstrap/css/bootstrap.min.css")
            //    .Include("~/AdminLTE/dist/css/AdminLTE.min.css")
            //    .Include("~/Content/bootstrap-custom.css")
            //     .Include("~/Content/lobibox.css")
            //    .Include("~/AdminLTE/dist/css/skins/_all-skins.css")
            //    .Include("~/AdminLTE/plugins/fullcalendar/fullcalendar.min.css")
            //    .Include("~/AdminLTE/plugins/fullcalendar/fullcalendar.print.css")
            //    .Include("~/AdminLTE/plugins/datatables/dataTables.bootstrap.css")
            //    .Include("~/AdminLTE/plugins/iCheck/all.css")
            //    .Include("~/AdminLTE/plugins/morris/morris.css")
            //    .Include("~/AdminLTE/plugins/jvectormap/jquery-jvectormap-1.2.2.css")
            //    .Include("~/AdminLTE/plugins/datepicker/datepicker3.css")
            //    .Include("~/AdminLTE/plugins/timepicker/bootstrap-timepicker.css")
            //    .Include("~/AdminLTE/plugins/daterangepicker/daterangepicker-bs3.css")
            //    .Include("~/AdminLTE/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css")
            //    .Include("~/Content/Site.css")
            ////.Include("~/Content/bootstrap-datepicker.css")
            //.Include("~/Content/Gridmvc.css")
            //);


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-custom.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-responsive.min.css",
                      "~/css/dashboard.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/Gridmvc.css"));


        }





    }
}