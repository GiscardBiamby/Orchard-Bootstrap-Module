using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orchard;
using Orchard.UI.Resources;

namespace TheMonarch.bootstrap {

    public class ResourceManifest : IResourceManifestProvider {

        #region helpers

        private static string ThemeFolder = @"~/Themes/TheMonarch.bootstrap/";
        private static string ModuleFolder = @"~/Modules/TheMonarch.bootstrap/";
        private enum ResourceType { Scripts, Styles }
        private enum ResourceLocation { Module, Theme }
        
        private static string ModuleStyle(string path) {
            return GetResourcePath(path, ResourceType.Styles, ResourceLocation.Module);
        }

        private static string ModuleScript(string path) {
            return GetResourcePath(path, ResourceType.Scripts, ResourceLocation.Module);
        }

        private static string GetResourcePath(string path, ResourceType type, ResourceLocation loc) {
            if (path.StartsWith("/")) {
                path = path.Substring(1);
            }
            return string.Format("{0}{1}/{2}"
                , loc == ResourceLocation.Module ? ModuleFolder : ThemeFolder
                , type.ToString()
                , path
            );
        }

        #endregion helpers

        private readonly IOrchardServices _services;

        public ResourceManifest(IOrchardServices services) {
            _services = services;
        }

        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();

            //Styles
            manifest.DefineStyle("Monarch.Bootstrap")
                .SetUrl(ModuleStyle("bootstrap/less/bootstrap.css"));
            manifest.DefineStyle("Monarch.Bootstrap-responsive")
                .SetUrl(ModuleStyle("bootstrap/less/responsive.css"))
                .SetDependencies("Monarch.Bootstrap");
            manifest.DefineStyle("Monarch.Custom")
                .SetUrl(ModuleStyle("bootstrap/less/custom.min.css"), ModuleStyle("bootstrap/less/custom.css"));
            manifest.DefineStyle("Monarch.Custom.Responsive")
                .SetDependencies("Monarch.Custom")
                .SetUrl(ModuleStyle("bootstrap/less/custom.responsive.min.css"), ModuleStyle("bootstrap/less/custom.responsive.css"));


            // Scripts 
            manifest.DefineScript("Monarch.Bootstrap").SetUrl(ModuleScript("bootstrap.js")).SetVersion("2.0.2").SetDependencies("jQuery");
            manifest.DefineScript("Monarch.Bootstrap-alert").SetUrl(ModuleScript("plugins/bootstrap-alert.js")).SetVersion("2.0.2");
            manifest.DefineScript("Monarch.Bootstrap-button").SetUrl(ModuleScript("plugins/bootstrap-button.js")).SetVersion("2.0.2");
            manifest.DefineScript("Monarch.Bootstrap-carousel").SetUrl(ModuleScript("plugins/bootstrap-carousel.js")).SetVersion("2.0.2");
            manifest.DefineScript("Monarch.Bootstrap-collapse").SetUrl(ModuleScript("plugins/bootstrap-collapse.js")).SetVersion("2.0.2");
            manifest.DefineScript("Monarch.Bootstrap-dropdown").SetUrl(ModuleScript("plugins/bootstrap-dropdown.js")).SetVersion("2.0.2");
            manifest.DefineScript("Monarch.Bootstrap-modal").SetUrl(ModuleScript("plugins/bootstrap-modal.js")).SetVersion("2.0.2");
            manifest.DefineScript("Monarch.Bootstrap-popover").SetUrl(ModuleScript("plugins/bootstrap-popover.js")).SetVersion("2.0.2");
            manifest.DefineScript("Monarch.Bootstrap-scrollspy").SetUrl(ModuleScript("plugins/bootstrap-scrollspy.js")).SetVersion("2.0.2");
            manifest.DefineScript("Monarch.Bootstrap-tab").SetUrl(ModuleScript("plugins/bootstrap-tab.js")).SetVersion("2.0.2");
            manifest.DefineScript("Monarch.Bootstrap-tooltip").SetUrl(ModuleScript("plugins/bootstrap-tooltip.js")).SetVersion("2.0.2");
            manifest.DefineScript("Monarch.Bootstrap-transition").SetUrl(ModuleScript("plugins/bootstrap-transition.js")).SetVersion("2.0.2");
            manifest.DefineScript("Monarch.Bootstrap-typeahead").SetUrl(ModuleScript("plugins/bootstrap-typeahead.js")).SetVersion("2.0.2");
        }
    }
}
