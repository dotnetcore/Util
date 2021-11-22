using System;
using System.Threading.Tasks;
using RazorEngineCore;

namespace Util.Templates.Razor {
    /// <summary>
    /// Razor模板引擎扩展
    /// </summary>
    public static class TemplateEngineExtensions {
        /// <summary>
        /// 清除模板缓存
        /// </summary>
        /// <param name="templateEngine">Razor模板引擎</param>
        public static void ClearTemplateCache( this ITemplateEngine templateEngine ) {
            if( templateEngine == null )
                throw new ArgumentNullException( nameof( templateEngine ) );
            RazorTemplateEngine.ClearTemplateCache();
        }

        /// <summary>
        /// 渲染模板
        /// </summary>
        /// <param name="templateEngine">Razor模板引擎</param>
        /// <param name="template">模板字符串</param>
        /// <param name="data">模板数据</param>
        /// <param name="builderAction">模板编译配置操作</param>
        public static string Render( this ITemplateEngine templateEngine, string template, object data, Action<IRazorEngineCompilationOptionsBuilder> builderAction ) {
            if( templateEngine == null )
                throw new ArgumentNullException( nameof( templateEngine ) );
            if( !( templateEngine is RazorTemplateEngine engine ) )
                return null;
            return engine.Render( template, data, builderAction );
        }

        /// <summary>
        /// 渲染模板
        /// </summary>
        /// <param name="templateEngine">Razor模板引擎</param>
        /// <param name="template">模板字符串</param>
        /// <param name="data">模板数据</param>
        /// <param name="builderAction">模板编译配置操作</param>
        public static async Task<string> RenderAsync( this ITemplateEngine templateEngine, string template, object data, Action<IRazorEngineCompilationOptionsBuilder> builderAction ) {
            if( templateEngine == null )
                throw new ArgumentNullException( nameof( templateEngine ) );
            if( !( templateEngine is RazorTemplateEngine engine ) )
                return null;
            return await engine.RenderAsync( template, data, builderAction );
        }

        /// <summary>
        /// 通过路径渲染模板
        /// </summary>
        /// <param name="templateEngine">模板引擎</param>
        /// <param name="filePath">模板文件绝对路径</param>
        /// <param name="data">模板数据</param>
        /// <param name="builderAction">模板编译配置操作</param>
        public static string RenderByPath( this ITemplateEngine templateEngine, string filePath, object data, Action<IRazorEngineCompilationOptionsBuilder> builderAction ) {
            if( templateEngine == null )
                throw new ArgumentNullException( nameof( templateEngine ) );
            var template = Util.Helpers.File.ReadToString( filePath );
            return templateEngine.Render( template, data, builderAction );
        }

        /// <summary>
        /// 通过路径渲染模板
        /// </summary>
        /// <param name="templateEngine">模板引擎</param>
        /// <param name="filePath">模板文件绝对路径</param>
        /// <param name="data">模板数据</param>
        /// <param name="builderAction">模板编译配置操作</param>
        public static async Task<string> RenderByPathAsync( this ITemplateEngine templateEngine, string filePath, object data, Action<IRazorEngineCompilationOptionsBuilder> builderAction ) {
            if( templateEngine == null )
                throw new ArgumentNullException( nameof( templateEngine ) );
            var template = await Util.Helpers.File.ReadToStringAsync( filePath );
            return await templateEngine.RenderAsync( template, data, builderAction );
        }

        /// <summary>
        /// 渲染模板并保存到文件
        /// </summary>
        /// <param name="templateEngine">模板引擎</param>
        /// <param name="template">模板字符串</param>
        /// <param name="data">模板数据</param>
        /// <param name="filePath">目标文件绝对路径</param>
        /// <param name="builderAction">模板编译配置操作</param>
        public static void Save( this ITemplateEngine templateEngine, string template, object data, string filePath, Action<IRazorEngineCompilationOptionsBuilder> builderAction ) {
            if( templateEngine == null )
                throw new ArgumentNullException( nameof( templateEngine ) );
            var result = templateEngine.Render( template, data, builderAction );
            Util.Helpers.File.Write( filePath, result );
        }

        /// <summary>
        /// 渲染模板并保存到文件
        /// </summary>
        /// <param name="templateEngine">模板引擎</param>
        /// <param name="template">模板字符串</param>
        /// <param name="data">模板数据</param>
        /// <param name="filePath">目标文件绝对路径</param>
        /// <param name="builderAction">模板编译配置操作</param>
        public static async Task SaveAsync( this ITemplateEngine templateEngine, string template, object data, string filePath, Action<IRazorEngineCompilationOptionsBuilder> builderAction ) {
            if( templateEngine == null )
                throw new ArgumentNullException( nameof( templateEngine ) );
            var result = await templateEngine.RenderAsync( template, data, builderAction );
            await Util.Helpers.File.WriteAsync( filePath, result );
        }

        /// <summary>
        /// 通过路径渲染模板并保存到文件
        /// </summary>
        /// <param name="templateEngine">模板引擎</param>
        /// <param name="templatePath">模板文件绝对路径</param>
        /// <param name="data">模板数据</param>
        /// <param name="filePath">目标文件绝对路径</param>
        /// <param name="builderAction">模板编译配置操作</param>
        public static void SaveByPath( this ITemplateEngine templateEngine, string templatePath, object data, string filePath, Action<IRazorEngineCompilationOptionsBuilder> builderAction ) {
            if( templateEngine == null )
                throw new ArgumentNullException( nameof( templateEngine ) );
            var result = templateEngine.RenderByPath( templatePath, data, builderAction );
            Util.Helpers.File.Write( filePath, result );
        }

        /// <summary>
        /// 渲染模板并保存到文件
        /// </summary>
        /// <param name="templateEngine">模板引擎</param>
        /// <param name="templatePath">模板文件绝对路径</param>
        /// <param name="data">模板数据</param>
        /// <param name="filePath">目标文件绝对路径</param>
        /// <param name="builderAction">模板编译配置操作</param>
        public static async Task SaveByPathAsync( this ITemplateEngine templateEngine, string templatePath, object data, string filePath, Action<IRazorEngineCompilationOptionsBuilder> builderAction ) {
            if( templateEngine == null )
                throw new ArgumentNullException( nameof( templateEngine ) );
            var result = await templateEngine.RenderByPathAsync( templatePath, data, builderAction );
            await Util.Helpers.File.WriteAsync( filePath, result );
        }
    }
}
