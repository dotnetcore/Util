using System.Globalization;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Localization;
using Util.Helpers;

namespace Util.Localization.Json {
    /// <summary>
    /// 路径解析器
    /// </summary>
    public class PathResolver : IPathResolver {
        /// <inheritdoc />
        public string GetRootNamespace( Assembly assembly ) {
            assembly.CheckNull( nameof(assembly) );
            var attribute = assembly.GetCustomAttribute<RootNamespaceAttribute>();
            return attribute == null ? assembly.GetName().Name : attribute.RootNamespace;
        }

        /// <inheritdoc />
        public string GetResourcesRootPath( Assembly assembly, string rootPath ) {
            if ( assembly == null )
                return rootPath;
            var attribute = assembly.GetCustomAttribute<ResourceLocationAttribute>();
            return attribute == null ? rootPath : attribute.ResourceLocation;
        }

        /// <inheritdoc />
        public string GetResourcesBaseName( Assembly assembly, string typeFullName ) {
            var rootNamespace = GetRootNamespace( assembly );
            return typeFullName.RemoveStart( $"{rootNamespace}." );
        }

        /// <inheritdoc />
        public string GetJsonResourcePath( string rootPath, string baseName, CultureInfo culture ) {
            if( baseName.IsEmpty() )
                return Path.Combine( Common.ApplicationBaseDirectory, rootPath, $"{culture.Name}.json" );
            baseName = FixInnerClassPath( baseName );
            return Path.Combine( Common.ApplicationBaseDirectory, rootPath, $"{baseName}.{culture.Name}.json" );
        }

        /// <summary>
        /// 修复内部类分隔符+
        /// </summary>
        private string FixInnerClassPath( string path ) {
            const char innerClassSeparator = '+';
            return path.Contains( innerClassSeparator ) ? path.Replace( innerClassSeparator, '.' ) : path;
        }
    }
}
