﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoogleTestAdapter.DiaResolver {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GoogleTestAdapter.DiaResolver.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Attempts to find PDB {0}.
        /// </summary>
        internal static string AttemptsToFind {
            get {
                return ResourceManager.GetString("AttemptsToFind", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to In order to get source locations for your tests, please ensure to generate *full* PDBs for your test executables..
        /// </summary>
        internal static string GenerateFullPDBMessage {
            get {
                return ResourceManager.GetString("GenerateFullPDBMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to locate line number for {0}.
        /// </summary>
        internal static string LineNumberError {
            get {
                return ResourceManager.GetString("LineNumberError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot load {0}..
        /// </summary>
        internal static string LoadError {
            get {
                return ResourceManager.GetString("LoadError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Couldn&apos;t find the msdia.dll to parse *.pdb files. You will not get any source locations for your tests..
        /// </summary>
        internal static string msdiaError {
            get {
                return ResourceManager.GetString("msdiaError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parsing PDB file {0}.
        /// </summary>
        internal static string ParsingFile {
            get {
                return ResourceManager.GetString("ParsingFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Couldn&apos;t find the .pdb file of file &apos;{0}&apos;. You will not get any source locations for your tests..
        /// </summary>
        internal static string PdbFileNotFoundError {
            get {
                return ResourceManager.GetString("PdbFileNotFoundError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UnMapAndLoad failed!.
        /// </summary>
        internal static string UnMapLoad {
            get {
                return ResourceManager.GetString("UnMapLoad", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use linker option /DEBUG:FULL (Visual Studio 2017) or /DEBUG (Visual Studio 2015 and older) - do not use /DEBUG:FASTLINK!.
        /// </summary>
        internal static string UseLinkerOption {
            get {
                return ResourceManager.GetString("UseLinkerOption", resourceCulture);
            }
        }
    }
}
