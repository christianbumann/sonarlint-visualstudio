﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SonarLint.VisualStudio.Progress.Observation {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ProgressObserverResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ProgressObserverResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SonarLint.VisualStudio.Progress.ProgressObservation.ProgressObserverResources", typeof(ProgressObserverResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The current step is not part of the observed steps..
        /// </summary>
        internal static string NonObservedStepException {
            get {
                return ResourceManager.GetString("NonObservedStepException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The controller has finished and the observer can no longer be used..
        /// </summary>
        internal static string ObserverDisposedException {
            get {
                return ResourceManager.GetString("ObserverDisposedException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The controller instance is in invalid state. Expecting IProgressEvents steps to be set and IProgressEvents.Steps to be initialized..
        /// </summary>
        internal static string UnsupportedProgressControllerException {
            get {
                return ResourceManager.GetString("UnsupportedProgressControllerException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The IProgressEvents.Steps must be initialized..
        /// </summary>
        internal static string UnsupportedProgressEventsException {
            get {
                return ResourceManager.GetString("UnsupportedProgressEventsException", resourceCulture);
            }
        }
    }
}
