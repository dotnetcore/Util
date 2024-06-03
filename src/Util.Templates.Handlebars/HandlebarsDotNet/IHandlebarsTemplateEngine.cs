namespace Util.Templates.HandlebarsDotNet;

/// <summary>
/// Handlebars模板引擎
/// </summary>
public interface IHandlebarsTemplateEngine : ITemplateEngine {
    /// <summary>
    /// 设置文本编码器
    /// </summary>
    /// <param name="encoder">文本编码器</param>
    IHandlebarsTemplateEngine Encoder( ITextEncoder encoder );
    /// <summary>
    /// 设置 Html 编码器
    /// </summary>
    IHandlebarsTemplateEngine HtmlEncoder();
}