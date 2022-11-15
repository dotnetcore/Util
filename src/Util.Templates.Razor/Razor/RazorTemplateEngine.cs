using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Threading.Tasks;
using RazorEngineCore;

namespace Util.Templates.Razor {
    /// <summary>
    /// Razor模板引擎
    /// </summary>
    public class RazorTemplateEngine : IRazorTemplateEngine {
        /// <summary>
        /// 模板过滤器
        /// </summary>
        private static readonly ConcurrentDictionary<string, ITemplateFilter> _filters = new();
        /// <summary>
        /// 程序集引用列表
        /// </summary>
        private static readonly ConcurrentDictionary<string, Assembly> _assemblies = new();
        /// <summary>
        /// 模板缓存
        /// </summary>
        protected static readonly ConcurrentDictionary<int, IRazorEngineCompiledTemplate> TemplateCache = new();
        /// <summary>
        /// 是否自动加载程序集引用列表
        /// </summary>
        private static bool _isAutoLoadAssemblies;
        /// <summary>
        /// Razor模板引擎
        /// </summary>
        protected readonly IRazorEngine RazorEngine;

        /// <summary>
        /// 初始化Razor模板引擎
        /// </summary>
        /// <param name="razorEngine">Razor模板引擎</param>
        public RazorTemplateEngine( IRazorEngine razorEngine ) {
            RazorEngine = razorEngine ?? throw new ArgumentNullException( nameof( razorEngine ) );
            _isAutoLoadAssemblies = true;
        }

        /// <summary>
        /// 清除模板缓存
        /// </summary>
        public static void ClearTemplateCache() {
            TemplateCache.Clear();
        }

        /// <summary>
        /// 添加模板过滤器
        /// </summary>
        /// <param name="filter">模板过滤器</param>
        public static void AddFilter( ITemplateFilter filter ) {
            if ( filter == null )
                return;
            _filters.TryAdd( filter.GetType().FullName, filter );
        }

        /// <summary>
        /// 清除模板过滤器
        /// </summary>
        public static void ClearFilters() {
            _filters.Clear();
        }

        /// <summary>
        /// 添加程序集引用
        /// </summary>
        /// <param name="assembly">程序集</param>
        public static void AddAssemblyReference( Assembly assembly ) {
            _assemblies.TryAdd( assembly.FullName, assembly );
        }

        /// <summary>
        /// 添加程序集引用
        /// </summary>
        /// <param name="assembly">程序集</param>
        public static void AddAssemblyReference( string assembly ) {
            AddAssemblyReference( Assembly.Load( assembly ) );
        }

        /// <summary>
        /// 禁止自动加载程序集引用列表
        /// </summary>
        public static void DisableAutoLoadAssemblies() {
            _isAutoLoadAssemblies = false;
        }

        /// <summary>
        /// 渲染模板
        /// </summary>
        /// <param name="template">模板字符串</param>
        /// <param name="data">模板数据</param>
        public string Render( string template, object data = null ) {
            return Render( template, data, null );
        }

        /// <summary>
        /// 渲染模板
        /// </summary>
        /// <param name="template">模板字符串</param>
        /// <param name="data">模板数据</param>
        /// <param name="builderAction">模板编译配置操作</param>
        public string Render( string template, object data, Action<IRazorEngineCompilationOptionsBuilder> builderAction ) {
            if ( string.IsNullOrWhiteSpace( template ) )
                return null;
            var compiledTemplate = GetCompiledTemplateFromCache( template, builderAction );
            return compiledTemplate?.Run( data );
        }

        /// <summary>
        /// 从缓存中获取已编译模板
        /// </summary>
        private IRazorEngineCompiledTemplate GetCompiledTemplateFromCache( string template, Action<IRazorEngineCompilationOptionsBuilder> builderAction ) {
            return TemplateCache.GetOrAdd( template.GetHashCode(), t => {
                template = FilterTemplate( template );
                return GetCompiledTemplate( template, builderAction );
            } );
        }

        /// <summary>
        /// 过滤模板
        /// </summary>
        private string FilterTemplate( string template ) {
            foreach ( var filter in _filters.Values )
                template = filter.Filter( template );
            return template;
        }

        /// <summary>
        /// 获取已编译模板
        /// </summary>
        private IRazorEngineCompiledTemplate GetCompiledTemplate( string template, Action<IRazorEngineCompilationOptionsBuilder> builderAction ) {
            return RazorEngine.Compile( template, builder => {
                LoadAssemblies( builder );
                builderAction?.Invoke( builder );
            } );
        }

        /// <summary>
        /// 加载程序集引用列表
        /// </summary>
        private void LoadAssemblies( IRazorEngineCompilationOptionsBuilder builder ) {
            if ( _isAutoLoadAssemblies == false )
                return;
            foreach ( var assembly in _assemblies.Values ) {
                builder.AddAssemblyReference( assembly );
            }
        }

        /// <summary>
        /// 渲染模板
        /// </summary>
        /// <param name="template">模板字符串</param>
        /// <param name="data">模板数据</param>
        public virtual async Task<string> RenderAsync( string template, object data = null ) {
            return await RenderAsync( template, data, null );
        }

        /// <summary>
        /// 渲染模板
        /// </summary>
        /// <param name="template">模板字符串</param>
        /// <param name="data">模板数据</param>
        /// <param name="builderAction">模板编译配置操作</param>
        public async Task<string> RenderAsync( string template, object data, Action<IRazorEngineCompilationOptionsBuilder> builderAction ) {
            if ( string.IsNullOrWhiteSpace( template ) )
                return null;
            var compiledTemplate = GetCompiledTemplateFromCache( template, builderAction );
            if ( compiledTemplate == null )
                return null;
            return await compiledTemplate.RunAsync( data );
        }
    }
}
