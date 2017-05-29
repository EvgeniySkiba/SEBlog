using System.Web.Optimization;

namespace SeBlog.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {


            //jquery
            bundles.UseCdn = true;

            // jquery library bundle
            var jqueryBundle = new ScriptBundle("~/jquery", "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.2.min.js")
                                    .Include("~/Scripts/jquery-{version}.js");
            bundles.Add(jqueryBundle);



            // jQuery UI library bundle
            var jqueryUIBundle = new ScriptBundle("~/jqueryui", "http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.1/jquery-ui.min.js").Include("~/Scripts/jquery-ui-{version}.min.js");
            bundles.Add(jqueryUIBundle);

            //// my 
            bundles.Add(new ScriptBundle("~/js").Include(
                       "~/Scripts/admin.js"));

            bundles.Add(new ScriptBundle("~/app.js").Include(
                    "~/Scripts/app.js"));


            bundles.Add(new StyleBundle("~/Content/admin/css").Include(
                      "~/Content/themes/simple/admin.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/jquery-ui.css").Include(
                       "~/Content/themes/base/jquery-ui.css"));


            var jqueryValBundle = new ScriptBundle("~/jqueryval", "http://ajax.aspnetcdn.com/ajax/jquery.validate/1.10.0/jquery.validate.min.js")
                               .Include("~/Scripts/jquery.validate.js");
            bundles.Add(jqueryValBundle);

            // jquery unobtrusive validation library
            var jqueryUnobtrusiveValBundle = new ScriptBundle("~/jqueryunobtrusiveval", "http://ajax.aspnetcdn.com/ajax/mvc/3.0/jquery.validate.unobtrusive.min.js")
                                                .Include("~/Scripts/jquery.validate.unobtrusive.js");
            bundles.Add(jqueryUnobtrusiveValBundle);


            //// jqgrid            
            bundles.Add(new ScriptBundle("~/Scripts/jquery.jqGrid").Include(
                     "~/Scripts/jquery.jqGrid.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/i18n/grid.locale-en").Include(
                      "~/Scripts/i18n/grid.locale-en.js"));

            bundles.Add(new StyleBundle("~/Content/jquery.jqGrid/ui.jqgrid").Include(
                     "~/Content/jquery.jqGrid/ui.jqgrid.css"));

            bundles.Add(new StyleBundle("~/Content/themes/simple").Include(
                "~/Content/themes/simple/style.css"));
            ////tinymce
            bundles.Add(new ScriptBundle("~/Scripts/tinymce/jquery.tinymce").Include(
                     "~/Scripts/tinymce/jquery.tinymce.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/tinymce/tinymce.js").Include(
                    "~/Scripts/tinymce/tinymce.js"));


        }
    }
}