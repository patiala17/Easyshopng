using System.Web;
using System.Web.Optimization;

namespace GenericRepository
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-3.2.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/Adminjquery").Include(
    "~/Content/themes/Admin/js/plugins/charts/sparkline.min.js",
    "~/Content/themes/Admin/js/plugins/forms/uniform.min.js",
    "~/Content/themes/Admin/js/plugins/forms/select2.min.js",
    "~/Content/themes/Admin/js/plugins/forms/inputmask.js",
    "~/Content/themes/Admin/js/plugins/forms/autosize.js",
    "~/Content/themes/Admin/js/plugins/forms/inputlimit.min.js",
    "~/Content/themes/Admin/js/plugins/forms/listbox.js",
    "~/Content/themes/Admin/js/plugins/forms/multiselect.js",
    "~/Content/themes/Admin/js/plugins/forms/validate.min.js",
    "~/Content/themes/Admin/js/plugins/forms/tags.min.js",
    "~/Content/themes/Admin/js/plugins/forms/switch.min.js",
    "~/Content/themes/Admin/js/plugins/forms/uploader/plupload.queue.min.js",
    "~/Content/themes/Admin/js/plugins/forms/uploader/plupload.full.min.js",
    "~/Content/themes/Admin/js/plugins/forms/wysihtml5/wysihtml5.min.js",
    "~/Content/themes/Admin/js/plugins/forms/wysihtml5/toolbar.js",
    "~/Content/themes/Admin/js/plugins/interface/daterangepicker.js",
    "~/Content/themes/Admin/js/plugins/interface/fancybox.min.js",
    "~/Content/themes/Admin/js/plugins/interface/moment.js",
    "~/Content/themes/Admin/js/plugins/interface/jgrowl.min.js",
    "~/Content/themes/Admin/js/plugins/interface/datatables.min.js",
    "~/Content/themes/Admin/js/plugins/interface/colorpicker.js",
    "~/Content/themes/Admin/js/plugins/interface/fullcalendar.min.js",
    "~/Content/themes/Admin/js/plugins/interface/timepicker.min.js",
    "~/Content/themes/Admin/js/plugins/interface/collapsible.min.js",
    "~/Content/themes/Admin/js/bootstrap.min.js",
    "~/Content/themes/Admin/js/application.js"
    ));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

    

        }
    }
}