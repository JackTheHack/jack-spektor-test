
using System.Web;
using System.Web.Optimization;

namespace NumberHumanizer
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Assets/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/libs")
                    .Include("~/Assets/js/jquery-{version}.js")
                    .Include("~/Assets/js/jquery.validate*")
                    .Include("~/Assets/js/modernizr-*")
                    .Include("~/Assets/js/bootstrap.js", "~/Assets/js/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include("~/Assets/js/app.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Assets/css/bootstrap.css",
                      "~/Assets/css/styles.css"));
        }
    }
}
