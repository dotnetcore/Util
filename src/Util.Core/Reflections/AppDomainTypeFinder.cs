using System;
using System.Collections.Generic;
using System.Reflection;
using Util.Helpers;

namespace Util.Reflections {
    /// <summary>
    /// 应用程序域类型查找器
    /// </summary>
    public class AppDomainTypeFinder : ITypeFinder {
        /// <summary>
        /// 程序集查找器
        /// </summary>
        private readonly IAssemblyFinder _assemblyFinder;

        /// <summary>
        /// 初始化应用程序域类型查找器
        /// </summary>
        /// <param name="assemblyFinder">程序集查找器</param>
        public AppDomainTypeFinder( IAssemblyFinder assemblyFinder ) {
            _assemblyFinder = assemblyFinder ?? throw new ArgumentNullException( nameof( assemblyFinder ) );
        }

        /// <summary>
        /// 查找类型列表
        /// </summary>
        /// <typeparam name="T">查找类型</typeparam>
        public List<Type> Find<T>() {
            return Find( typeof( T ) );
        }

        /// <summary>
        /// 获取程序集列表
        /// </summary>
        public List<Assembly> GetAssemblies() {
            return _assemblyFinder.Find();
        }

        /// <summary>
        /// 查找类型列表
        /// </summary>
        /// <param name="findType">查找类型</param>
        public List<Type> Find( Type findType ) {
            return Reflection.FindImplementTypes( findType, GetAssemblies()?.ToArray() );
        }
    }
}
