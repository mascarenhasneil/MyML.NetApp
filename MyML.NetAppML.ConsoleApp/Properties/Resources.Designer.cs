// <auto-generated/>
namespace MyML_NetAppML.ConsoleApp.Properties {
    using System;
    using System.Reflection;
    using System.Resources;
    using System.Globalization;
    
    internal class Resources {
        private static ResourceManager resourceMan;
        private static CultureInfo resourceCulture;
        
        internal Resources() {}
        
        internal static ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    resourceMan = new ResourceManager("MyML_NetAppML.ConsoleApp.Resources", typeof(Resources).Assembly);
                }
                return resourceMan;
            }
        }
        
        internal static CultureInfo Culture {
            get { return resourceCulture; }
            set { resourceCulture = value; }
        }
        
        internal static string UsingModelToMakeSinglePrediction {
            get { return ResourceManager.GetString("UsingModelToMakeSinglePrediction", resourceCulture); }
        }
        internal static string EndOfProcessMessage {
            get { return ResourceManager.GetString("EndOfProcessMessage", resourceCulture); }
        }
        internal static string TrainingModel {
            get { return ResourceManager.GetString("TrainingModel", resourceCulture); }
        }
        internal static string EndOfTraining {
            get { return ResourceManager.GetString("EndOfTraining", resourceCulture); }
        }
        internal static string CrossValidating {
            get { return ResourceManager.GetString("CrossValidating", resourceCulture); }
        }
        internal static string SavingModel {
            get { return ResourceManager.GetString("SavingModel", resourceCulture); }
        }
        internal static string ModelSaved {
            get { return ResourceManager.GetString("ModelSaved", resourceCulture); }
        }
        internal static string MetricsHeader {
            get { return ResourceManager.GetString("MetricsHeader", resourceCulture); }
        }
        internal static string MetricsTitle {
            get { return ResourceManager.GetString("MetricsTitle", resourceCulture); }
        }
        internal static string MetricsSeparator {
            get { return ResourceManager.GetString("MetricsSeparator", resourceCulture); }
        }
        internal static string MetricsFooter {
            get { return ResourceManager.GetString("MetricsFooter", resourceCulture); }
        }
        internal static string FoldsHeader {
            get { return ResourceManager.GetString("FoldsHeader", resourceCulture); }
        }
        internal static string FoldsTitle {
            get { return ResourceManager.GetString("FoldsTitle", resourceCulture); }
        }
        internal static string FoldsSeparator {
            get { return ResourceManager.GetString("FoldsSeparator", resourceCulture); }
        }
        internal static string FoldsFooter {
            get { return ResourceManager.GetString("FoldsFooter", resourceCulture); }
        }
    }
}
