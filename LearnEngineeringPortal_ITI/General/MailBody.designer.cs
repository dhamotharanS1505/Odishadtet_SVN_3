//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option or rebuild the Visual Studio project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class MailBody {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MailBody() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.MailBody", global::System.Reflection.Assembly.Load("App_GlobalResources"));
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
        ///   Looks up a localized string similar to &lt;!DOCTYPE HTML &gt;
        ///&lt;html&gt;
        /// &lt;head&gt;
        ///  &lt;TITLE&gt;Password Changed | Learnengg.com &lt;/TITLE&gt;
        /// &lt;/head&gt;
        ///
        /// &lt;body&gt;
        ///&lt;table&gt;
        ///  &lt;thead&gt;
        ///    &lt;tr&gt;
        ///      &lt;td&gt; Hi #name#, &lt;/td&gt;
        ///    &lt;/tr&gt;
        ///  &lt;/thead&gt;
        ///  &lt;tbody&gt;
        ///    &lt;tr&gt;
        ///      &lt;td&gt; 
        ///        Password successfully changed
        ///        Your new Learnengg.com password for the account #name# has been set.
        ///        
        ///        You can now access your account, view your subjects or change your account settings. 
        ///        &lt;/td&gt;
        ///    &lt;/tr&gt;
        ///  &lt;/tbody&gt;
        ///  &lt;tfoot&gt;
        ///    &lt;tr&gt;
        ///      &lt; [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ResetPassword {
            get {
                return ResourceManager.GetString("ResetPassword", resourceCulture);
            }
        }
    }
}
