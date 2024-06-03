using System.Threading.Tasks;
using Util.Templates.HandlebarsDotNet;
using Xunit;

namespace Util.Templates.Handlebars.Tests.Integration; 

/// <summary>
/// Razor模板引擎测试 - 渲染模板字符串
/// </summary>
public class HandlebarsTemplateEngineTest {
    /// <summary>
    /// Razor模板引擎
    /// </summary>
    private readonly IHandlebarsTemplateEngine _templateEngine;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public HandlebarsTemplateEngineTest( IHandlebarsTemplateEngine templateEngine ) {
        _templateEngine = templateEngine;
    }

    /// <summary>
    /// 测试渲染模板 - 渲染没有数据的模板
    /// </summary>
    [Fact]
    public void TestRender_1() {
        var result = _templateEngine.Render( "a" );
        Assert.Equal( "a", result );
    }

    /// <summary>
    /// 测试渲染模板 - 渲染带变量模板,使用匿名对象传递数据
    /// </summary>
    [Fact]
    public void TestRender_2() {
        var result = _templateEngine.Render( "hello {{Name}}", new { Name = "util" } );
        Assert.Equal( "hello util", result );
    }

    /// <summary>
    /// 测试渲染模板 - 中文编码
    /// </summary>
    [Fact]
    public void TestRender_3() {
        var source = "<div>{{Text}}   {}</div>";
        var value = new { Text = "<你好>" };
        var actual2 = _templateEngine.Render( source, value );
        Assert.Equal( "<div><你好>   {}</div>", actual2 );
    }

    /// <summary>
    /// 测试渲染模板 - Html编码器
    /// </summary>
    [Fact]
    public void TestHtmlEncoder() {
        var source = "<div>{{Text2}}   {}</div>";
        var value = new { Text2 = "<你好>" };
        var actual2 = _templateEngine.HtmlEncoder().Render( source, value );
        Assert.Equal( "<div>&lt;你好&gt;   {}</div>", actual2 );
    }

    /// <summary>
    /// 测试异步渲染模板 
    /// </summary>
    [Fact]
    public async Task TestRenderAsync() {
        var result = await _templateEngine.RenderAsync( "a" );
        Assert.Equal( "a", result );
    }

    /// <summary>
    /// 测试渲染模板 - 渲染带变量模板,使用匿名对象传递数据
    /// </summary>
    [Fact]
    public async Task TestRenderAsync_2() {
        var result = await _templateEngine.RenderAsync( "hello {{Name}}", new { Name = "util" } );
        Assert.Equal( "hello util", result );
    }
}