using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis;
using System;

namespace RazorEngineCore
{
    public class RazorEngineCompilationOptions
    {
        public HashSet<Assembly> ReferencedAssemblies { get; set; }

        public HashSet<MetadataReference> MetadataReferences { get; set; } = new HashSet<MetadataReference>();
        public string TemplateNamespace { get; set; } = "TemplateNamespace";
        public string Inherits { get; set; } = "RazorEngineCore.RazorEngineTemplateBase";

        public HashSet<string> DefaultUsings { get; set; } = new HashSet<string>()
        {
            "System.Linq",
            "System.Collections",
            "System.Collections.Generic"
        };

        public RazorEngineCompilationOptions()
        {
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            bool isFullFramework = RuntimeInformation.FrameworkDescription.StartsWith(".NET Framework", StringComparison.OrdinalIgnoreCase);

            if (isWindows && isFullFramework)
            {
                this.ReferencedAssemblies = new HashSet<Assembly>()
                {
                    typeof(object).Assembly,
                    Assembly.Load(new AssemblyName("Microsoft.CSharp, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    typeof(RazorEngineTemplateBase).Assembly,
                    typeof(System.Runtime.GCSettings).Assembly,
                    typeof(System.Collections.IList).Assembly,
                    typeof(System.Collections.Generic.IEnumerable<>).Assembly,
                    typeof(System.Linq.Enumerable).Assembly,
                    typeof(System.Linq.Expressions.Expression).Assembly,
                    Assembly.Load(new AssemblyName("netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"))
                };
            }

            if (isWindows && !isFullFramework) // i.e. NETCore
            {
                this.ReferencedAssemblies = new HashSet<Assembly>()
                {
                    typeof(object).Assembly,
                    Assembly.Load(new AssemblyName("Microsoft.CSharp")),
                    typeof(RazorEngineTemplateBase).Assembly,
                    Assembly.Load(new AssemblyName("System.Runtime")),
                    typeof(System.Collections.IList).Assembly,
                    typeof(System.Collections.Generic.IEnumerable<>).Assembly,
                    Assembly.Load(new AssemblyName("System.Linq")),
                    Assembly.Load(new AssemblyName("System.Linq.Expressions")),
                    Assembly.Load(new AssemblyName("netstandard"))
                };
            }

            if (!isWindows)
            {
                this.ReferencedAssemblies = new HashSet<Assembly>()
                {
                    typeof(object).Assembly,
                    Assembly.Load(new AssemblyName("Microsoft.CSharp")),
                    typeof(RazorEngineTemplateBase).Assembly,
                    Assembly.Load(new AssemblyName("System.Runtime")),
                    typeof(System.Collections.IList).Assembly,
                    typeof(System.Collections.Generic.IEnumerable<>).Assembly,
                    Assembly.Load(new AssemblyName("System.Linq")),
                    Assembly.Load(new AssemblyName("System.Linq.Expressions")),
                    Assembly.Load(new AssemblyName("netstandard"))
                };
            }
        }
    }
}