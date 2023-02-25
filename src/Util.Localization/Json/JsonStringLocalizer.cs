using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Util.Localization.Json {
    /// <summary>
    /// Json字符串定位器
    /// </summary>
    public class JsonStringLocalizer : IStringLocalizer {
        /// <summary>
        /// 路径解析器
        /// </summary>
        private readonly IPathResolver _pathResolver;
        /// <summary>
        /// 资源根目录路径
        /// </summary>
        private readonly string _resourcesRootPath;
        /// <summary>
        /// 资源基名称
        /// </summary>
        private readonly string _resourcesBaseName;
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// 资源缓存
        /// </summary>
        private readonly ConcurrentDictionary<string, IEnumerable<KeyValuePair<string, string>>> _resourcesCache;
        /// <summary>
        /// 搜索位置
        /// </summary>
        private readonly string _searchedLocation;

        /// <summary>
        /// 初始化Json字符串定位器
        /// </summary>
        /// <param name="pathResolver">路径解析器</param>
        /// <param name="resourcesRootPath">资源根目录路径</param>
        /// <param name="resourcesBaseName">资源基名称</param>
        /// <param name="logger">资源基名称</param>
        public JsonStringLocalizer( IPathResolver pathResolver, string resourcesRootPath, string resourcesBaseName, ILogger logger ) {
            _pathResolver = pathResolver;
            _resourcesRootPath = resourcesRootPath;
            _resourcesBaseName = resourcesBaseName;
            _logger = logger;
            _resourcesCache = new ConcurrentDictionary<string, IEnumerable<KeyValuePair<string, string>>>();
            _searchedLocation = $"{resourcesRootPath}.{resourcesBaseName}";
        }

        /// <summary>
        /// 获取本地化字符串
        /// </summary>
        /// <param name="name">本地化字符串名称</param>
        public LocalizedString this[string name] {
            get {
                name.CheckNull( nameof( name ) );
                var value = GetValue( name, _resourcesBaseName ) ?? GetValue( name, null );
                return new LocalizedString( name, value ?? name, value == null, _searchedLocation );
            }
        }

        /// <summary>
        /// 获取本地化字符串
        /// </summary>
        /// <param name="name">本地化字符串名称</param>
        /// <param name="arguments">参数列表</param>
        public LocalizedString this[ string name, params object[] arguments ] {
            get {
                name.CheckNull( nameof( name ) );
                var format = GetValue( name, _resourcesBaseName ) ?? GetValue( name, null );
                var value = string.Format( format ?? name, arguments );
                return new LocalizedString( name, value, format == null, _searchedLocation );
            }
        }

        /// <summary>
        /// 获取资源值
        /// </summary>
        /// <param name="name">资源名称</param>
        /// <param name="resourcesBaseName">资源基名称</param>
        protected virtual string GetValue( string name,string resourcesBaseName ) {
            var cultures = Util.Helpers.Culture.GetCurrentUICultures();
            foreach ( var culture in cultures ) {
                var resources = GetResourcesByCache( culture, resourcesBaseName );
                if ( resources == null )
                    continue;
                var resource = resources.SingleOrDefault( t => t.Key == name );
                var result = resource.Value;
                _logger.SearchedLocation( name, _searchedLocation, culture );
                return result;
            }
            return null;
        }

        /// <summary>
        /// 从缓存获取资源列表
        /// </summary>
        /// <param name="culture">区域文化</param>
        /// <param name="resourcesBaseName">资源基名称</param>
        protected virtual IEnumerable<KeyValuePair<string, string>> GetResourcesByCache( CultureInfo culture, string resourcesBaseName ) {
            return _resourcesCache.GetOrAdd( $"{culture.Name}_{resourcesBaseName}", t => GetResources( culture, resourcesBaseName ) );
        }

        /// <summary>
        /// 获取资源列表
        /// </summary>
        /// <param name="culture">区域文化</param>
        /// <param name="resourcesBaseName">资源基名称</param>
        protected virtual IEnumerable<KeyValuePair<string, string>> GetResources( CultureInfo culture, string resourcesBaseName ) {
            var path = _pathResolver.GetJsonResourcePath( _resourcesRootPath, resourcesBaseName, culture );
            if ( File.Exists( path ) == false ) {
                if ( resourcesBaseName.IsEmpty() )
                    return null;
                path = _pathResolver.GetJsonResourcePath( _resourcesRootPath, resourcesBaseName.Replace( '.', Path.DirectorySeparatorChar ), culture );
            }
            if ( File.Exists( path ) == false )
                return null;
            var builder = new ConfigurationBuilder()
                .AddJsonFile( path, optional: false, reloadOnChange: false );
            var config = builder.Build();
            return config.AsEnumerable();
        }

        /// <summary>
        /// 获取全部本地化字符串
        /// </summary>
        /// <param name="includeParentCultures">是否包含父区域</param>
        public virtual IEnumerable<LocalizedString> GetAllStrings( bool includeParentCultures ) {
            var result = new List<LocalizedString>();
            var cultures = Util.Helpers.Culture.GetCurrentUICultures();
            foreach ( var culture in cultures ) {
                var resources = ToLocalizedStrings( GetResourcesByCache( culture,_resourcesBaseName ) );
                result.AddRange( resources );
                if ( includeParentCultures == false )
                    return result;
            }
            return result;
        }

        /// <summary>
        /// 转换为LocalizedString集合
        /// </summary>
        protected virtual IEnumerable<LocalizedString> ToLocalizedStrings( IEnumerable<KeyValuePair<string, string>> resources ) {
            var result = new List<LocalizedString>();
            foreach ( var resource in resources )
                result.Add( new LocalizedString( resource.Key, resource.Value, false, _searchedLocation ) );
            return result;
        }
    }
}
