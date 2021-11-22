using System;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace RazorEngineCore
{
    public class RazorEngineCompilationOptionsBuilder : IRazorEngineCompilationOptionsBuilder
    {
        public RazorEngineCompilationOptions Options { get; set; }

        public RazorEngineCompilationOptionsBuilder(RazorEngineCompilationOptions options = null)
        {
            this.Options = options ?? new RazorEngineCompilationOptions();
        }

        public void AddAssemblyReferenceByName(string assemblyName)
        {
            Assembly assembly = Assembly.Load(new AssemblyName(assemblyName));
            this.AddAssemblyReference(assembly);
        }

        public void AddAssemblyReference(Assembly assembly)
        {
            this.Options.ReferencedAssemblies.Add(assembly);
        }

        public void AddAssemblyReference(Type type)
        {
            this.AddAssemblyReference(type.Assembly);

            foreach (Type argumentType in type.GenericTypeArguments)
            {
                this.AddAssemblyReference(argumentType);
            }
        }

        public void AddMetadataReference(MetadataReference reference)
        {
            this.Options.MetadataReferences.Add(reference);
        }

        public void AddUsing(string namespaceName)
        {
            this.Options.DefaultUsings.Add(namespaceName);
        }

        public void Inherits(Type type)
        {
            this.Options.Inherits = this.RenderTypeName(type);
            this.AddAssemblyReference(type);
        }

        private string RenderTypeName(Type type)
        {
            string result = type.Namespace + "." + type.Name;

            if (result.Contains('`'))
            {
                result = result.Substring(0, result.IndexOf("`"));
            }

            if (type.GenericTypeArguments.Length == 0)
            {
                return result;
            }

            return result + "<" + string.Join(",", type.GenericTypeArguments.Select(this.RenderTypeName)) + ">";
        }
    }
}