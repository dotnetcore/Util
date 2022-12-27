using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Util.Reflections {
    /// <summary>
    /// 应用程序域程序集查找器
    /// </summary>
    public class AppDomainAssemblyFinder : IAssemblyFinder {
        /// <summary>
        /// 程序集过滤模式
        /// </summary>
        public string AssemblySkipPattern { get; set; }
        /// <summary>
        /// 程序集列表
        /// </summary>
        private List<Assembly> _assemblies;

        /// <summary>
        /// 获取程序集列表
        /// </summary>
        public List<Assembly> Find() {
            if ( _assemblies != null )
                return _assemblies;
            _assemblies = new List<Assembly>();
            LoadAssemblies();
            foreach( var assembly in AppDomain.CurrentDomain.GetAssemblies() ) {
                if( IsSkip( assembly ) )
                    continue;
                _assemblies.Add( assembly );
            }
            return _assemblies;
        }

        /// <summary>
        /// 加载引用但尚未调用的程序集列表到当前应用程序域
        /// </summary>
        protected virtual void LoadAssemblies() {
            var currentDomainAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach( string file in GetLoadAssemblyFiles() )
                LoadAssembly( file, currentDomainAssemblies );
        }

        /// <summary>
        /// 获取需要加载的程序集文件列表
        /// </summary>
        protected virtual string[] GetLoadAssemblyFiles() {
            return Directory.GetFiles( AppContext.BaseDirectory, "*.dll" );
        }

        /// <summary>
        /// 加载程序集到当前应用程序域
        /// </summary>
        protected void LoadAssembly( string file, Assembly[] currentDomainAssemblies ) {
            try {
                var assemblyName = AssemblyName.GetAssemblyName( file );
                if( IsSkip( assemblyName.Name ) )
                    return;
                if( currentDomainAssemblies.Any( t => t.FullName == assemblyName.FullName ) )
                    return;
                AppDomain.CurrentDomain.Load( assemblyName );
            }
            catch( BadImageFormatException ) {
            }
        }

        /// <summary>
        /// 是否过滤程序集
        /// </summary>
        protected bool IsSkip( string assemblyName ) {
            var applicationName = Assembly.GetEntryAssembly()?.GetName().Name;
            if ( assemblyName.StartsWith( $"{applicationName}.Views" ) )
                return true;
            if( assemblyName.StartsWith( $"{applicationName}.PrecompiledViews" ) )
                return true;
            if ( string.IsNullOrWhiteSpace( AssemblySkipPattern ) )
                return false;
            return Regex.IsMatch( assemblyName, AssemblySkipPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled );
        }

        /// <summary>
        /// 是否过滤程序集
        /// </summary>
        private bool IsSkip( Assembly assembly ) {
            return IsSkip( assembly.FullName );
        }
    }
}
