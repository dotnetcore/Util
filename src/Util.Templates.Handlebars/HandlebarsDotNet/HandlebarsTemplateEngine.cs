namespace Util.Templates.HandlebarsDotNet;

/// <summary>
/// Handlebars模板引擎
/// </summary>
public class HandlebarsTemplateEngine : IHandlebarsTemplateEngine {
    /// <summary>
    /// 模板缓存
    /// </summary>
    protected static readonly ConcurrentDictionary<int, HandlebarsTemplate<object, object>> TemplateCache = new();
    /// <summary>
    /// 文本编码器
    /// </summary>
    private ITextEncoder _encoder;

    /// <summary>
    /// 清除缓存
    /// </summary>
    public static void ClearCache() {
        TemplateCache.Clear();
    }

    /// <summary>
    /// 设置文本编码器
    /// </summary>
    /// <param name="encoder">文本编码器</param>
    public IHandlebarsTemplateEngine Encoder( ITextEncoder encoder ) {
        _encoder = encoder;
        return this;
    }

    /// <summary>
    /// 设置 Html 编码器
    /// </summary>
    public IHandlebarsTemplateEngine HtmlEncoder() {
        return Encoder( new HtmlEncoder() );
    }

    /// <summary>
    /// 渲染模板
    /// </summary>
    /// <param name="template">模板字符串</param>
    /// <param name="data">模板数据</param>
    public virtual string Render( string template, object data = null ) {
        if ( string.IsNullOrWhiteSpace( template ) )
            return null;
        var compiledTemplate = GetCompiledTemplateFromCache( template );
        return compiledTemplate?.Invoke( data );
    }

    /// <summary>
    /// 从缓存中获取已编译模板
    /// </summary>
    protected virtual HandlebarsTemplate<object, object> GetCompiledTemplateFromCache( string template ) {
        return TemplateCache.GetOrAdd( template.GetHashCode(), _ => {
            var handlebars = Handlebars.Create();
            handlebars.Configuration.TextEncoder = _encoder;
            return handlebars.Compile( template );
        } );
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