using System;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace RazorEngineCore
{
    public interface IRazorEngineCompilationOptionsBuilder
    {
        RazorEngineCompilationOptions Options { get; set; }
        
        void AddAssemblyReferenceByName(string assemblyName);
        
        void AddAssemblyReference(Assembly assembly);
        
        void AddAssemblyReference(Type type);

        void AddMetadataReference(MetadataReference reference);
        
        void AddUsing(string namespaceName);
        
        void Inherits(Type type);
    }
}