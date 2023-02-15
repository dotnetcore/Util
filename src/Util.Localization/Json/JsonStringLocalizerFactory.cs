using System;
using System.Reflection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Util.Localization.Json {
    /// <summary>
    /// Json字符串定位器工厂
    /// </summary>
    public class JsonStringLocalizerFactory : IStringLocalizerFactory {
        /// <summary>
        /// 资源根目录路径
        /// </summary>
        private readonly string _rootPath;
        /// <summary>
        /// 路径解析器
        /// </summary>
        private readonly IPathResolver _pathResolver;
        /// <summary>
        /// 日志工厂
        /// </summary>
        private readonly ILoggerFactory _loggerFactory;

        /// <summary>
        /// 初始化Json字符串定位器工厂
        /// </summary>
        /// <param name="options">本地化配置</param>
        /// <param name="pathResolver">本地化配置</param>
        /// <param name="loggerFactory">本地化配置</param>
        public JsonStringLocalizerFactory( IOptions<LocalizationOptions> options, IPathResolver pathResolver, ILoggerFactory loggerFactory ) {
            options.CheckNull( nameof( options ) );
            _rootPath = options.Value.ResourcesPath;
            _pathResolver = pathResolver ?? throw new ArgumentNullException( nameof( pathResolver ) );
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException( nameof(loggerFactory) );
        }

        /// <summary>
        /// 创建Json字符串定位器
        /// </summary>
        /// <param name="resourceSource">资源类型</param>
        public IStringLocalizer Create( Type resourceSource ) {
            resourceSource.CheckNull( nameof( resourceSource ) );
            var assembly = resourceSource.Assembly;
            var rootPath = _pathResolver.GetResourcesRootPath( assembly, _rootPath );
            var baseName = _pathResolver.GetResourcesBaseName( assembly, resourceSource.FullName );
            return new JsonStringLocalizer( _pathResolver, rootPath, baseName, _loggerFactory.CreateLogger<JsonStringLocalizer>() );
        }

        /// <summary>
        /// 创建Json字符串定位器
        /// </summary>
        /// <param name="baseName">资源名称</param>
        /// <param name="location">资源位置</param>
        public IStringLocalizer Create( string baseName, string location ) {
            location ??= new AssemblyName( GetType().Assembly.FullName ).Name;
            var assemblyName = new AssemblyName( location );
            var assembly = Assembly.Load( assemblyName );
            var rootPath = _pathResolver.GetResourcesRootPath( assembly, _rootPath );
            return new JsonStringLocalizer( _pathResolver, rootPath, baseName, _loggerFactory.CreateLogger<JsonStringLocalizer>() );
        }
    }
}
