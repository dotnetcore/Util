using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Util.Microservices.Dapr.Tests.Samples; 

/// <summary>
/// 模拟Http上下文访问器
/// </summary>
public class MockHttpContextAccessor : IHttpContextAccessor {
    /// <summary>
    /// 初始化模拟Http上下文访问器
    /// </summary>
    public MockHttpContextAccessor() {
        HttpContext = new DefaultHttpContext();
        HttpContext.Request.Headers["test_1"] = "test_1";
        HttpContext.Request.Headers.ContentLanguage = new StringValues( "en" );
    }

    /// <summary>
    /// Http上下文
    /// </summary>
    public HttpContext HttpContext { get; set; }
}