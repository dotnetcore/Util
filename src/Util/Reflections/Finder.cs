using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Util.Reflections {
    /// <summary>
    /// 类型查找器
    /// </summary>
    public class Finder : IFind {
        /// <summary>
        /// 跳过的程序集
        /// </summary>
        private const string SkipAssemblies = "^Npoi|^System|^Mscorlib|^Netstandard|^Microsoft|^Autofac|^AutoMapper|^EntityFramework|^Newtonsoft|^Castle|^NLog|^Pomelo|^AspectCore|^Xunit|^Nito|^Npgsql|^Exceptionless|^MySqlConnector|^Anonymously Hosted";

        /// <summary>
        /// 获取程序集列表
        /// </summary>
        public virtual List<Assembly> GetAssemblies() {
            return GetAssembliesFromCurrentAppDomain();
        }

        /// <summary>
        /// 从当前应用程序域获取程序集列表
        /// </summary>
        private List<Assembly> GetAssembliesFromCurrentAppDomain() {
            var result = new List<Assembly>();
            foreach( var assembly in AppDomain.CurrentDomain.GetAssemblies() ) {
                if( Match( assembly ) )
                    result.Add( assembly );
            }
            return result.Distinct().ToList();
        }

        /// <summary>
        /// 程序集是否匹配
        /// </summary>
        private bool Match( Assembly assembly ) {
            return !Regex.IsMatch( assembly.FullName, SkipAssemblies, RegexOptions.IgnoreCase | RegexOptions.Compiled );
        }

        /// <summary>
        /// 加载程序集到当前应用程序域
        /// </summary>
        /// <param name="path">目录绝对路径</param>
        protected void LoadAssemblies( string path ) {            
            var dllFiles = new List<string>(); 
            // 自动注册的程序集配置文件，置于当前根路径下
            // 配置文件内容为程序集文件名称（含后缀名），注意大小写 
            string configFile = Path.Combine(path, "di.txt");
            
            if (File.Exists(configFile))
            {
                // 存在配置文件，则从配置文件中读取
                using (var dllReader = File.OpenText(configFile))
                {
                    var line = dllReader.ReadLine();
                    while (line != null)
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            // 只读取后缀名为.dll的程序集文件
                            if (line.Trim().EndsWith(".dll"))
                            {
                                var fn = Path.Combine(path, line.Trim());
                                // 如果在当前目录下存在程序集文件，则加入要自动注册的文件集合中
                                if (File.Exists(fn))
                                {
                                    dllFiles.Add(fn);
                                }
                            }
                        }
                        line = dllReader.ReadLine();
                    }
                }
            }
            else // 如果不存在配置文件，则自动从当前根路径下读取所有dll文件
            {
                dllFiles = Directory.GetFiles(path, "*.dll").ToList();
            }

            // 遍历所有程序集文件
            foreach ( string file in dllFiles) {
                var assemblyName = AssemblyName.GetAssemblyName( file );
                if (Match(assemblyName))
                {
                    try
                    {
                        AppDomain.CurrentDomain.Load(assemblyName);                       
                    }
                    finally
                    { }
                }
            }
        }

        /// <summary>
        /// 程序集是否匹配
        /// </summary>
        private bool Match( AssemblyName assemblyName ) {
            return !Regex.IsMatch( assemblyName.FullName, SkipAssemblies, RegexOptions.IgnoreCase | RegexOptions.Compiled );
        }

        /// <summary>
        /// 查找类型列表
        /// </summary>
        /// <typeparam name="T">查找类型</typeparam>
        /// <param name="assemblies">在指定的程序集列表中查找</param>
        public List<Type> Find<T>( List<Assembly> assemblies = null ) {
            return Find( typeof( T ), assemblies );
        }

        /// <summary>
        /// 查找类型列表
        /// </summary>
        /// <param name="findType">查找类型</param>
        /// <param name="assemblies">在指定的程序集列表中查找</param>
        public List<Type> Find( Type findType, List<Assembly> assemblies = null ) {
            assemblies = assemblies ?? GetAssemblies();
            var result = new List<Type>();
            foreach( var assembly in assemblies )
                result.AddRange( GetTypes( findType, assembly ) );
            return result.Distinct().ToList();
        }

        /// <summary>
        /// 获取类型列表
        /// </summary>
        private List<Type> GetTypes( Type findType, Assembly assembly ) {
            var result = new List<Type>();
            Type[] types;
            try {
                types = assembly.GetTypes();
            }
            catch( ReflectionTypeLoadException ) {
                return result;
            }
            if( types == null )
                return result;
            foreach( var type in types )
                AddType( result, findType, type );
            return result;
        }

        /// <summary>
        /// 添加类型
        /// </summary>
        private void AddType( List<Type> result, Type findType,  Type type ) {
            if( type.IsInterface || type.IsAbstract )
                return;
            if ( findType.IsAssignableFrom( type ) == false && MatchGeneric( findType, type ) == false )
                return;
            result.Add( type );
        }

        /// <summary>
        /// 泛型匹配
        /// </summary>
        private bool MatchGeneric( Type findType, Type type ) {
            if ( findType.IsGenericTypeDefinition == false )
                return false;
            var definition = findType.GetGenericTypeDefinition();
            foreach ( var implementedInterface in type.FindInterfaces( ( filter, criteria ) => true, null ) ) {
                if( implementedInterface.IsGenericType == false )
                    continue;
                return definition.IsAssignableFrom( implementedInterface.GetGenericTypeDefinition() );
            }
            return false;
        }
    }
}
