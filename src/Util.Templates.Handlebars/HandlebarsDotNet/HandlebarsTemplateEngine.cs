using System.Collections.Concurrent;
using System.Threading.Tasks;
using HandlebarsDotNet;

namespace Util.Templates.HandlebarsDotNet {
    /// <summary>
    /// Handlebars模板引擎
    /// </summary>
    public class HandlebarsTemplateEngine: IHandlebarsTemplateEngine {
        /// <summary>
        /// 模板缓存
        /// </summary>
        protected static readonly ConcurrentDictionary<int, HandlebarsTemplate<object, object>> TemplateCache = new();

        /// <summary>
        /// 清除缓存
        /// </summary>
        public static void ClearCache() {
            TemplateCache.Clear();
        }
        /// <summary>
        /// 渲染模板
        /// </summary>
        /// <param name="template">模板字符串</param>
        /// <param name="data">模板数据</param>
        public virtual string Render( string template, object data = null ) {
            if( string.IsNullOrWhiteSpace( template ) )
                return null;
            var compiledTemplate = GetCompiledTemplateFromCache( template );
            return compiledTemplate?.Invoke( data );
        }

        /// <summary>
        /// 从缓存中获取已编译模板
        /// </summary>
        protected virtual HandlebarsTemplate<object, object> GetCompiledTemplateFromCache( string template ) {
            return TemplateCache.GetOrAdd( template.GetHashCode(), t => Handlebars.Compile( template ) );
        }

        /// <summary>
        /// 渲染模板
        /// </summary>
        /// <param name="template">模板字符串</param>
        /// <param name="data">模板数据</param>
        public virtual Task<string> RenderAsync( string template, object data = null ) {
            return Task.FromResult( Render( template, data ) );
        }
    }
}
