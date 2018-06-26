namespace AW.Web
{
    using System.Web.Optimization;
    using BundleTransformer.Core.Transformers;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            RegisterConstantsStyleBundles(bundles);
            RegisterCommonStyleBundles(bundles);
            RegisterControllersStyleBundles(bundles);
        }

        private static void RegisterConstantsStyleBundles(BundleCollection bundles)
        {
            var bundle = new StyleBundle("~/bundles/style/constants")
                .IncludeDirectory("~/Styles/Constants", "*.css", true)
                .IncludeDirectory("~/Styles/Constants", "*.less", true);
            AddStyleBundle(bundles, bundle);
        }

        private static void RegisterCommonStyleBundles(BundleCollection bundles)
        {
            var bundle = new StyleBundle("~/bundles/style/common")
                .IncludeDirectory("~/Styles/Common", "*.css", true)
                .IncludeDirectory("~/Styles/Common", "*.less", true);
            AddStyleBundle(bundles, bundle);
        }

        private static void RegisterControllersStyleBundles(BundleCollection bundles)
        {
            var bundle = new StyleBundle("~/bundles/style/controllers")
                .IncludeDirectory("~/Styles/Controllers", "*.css", true)
                .IncludeDirectory("~/Styles/Controllers", "*.less", true);
            AddStyleBundle(bundles, bundle);
        }

        private static void AddStyleBundle(BundleCollection bundles, Bundle bundle)
        {
            bundle.Transforms.Add(new StyleTransformer());
            bundle.Transforms.Add(new CssMinify());
            bundles.Add(bundle);
        }
    }
}
