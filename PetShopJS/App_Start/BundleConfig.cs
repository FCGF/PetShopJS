using System.Collections.Generic;
using System.Web.Optimization;

namespace PetShopJS {
    public class BundleConfig {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {
            var jqueryBundle = new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.1.1.min.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/toastr.min.js");
            jqueryBundle.Orderer = new AsIsBundleOrderer();

            var valBundle = new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/cldr.js",
                        "~/Scripts/cldr/event.js",
                        "~/Scripts/cldr/supplemental.js",
                        "~/Scripts/globalize.js",
                        "~/Scripts/globalize/number.js",
                        "~/Scripts/globalize/date.js",
                        "~/Scripts/jquery.validate.globalize.min.js");
            valBundle.Orderer = new AsIsBundleOrderer();

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            var modernBundle = new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*");
            modernBundle.Orderer = new AsIsBundleOrderer();

            var bootBundle = new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/javascripts/bootstrap.min.js",
                      "~/Scripts/jquery.bootgrid.min.js",
                      "~/Scripts/respond.js");
            bootBundle.Orderer = new AsIsBundleOrderer();

            var cssBundle = new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/jquery.bootgrid.min.css",
                      "~/stylesheets/plugins/bootstrap-datepicker3.min.css",
                      "~/Content/toastr.css",
                      "~/Content/Site.css");
            cssBundle.Orderer = new AsIsBundleOrderer();

            bundles.Add(jqueryBundle);
            bundles.Add(valBundle);
            bundles.Add(modernBundle);
            bundles.Add(bootBundle);
            bundles.Add(cssBundle);
        }
    }

    public class AsIsBundleOrderer : IBundleOrderer {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files) {
            return files;
        }
    }

}
