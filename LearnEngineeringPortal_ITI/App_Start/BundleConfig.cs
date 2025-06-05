using System.Web;
using System.Web.Optimization;

namespace TNDET 
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            //bundles.Add(new ScriptBundle("~/bundles/bootstrap", @"//ajax.aspnetcdn.com/ajax/jQuery/jquery-1.11.1.min.js").Include(
            //    "~/Scripts/jquery-1.11.1.min.js",
            //    "~/Scripts/bootstrap.js", "~/Scripts/jQuery.tmpl.js",
            //    "~/Scripts/Alert/sweetalert-dev.js"
            //         ));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //     "~/Content/bootstrap.min.css",
            //          "~/Content/bootstrap.css",
            //          "~/Scripts/Alert/alert_box.css",
            //          "~/css/font-awesome.min.css",
            //          "~/css/index.css"
            //          ));


            bundles.Add(new StyleBundle("~/Content/cssMainLayout").Include(
                //"~/Content/bootstrap.min.css",
                //"~/LE/css/bootstrap.css", //03/06/2025
                //"~/LE/css/bootstrap.min.css", //03/06/2025
                "~/Content/jquery-ui.css",
                //"~/Scripts/JQGridNew/jquery-ui.css",
                "~/Scripts/JQGridNew/ui.jqgrid.css",

                "~/CSS/simple-sidebar.css",

                "~/Scripts/Alert/alert_box.css",
                "~/css/font-awesome.min.css",
                "~/css/style.css"
                                      //"~/css/font1.css",
                                      //"~/css/font2.css"
                                     
             ));

            //bundles.Add(new ScriptBundle("~/bundles/JSMainLayout").Include(
            // //   "~/Scripts/jquery-1.11.1.min.js",
            //    "~/theme_v2/js_v2/jquery.min.js",
            //   "~/Scripts/jquery-ui.min.js",
            //     "~/Scripts/jquery.validate.min.js",
            //     "~/Scripts/JQGridNew/grid.locale-en.js",
            //     "~/Scripts/JQGridNew/jquery.jqGrid.min.js",
            //    "~/Scripts/bootstrap.min.js", "~/Scripts/jQuery.tmpl.js",
            //    "~/Scripts/Alert/sweetalert-dev.js",
            //    "~/Scripts/Common.js",
            //    "~/Scripts/jquery.cookie.js",
            //    "~/Scripts/themewaves.js",
            //     "~/Scripts/ToolTip.js",
            //     "~/Scripts/ProjectScript/CheckInProcess.js",
            //     "~/Scripts/loadingoverlay.min.js"

            //          ));

            bundles.Add(new StyleBundle("~/Content/cssAdminLayout").Include(
               "~/css/AdminCss/font-awesome.css",
               "~/css/AdminCss/AdminStyle.css",
               //"~/css/AdminCss/bootstrap.css",//03/06/2025
               "~/css/AdminCss/bootstrap-theme.css",             
               "~/Content/jquery-ui.css",
               "~/Scripts/JQGridNew/ui.jqgrid.css",
               "~/CSS/simple-sidebar.css",
               "~/Scripts/Alert/alert_box.css",
               //"~/Scripts/DataTable/dataTables.bootstrap.min.css",
               "~/Content/DataTables/DataTables-1.10.21/css/dataTables.bootstrap.min.css",
                "~/files/css/style-two.css",//03/06/2025
                "~/files/css/style.css" ,//03/06/2025
                "~/files/css/icon.css",//03/06/2025
                //"~/css/AdminCss/bootstrap.min.css"
                "~/Scripts/bootstrap.css"
              ));

            bundles.Add(new ScriptBundle("~/bundles/JSAdminLayout").Include(
                 //"~/Scripts/jquery-1.11.1.min.js",//03/06/2025
                 //"~/Scripts/jquery-1.12.4.min.js",//03/06/2025
                 "~/Scripts/jqueryui114/jquery-ui.min.js",//03/06/2025
                 "~/Scripts/jquery-3.7.1.min.js",
                 //"~/Scripts/jquery-ui.min.js",//03/06/2025 old
                 "~/Scripts/jquery.validate.min.js",
                 "~/Scripts/JQGridNew/grid.locale-en.js",
                 "~/Scripts/JQGridNew/jquery.jqGrid.min.js",
                 "~/Scripts/jQuery.tmpl.js",
                 "~/Scripts/Alert/sweetalert-dev.js",
                 "~/Scripts/Common.js",
                 "~/Scripts/jquery.cookie.js",
                 "~/Scripts/ToolTip.js",
                 "~/Scripts/ProjectScript/CheckInProcess.js",
                 "~/Scripts/loadingoverlay.min.js",
                 //"~/Scripts/DataTable/jquery.dataTables.min.js",
                 //"~/Scripts/DataTable/dataTables.bootstrap.js",
                 "~/Content/DataTables/DataTables-1.10.21/js/jquery.dataTables.js",
                 "~/Content/DataTables/DataTables-1.10.21/js/dataTables.bootstrap4.min.js",
                 "~/Scripts/bootstrap.min.js",//5.3.3 new
                 //"~/Scripts/bootstrap.bundle.min.js",
                 "~/Scripts/DataTable/bootstrap-multiselect.js"

   
            ));



        }
    }
}
